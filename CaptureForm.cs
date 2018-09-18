using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SharpPcap;
using PacketDotNet;
using System.Net.NetworkInformation;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;

namespace TosAssist
{
    public partial class CaptureForm : Form
    {
        /// <summary>
        /// When true the background thread will terminate
        /// </summary>
        /// <param name="args">
        /// A <see cref="System.String"/>
        /// </param>
        private bool BackgroundThreadStop;

        /// <summary>
        /// Object that is used to prevent two threads from accessing
        /// PacketQueue at the same time
        /// </summary>
        /// <param name="args">
        /// A <see cref="System.String"/>
        /// </param>
        private object QueueLock = new object();

        /// <summary>
        /// The queue that the callback thread puts packets in. Accessed by
        /// the background thread when QueueLock is held
        /// </summary>
        private List<RawCapture> PacketQueue = new List<RawCapture>();

        /// <summary>
        /// The last time PcapDevice.Statistics() was called on the active device.
        /// Allow periodic display of device statistics
        /// </summary>
        /// <param name="args">
        /// A <see cref="System.String"/>
        /// </param>
        private DateTime LastStatisticsOutput;

        /// <summary>
        /// Interval between PcapDevice.Statistics() output
        /// </summary>
        /// <param name="args">
        /// A <see cref="System.String"/>
        /// </param>
        private TimeSpan LastStatisticsInterval = new TimeSpan(0, 0, 2);

        private System.Threading.Thread backgroundThread;

        private DeviceListForm deviceListForm;
        private ICaptureDevice device;

        //ToS Stuff:

        private int totalPacketsHandled = 0;
        private int incomingDataHandled = 0;

        private List<Entry> stringTable;

        private bool isCovenGame = true;
        string[] names = new string[15];
        string lastNameUp = "";

        private Packet lastSentPacket = null;

        List<ChatItem> chatlog = new List<ChatItem>();


        public CaptureForm()
        {
            InitializeComponent();
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            InitStringTable();
        }

        private void InitStringTable()
        {
            var xmlText = GetResourceTextFile("Resources.Game.xml");
            StringReader rdr = new StringReader(xmlText);

            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Entries";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Entry>), xRoot);
            stringTable = (List<Entry>)serializer.Deserialize(rdr);            

        }

        public string GetResourceTextFile(string filename)
        {
            string result = string.Empty;

            var a = this.GetType().Assembly.GetManifestResourceNames();

            var embeddedName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "." + filename;
            using (Stream stream = this.GetType().Assembly.
                       GetManifestResourceStream(embeddedName))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
            return result;
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
        }

        private void CaptureForm_Load(object sender, EventArgs e)
        {
            deviceListForm = new DeviceListForm();
            deviceListForm.OnItemSelected += new DeviceListForm.OnItemSelectedDelegate(deviceListForm_OnItemSelected);
            deviceListForm.OnCancel += new DeviceListForm.OnCancelDelegate(deviceListForm_OnCancel);
        }

        void deviceListForm_OnItemSelected(int itemIndex)
        {
            // close the device list form
            deviceListForm.Hide();

            StartCapture(itemIndex);
        }

        void deviceListForm_OnCancel()
        {
            Application.Exit();
        }

        public class PacketWrapper
        {
            public RawCapture p;

            public int Count { get; private set; }
            public PosixTimeval Timeval { get { return p.Timeval; } }
            public LinkLayers LinkLayerType { get { return p.LinkLayerType; } }
            public int Length { get { return p.Data.Length; } }

            public PacketWrapper(int count, RawCapture p)
            {
                this.Count = count;
                this.p = p;
            }
        }

        private PacketArrivalEventHandler arrivalEventHandler;


        private CaptureStoppedEventHandler captureStoppedEventHandler;

        private void Shutdown()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device.OnPacketArrival -= arrivalEventHandler;
                device.OnCaptureStopped -= captureStoppedEventHandler;
                device = null;

                // ask the background thread to shut down
                BackgroundThreadStop = true;

                // wait for the background thread to terminate
                backgroundThread.Join();

                // switch the icon back to the play icon
                startStopToolStripButton.Image = global::TosAssist.Properties.Resources.play_icon_enabled;
                startStopToolStripButton.ToolTipText = "Select device to capture from";
            }
        }

        private void StartCapture(int itemIndex)
        {
            packetCount = 0;
            device = CaptureDeviceList.Instance[itemIndex];
            packetStrings = new Queue<PacketWrapper>();
            bs = new BindingSource();
            dataGridView.DataSource = bs;
            LastStatisticsOutput = DateTime.Now;

            // start the background thread
            BackgroundThreadStop = false;
            backgroundThread = new System.Threading.Thread(BackgroundThread);
            backgroundThread.Start();

            // setup background capture
            arrivalEventHandler = new PacketArrivalEventHandler(device_OnPacketArrival);
            device.OnPacketArrival += arrivalEventHandler;
            captureStoppedEventHandler = new CaptureStoppedEventHandler(device_OnCaptureStopped);
            device.OnCaptureStopped += captureStoppedEventHandler;
            device.Open();

            string filter = "port 3600";
            device.Filter = filter;

            // force an initial statistics update
            captureStatistics = device.Statistics;
            UpdateCaptureStatistics();

            // start the background capture
            device.StartCapture();

            // disable the stop icon since the capture has stopped
            startStopToolStripButton.Image = global::TosAssist.Properties.Resources.stop_icon_enabled;
            startStopToolStripButton.ToolTipText = "Stop capture";
        }

        void device_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            if (status != CaptureStoppedEventStatus.CompletedWithoutError)
            {
                MessageBox.Show("Error stopping capture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Queue<PacketWrapper> packetStrings;

        private int packetCount;
        private BindingSource bs;
        private ICaptureStatistics captureStatistics;
        private bool statisticsUiNeedsUpdate = false;

        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            // print out periodic statistics about this device
            var Now = DateTime.Now; // cache 'DateTime.Now' for minor reduction in cpu overhead
            var interval = Now - LastStatisticsOutput;
            if (interval > LastStatisticsInterval)
            {
                Console.WriteLine("device_OnPacketArrival: " + e.Device.Statistics);
                captureStatistics = e.Device.Statistics;
                statisticsUiNeedsUpdate = true;
                LastStatisticsOutput = Now;
            }

            // lock QueueLock to prevent multiple threads accessing PacketQueue at
            // the same time
            lock (QueueLock)
            {
                PacketQueue.Add(e.Packet);
            }
        }

        private void CaptureForm_Shown(object sender, EventArgs e)
        {
            deviceListForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (device == null)
            {
                deviceListForm.Show();
            }
            else
            {
                Shutdown();
            }
        }

        /// <summary>
        /// Checks for queued packets. If any exist it locks the QueueLock, saves a
        /// reference of the current queue for itself, puts a new queue back into
        /// place into PacketQueue and unlocks QueueLock. This is a minimal amount of
        /// work done while the queue is locked.
        ///
        /// The background thread can then process queue that it saved without holding
        /// the queue lock.
        /// </summary>
        private void BackgroundThread()
        {
            while (!BackgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (PacketQueue.Count != 0)
                    {
                        shouldSleep = false;
                    }
                }

                if (shouldSleep)
                {
                    System.Threading.Thread.Sleep(250);
                }
                else // should process the queue
                {
                    List<RawCapture> ourQueue;
                    lock (QueueLock)
                    {
                        // swap queues, giving the capture callback a new one
                        ourQueue = PacketQueue;
                        PacketQueue = new List<RawCapture>();
                    }

                    Console.WriteLine("BackgroundThread: ourQueue.Count is {0}", ourQueue.Count);

                    foreach (var packet in ourQueue)
                    {
                        // Here is where we can process our packets freely without
                        // holding off packet capture.
                        //
                        // NOTE: If the incoming packet rate is greater than
                        //       the packet processing rate these queues will grow
                        //       to enormous sizes. Packets should be dropped in these
                        //       cases

                        var packetWrapper = new PacketWrapper(packetCount, packet);
                        this.BeginInvoke(new MethodInvoker(delegate
                        {
                            packetStrings.Enqueue(packetWrapper);

                            MainPacketHandler(packetWrapper);
                        }
                        ));

                        packetCount++;

                        var time = packet.Timeval.Date;
                        var len = packet.Data.Length;
                        Console.WriteLine("BackgroundThread: {0}:{1}:{2},{3} Len={4}",
                            time.Hour, time.Minute, time.Second, time.Millisecond, len);


                    }

                    this.BeginInvoke(new MethodInvoker(delegate
                    {
                        bs.DataSource = packetStrings.Reverse();

                    }
                    ));

                    if (statisticsUiNeedsUpdate)
                    {
                        UpdateCaptureStatistics();
                        statisticsUiNeedsUpdate = false;
                    }
                }
            }
        }

        private void UpdateCaptureStatistics()
        {
            captureStatisticsToolStripStatusLabel.Text = string.Format("Received packets: {0}, Dropped packets: {1}, Interface dropped packets: {2}",
                                                       captureStatistics.ReceivedPackets,
                                                       captureStatistics.DroppedPackets,
                                                       captureStatistics.InterfaceDroppedPackets);
        }

        private void CaptureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shutdown();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
                return;

            var packetWrapper = (PacketWrapper)dataGridView.Rows[dataGridView.SelectedCells[0].RowIndex].DataBoundItem;
            var packet = Packet.ParsePacket(packetWrapper.p.LinkLayerType, packetWrapper.p.Data);
            packetInfoTextbox.Text = packet.ToString(StringOutputType.VerboseColored);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainPacketHandler(PacketWrapper packet)
        {
           
            totalPacketsHandled++;
            Console.WriteLine("MainPacketHandler for packet " + totalPacketsHandled + " " + packet.Count.ToString());
            //testRichText.Text += totalPacketsHandled + Environment.NewLine;
            
            var packetParsed = PacketDotNet.Packet.ParsePacket(packet.LinkLayerType, packet.p.Data);

            if (packetParsed is PacketDotNet.EthernetPacket)
            {
                var eth = ((PacketDotNet.EthernetPacket)packetParsed);

               // Console.WriteLine("Original Eth packet: " + eth.ToString());

                //Manipulate ethernet parameters
                //eth.SourceHwAddress = PhysicalAddress.Parse("00-11-22-33-44-55");
                //eth.DestinationHwAddress = PhysicalAddress.Parse("00-99-88-77-66-55");

                var ip = (PacketDotNet.IPPacket)packetParsed.Extract(typeof(PacketDotNet.IPPacket));
                if (ip != null)
                {
                    //Console.WriteLine("Original IP packet: " + ip.ToString());

                    //manipulate IP parameters
                    //ip.SourceAddress = System.Net.IPAddress.Parse("1.2.3.4");
                    //ip.DestinationAddress = System.Net.IPAddress.Parse("44.33.22.11");
                    //ip.TimeToLive = 11;

                    var tcp = (PacketDotNet.TcpPacket)packetParsed.Extract(typeof(PacketDotNet.TcpPacket));
                    if (tcp != null)
                    {
                        //Console.WriteLine("Original TCP packet: " + tcp.ToString());
                        if (tcp.SourcePort != 3600)
                        {
                            int i = 1;

                            lastSentPacket = packetParsed;
                            //handle outgoing packets
                        }
                        else
                        {
                            //incoming packet
                            //testRichText.Text = System.Text.Encoding.Default.GetString(tcp.PayloadData);
                            HandleIncomingData(tcp.PayloadData);
                        }


                        //manipulate TCP parameters
                        /*
                        tcp.SourcePort = 9999;
                        tcp.DestinationPort = 8888;
                        tcp.Syn = !tcp.Syn;
                        tcp.Fin = !tcp.Fin;
                        tcp.Ack = !tcp.Ack;
                        tcp.WindowSize = 500;
                        tcp.AcknowledgmentNumber = 800;
                        tcp.SequenceNumber = 800;
                        */
                    }

                }

            }
        }

        private void HandleIncomingData(byte[] data)
        {
            if (testRichText.Text.Length > 100000)
                testRichText.Text = "";
            incomingDataHandled++;
            if (data.Length > 0)
            {
                testRichText.Text += Environment.NewLine + incomingDataHandled.ToString() + ": " + Utilities.GetCommandNameFromIndex(data[0]) + " " + Utilities.ByteArrayToString(data);
                ParseCommand(data);
            }
            
        }


      public void ParseCommand(byte[] command)
      {
        switch (command[0])
        { 
                 //case 0: DefaultFunction(command); break;
                 //case 1: DefaultFunction(command); break;
                 //case 2: DefaultFunction(command); break;
                 //case 3: DefaultFunction(command); break;
                 //case 4: DefaultFunction(command); break;
                 case 5: UserLeftGame(command); break;
                 case 6: ChatBoxMessage(command); break;
                 //case 7: DefaultFunction(command); break;
                 //case 8: DefaultFunction(command); break;
                 //case 9: DefaultFunction(command); break;
                 //case 10: DefaultFunction(command); break;
                 //case 11: DefaultFunction(command); break;
                 //case 12: DefaultFunction(command); break;
                 //case 13: DefaultFunction(command); break;
                 //case 14: DefaultFunction(command); break;
                 //case 15: DefaultFunction(command); break;
                 //case 16: DoNotSpam(command); break;
                 //case 17: DefaultFunction(command); break;
                 //case 18: SystemMessage(command); break;
                 case 19: StringTableMessage(command); break;
                 //case 20: DefaultFunction(command); break;
                 //case 21: DefaultFunction(command); break;
                 //case 22: DefaultFunction(command); break;
                 //case 23: DefaultFunction(command); break;
                 //case 24: DefaultFunction(command); break;
                 //case 25: DefaultFunction(command); break;
                 //case 26: FriendUpdate(command); break;
                 //case 27: DefaultFunction(command); break;
                 //case 28: DefaultFunction(command); break;
                 //case 29: DefaultFunction(command); break;
                 //case 30: DefaultFunction(command); break;
                 //case 31: DefaultFunction(command); break;
                 //case 32: DefaultFunction(command); break;
                 //case 33: DefaultFunction(command); break;
                 //case 34: DefaultFunction(command); break;
                 //case 35: DefaultFunction(command); break;
                 //case 36: DefaultFunction(command); break;
                 //case 37: DefaultFunction(command); break;
                 //case 38: DefaultFunction(command); break;
                 case 39: ForcedLogout(command); break;
                 case 40: ReturnToHomePage(command); break;
                 //case 41: DefaultFunction(command); break;
                 //case 42: ShopPurchaseSuccess(command); break;
                 //case 43: DefaultFunction(command); break;
                 //case 44: DefaultFunction(command); break;
                 //case 45: DefaultFunction(command); break;
                 //case 46: DefaultFunction(command); break;
                 //case 47: DefaultFunction(command); break;
                 //case 48: UpdatePaidCurrency(command); break;
                 //case 49: DefaultFunction(command); break;
                 //case 50: DefaultFunction(command); break;
                 //case 51: SetLastBonusWinTime(command); break;
                 //case 52: DefaultFunction(command); break;
                 //case 53: DefaultFunction(command); break;
                 //case 54: DefaultFunction(command); break;
                 //case 55: DefaultFunction(command); break;
                 //case 56: DefaultFunction(command); break;
                 //case 57: DefaultFunction(command); break;
                 //case 58: DefaultFunction(command); break;
                 //case 59: DefaultFunction(command); break;
                 //case 60: DefaultFunction(command); break;
                 //case 61: DefaultFunction(command); break;
                 //case 62: DefaultFunction(command); break;
                 //case 63: DefaultFunction(command); break;
                 //case 64: DefaultFunction(command); break;
                 //case 65: DefaultFunction(command); break;
                 //case 66: UpdateFriendName(command); break;
                 //case 67: DefaultFunction(command); break;
                 //case 68: DefaultFunction(command); break;
                 //case 69: DefaultFunction(command); break;
                 //case 70: DefaultFunction(command); break;
                 //case 71: DefaultFunction(command); break;
                 //case 72: DefaultFunction(command); break;
                 //case 73: DefaultFunction(command); break;
                 //case 74: UserStatistics(command); break;
                 //case 75: DefaultFunction(command); break;
                 //case 76: DefaultFunction(command); break;
                 //case 77: ModeratorMessage(command); break;
                 //case 78: ReferAFriendUpdate(command); break;
                 //case 79: PlayerStatistics(command); break;
                 //case 80: ScrollConsumed(command); break;
                 //case 81: DefaultFunction(command); break;
                 //case 82: DefaultFunction(command); break;
                 //case 83: PromotionPopup(command); break;
                 //case 84: DefaultFunction(command); break;
                 //case 85: DefaultFunction(command); break;
                 //case 86: DefaultFunction(command); break;
                 //case 87: DefaultFunction(command); break;
                 //case 88: CurrencyMultiplier(command); break;
                 //case 89: DefaultFunction(command); break;


                 case 90: PickNames(command); break;
                 case 91: NamesAndPositionsOfUsers(command); break;
                 case 92: RoleAndPosition(command); break;
                 case 93: StartNight(command); break;
                 case 94: StartDay(command); break;
                 case 95: WhoDiedAndHow(command); break;
                 case 96: StartDiscussion(command); break;
                 case 97: StartVoting(command); break;
                 //case 98: StartDefenseTransition(command); break;
                 //case 99: StartJudgement(command); break;
                 //case 100: TrialFoundGuilty(command); break;
                 //case 101: TrialFoundNotGuilty(command); break;
                 //case 102: LookoutNightAbilityMessage(command); break;
                 //case 103: UserVoted(command); break;
                 //case 104: UserCanceledVote(command); break;
                 //case 105: UserChangedVote(command); break;
                 case 106: UserDied(command); break;
                 case 107: Resurrection(command); break;
                 case 108: TellRoleList(command); break;
                 case 109: UserChosenName(command); break;
                 case 110: OtherMafia(command); break;
                 //case 111: TellTownAmnesiacChangedRole(command); break;
                 //case 112: AmnesiacChangedRole(command); break;
                 case 113: BroughtBackToLife(command); break;
                 case 114: StartFirstDay(command); break;
                 case 115: BeingJailed(command); break;
                 //case 116: JailedTarget(command); break;
                 //case 117: UserJudgementVoted(command); break;
                 //case 118: UserChangedJudgementVote(command); break;
                 //case 119: UserCanceledJudgementVote(command); break;
                 //case 120: TellJudgementVotes(command); break;
                 //case 121: ExecutionerCompletedGoal(command); break;
                 //case 122: JesterCompletedGoal(command); break;
                 case 123: MayorRevealed(command); break;
                 //case 124: MayorRevealedAndAlreadyVoted(command); break;
                 //case 125: DisguiserStoleYourIdentity(command); break;
                 //case 126: DisguiserChangedIdentity(command); break;
                 //case 127: DisguiserChangedUpdateMafia(command); break;
                 //case 128: MediumIsTalkingToUs(command); break;
                 //case 129: MediumCommunicating(command); break;
                 case 130: TellLastWill(command); break;
                 case 131: HowManyAbilitiesLeft(command); break;
                 //case 132: MafiaTargeting(command); break;
                 //case 133: TellJanitorTargetsRole(command); break;
                 //case 134: TellJanitorTargetsWill(command); break;
                 //case 135: SomeoneHasWon(command); break;
                 //case 136: MafiosoPromotedToGodfather(command); break;
                 //case 137: MafiosoPromotedToGodfatherUpdateMafia(command); break;
                 //case 138: MafiaPromotedToMafioso(command); break;
                 //case 139: TellMafiaAboutMafiosoPromotion(command); break;
                 //case 140: ExecutionerConvertedToJester(command); break;
                 //case 141: AmnesiacBecameMafiaOrWitch(command); break;
                 //case 142: UserDisconnected(command); break;
                 //case 143: MafiaWasJailed(command); break;
                 //case 144: InvalidNameMessage(command); break;
                 case 145: StartNightTransition(command); break;
                 case 146: StartDayTransition(command); break;
                 //case 147: LynchUser(command); break;
                 //case 148: DeathNote(command); break;
                 //case 149: DefaultFunction(command); break;
                 //case 150: HousesChosen(command); break;
                 //case 151: FirstDayTransition(command); break;
                 //case 152: DefaultFunction(command); break;
                 //case 153: CharactersChosen(command); break;
                 //case 154: ResurrectionSetAlive(command); break;
                 //case 155: StartDefense(command); break;
                 //case 156: DefaultFunction(command); break;
                 //case 157: UserLeftDuringSelection(command); break;
                 //case 158: VigilanteKilledTown(command); break;
                 //case 159: NotifyUsersOfPrivateMessage(command); break;
                 //case 160: PrivateMessage(command); break;
                 //case 161: EarnedAchievements(command); break;
                 //case 162: DefaultFunction(command); break;
                 //case 163: SpyNightAbilityMessage(command); break;
                 //case 164: OneDayBeforeStalemate(command); break;
                 //case 165: PetsChosen(command); break;
                 //case 166: FacebookShareAchievement(command); break;
                 //case 167: FacebookShareWin(command); break;
                 //case 168: DeathAnimationsChosen(command); break;
                 //case 169: FullMoonNight(command); break;
                 //case 170: Identify(command); break;
                 case 171: EndGameInfo(command); break;
                 case 172: EndGameChatMessage(command); break;
                 case 173: EndGameUserUpdate(command); break;
                 case 174: DefaultFunction(command); break;
                 case 175: RoleLotsInfoMesssage(command); break;
                 //case 176: PayPalShowApprovalPage(command); break;
                 //case 177: DefaultFunction(command); break;
                 //case 178: DefaultFunction(command); break;
                 //case 179: DefaultFunction(command); break;
                 //case 180: VampirePromotion(command); break;
                 //case 181: OtherVampires(command); break;
                 //case 182: AddVampire(command); break;
                 //case 183: CanVampiresConvert(command); break;
                 //case 184: VampireDied(command); break;
                 //case 185: VampireHunterPromoted(command); break;
                 //case 186: VampireVisitedMessage(command); break;
                 //case 186: DefaultFunction(command); break;
                 //case 187: DefaultFunction(command); break;
                 //case 188: DefaultFunction(command); break;
                 //case 189: DefaultFunction(command); break;
                 //case 190: DefaultFunction(command); break;
                 //case 191: DefaultFunction(command); break;
                 //case 192: TransporterNotification(command); break;
                 //case 193: DefaultFunction(command); break;
                 //case 194: UpdateFreeCurrency(command); break;
                 //case 195: ActiveEvents(command); break;
                 //case 196: DefaultFunction(command); break;
                 //case 197: TauntResult(command); break;
                 //case 198: TauntActivated(command); break;
                 //case 199: TauntConsumed(command); break;
                 //case 200: TrackerNightAbility(command); break;
                 //case 201: AmbusherNightAbility(command); break;
                 //case 202: GuardianAngelProtection(command); break;
                 //case 203: PirateDuel(command); break;
                 //case 204: DuelTarget(command); break;
                 //case 205: PotionMasterPotions(command); break;
                 //case 206: HasNecronomicon(command); break;
                 //case 207: OtherWitches(command); break;
                 //case 208: PsychicNightAbility(command); break;
                 //case 209: TrapperNightAbility(command); break;
                 //case 210: TrapperTrapStatus(command); break;
                 //case 211: PestilenceConversion(command); break;
                 //case 212: JuggernautKillCount(command); break;
                 //case 213: CovenGotNecronomicon(command); break;
                 //case 214: GuardianAngelPromoted(command); break;
                 //case 215: VIPTarget(command); break;
                 //case 216: PirateDuelOutcome(command); break;
                 //case 217: DefaultFunction(command); break;
                 //case 218: DefaultFunction(command); break;
                 //case 219: AccountFlags(command); break;
                 //case 220: ZombieRotted(command); break;
                 //case 221: LoverTarget(command); break;
                 //case 222: PlagueSpread(command); break;
                 //case 223: RivalTarget(command); break;
                 //case 224: RankedInfo(command); break;
                 //case 225: JailorDeathNote(command); break;
                 //case 226: DefaultFunction(command); break;
                 //case 227: SpyNightInfo(command); break;
                default: UnhandledCommand(command); break;
        }
    }

        private void ChatBoxMessage(byte[] command)
        {
            int player = command[1];
            string Chat = System.Text.Encoding.UTF8.GetString(Utilities.RemoveStartingBytes(2, command));
            AddChat(player, Chat);
        }

        private void RoleLotsInfoMesssage(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void EndGameUserUpdate(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void EndGameChatMessage(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void EndGameInfo(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartDayTransition(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartNightTransition(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void HowManyAbilitiesLeft(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void TellLastWill(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void MayorRevealed(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void BeingJailed(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartFirstDay(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void BroughtBackToLife(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void OtherMafia(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void UserChosenName(byte[] command)
        {
            //throw new NotImplementedException();
            if (command[1] == 0x52)
            {
                //name
                //byte[] nameBytes = new byte[command.Length - 2];
                //Array.Copy(command, command.Length + 2, nameBytes, 0, nameBytes.Length);
                var nameBytes = Utilities.RemoveStartingBytes(3, command);
                string name = System.Text.Encoding.UTF8.GetString(nameBytes);
                int nameIndex = command[2];
                lastNameUp = name;
                AddName(name, nameIndex);
                testRichText.Text += Environment.NewLine + name + " has joined.";
            }
        }

        private void TellRoleList(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void Resurrection(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void UserDied(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartVoting(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartDiscussion(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void WhoDiedAndHow(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartDay(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StartNight(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void RoleAndPosition(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void NamesAndPositionsOfUsers(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void StringTableMessage(byte[] command)
        {
            var trimmedId = Utilities.RemoveStartingBytes(1, command);
            //var entireStringid = Encoding.UTF8.GetString(trimmedId);

            //Array.Resize(ref trimmedId, 1);
            if (command.Length > 3 && command[2] == 01)
            {
                mainTextRichText.Text += "Team specific night action?" + Environment.NewLine;
            }
            else
            {
                var result = GetActionString(Convert.ToInt32(command[1] - 1).ToString());
                mainTextRichText.Text += result + Environment.NewLine;
            }

            

            

            //throw new NotImplementedException();
        }

        private void UserLeftGame(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void PickNames(byte[] command)
        {
            FoundNextGame();
            //throw new NotImplementedException();
        }




        private void ReturnToHomePage(byte[] command)
        {
            //throw new NotImplementedException();
        }

        private void ForcedLogout(byte[] command)
        {
            //throw new NotImplementedException();
        }


        private void UnhandledCommand(byte[] command)
        {
            Console.WriteLine("Unhandled command: " + command[0] + " " + Utilities.GetCommandNameFromIndex(command[0]));
        }

        private void DefaultFunction(byte[] command)
        {
            //throw new NotImplementedException();
            Console.WriteLine("DefaultFunction: " + command[0]);
        }

        private string GetActionString(string id)
        {
            try
            {
                return stringTable.Where(e => e.id == id).FirstOrDefault().Text;
            }
            catch (Exception e)
            {
                return "Unknown Action";
            }

        }

        private void AddName(string name, int index)
        {
            name = name.Trim('\0');
            names[index - 1] = name;

            UpdateNames();
        }
        private void UpdateNames()
        {
            AllNamesList.Items.Clear();

            nameActionCombo.Items.Clear();
            for (int i = 0; i < 15; i++)
            {
                if (names[i] != null)
                {
                    AllNamesList.Items.Add((i + 1).ToString() + ") " + names[i]);
                    nameActionCombo.Items.Add((i + 1) + ") " + names[i]);
                }
                else
                {
                    AllNamesList.Items.Add("-");
                    nameActionCombo.Items.Add("-");
                }
            }
        }

        private void AddChat(int player, string chat)
        {
            chat = chat.Trim('\0');
            player = player - 1;
            chatlog.Add(new ChatItem(chat, player));

            string playerName = player.ToString();
            if (player < 15 && player > 0)
            {
                playerName = names[player];

                AddToChat("(" + (player + 1) + ") " + playerName + ": " + chat);
            }
            else
            {
                mainTextRichText.Text += "(?): " + chat + Environment.NewLine;
            }
        }
        private void AddToChat(string message)
        {
            message = message.Trim('\0');
            mainTextRichText.Text += message + Environment.NewLine;
        }
        private void FoundNextGame()
        {
            names = new string[names.Length];
            mainTextRichText.Text += "----NEXT GAME----" + Environment.NewLine;           
        }

        private void forceNightActionButton_Click(object sender, EventArgs e)
        {
            List<byte> toSend = new List<byte>();
            toSend.Add(Convert.ToByte(11));
            toSend.Add(Convert.ToByte(nameActionCombo.SelectedIndex + 1));
            toSend.Add(Convert.ToByte(0));


            SendData(toSend.ToArray());
        }

        private void sendChatButton_Click(object sender, EventArgs e)
        {
            var messageBytes = System.Text.Encoding.UTF8.GetBytes(Convert.ToChar(3) + sendMessageText.Text + Convert.ToChar(0));

            SendData(messageBytes);
        }

        private void SendData(byte[] data)
        {
            try
            {
                var eth = ((PacketDotNet.EthernetPacket)lastSentPacket);
                var ip = (PacketDotNet.IPPacket)lastSentPacket.Extract(typeof(PacketDotNet.IPPacket));

                var tcp = (PacketDotNet.TcpPacket)lastSentPacket.Extract(typeof(PacketDotNet.TcpPacket));


                var ethernetPacket = new PacketDotNet.EthernetPacket(eth.SourceHwAddress, eth.DestinationHwAddress, eth.Type);
                ethernetPacket.PayloadPacket = ip;
                //ethernetPacket.PayloadPacket.PayloadPacket =
                //var tcpPacket = new TcpPacket(tcp.SourcePort, tcp.DestinationPort);

                ethernetPacket.PayloadPacket.PayloadPacket.PayloadData = data;
                //(eth.PayloadPacket.PayloadPacket as PacketDotNet.TcpPacket).AcknowledgmentNumber++;
                (ethernetPacket.PayloadPacket.PayloadPacket as PacketDotNet.TcpPacket).Ack = false;
                (ethernetPacket.PayloadPacket.PayloadPacket as PacketDotNet.TcpPacket).UpdateCalculatedValues();
                (ethernetPacket.PayloadPacket.PayloadPacket as PacketDotNet.TcpPacket).UpdateTCPChecksum();
                (ethernetPacket.PayloadPacket.PayloadPacket as PacketDotNet.TcpPacket).UpdateCalculatedValues();
                (ethernetPacket.PayloadPacket.PayloadPacket as PacketDotNet.TcpPacket).UpdateTCPChecksum();
                //ethernetPacket.PayloadPacket = tcpPacket;
                //tcpPacket.PayloadData = data;
                //tcpPacket.UpdateCalculatedValues();
                //tcpPacket.CalculateTCPChecksum();


                device.SendPacket(eth);

            }
            catch(Exception e)
            {
                Console.WriteLine("Couldent send data: " + e.ToString());
            }
        }

        private void voteForButton_Click(object sender, EventArgs e)
        {
            List<byte> toSend = new List<byte>();
            toSend.Add(Convert.ToByte(10));
            toSend.Add(Convert.ToByte(nameActionCombo.SelectedIndex + 1));
            toSend.Add(Convert.ToByte(0));

            SendData(toSend.ToArray());
        }
    }
}
