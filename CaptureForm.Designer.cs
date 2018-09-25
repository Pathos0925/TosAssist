namespace TosAssist
{
    partial class CaptureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startStopToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.captureStatisticsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.packetInfoTextbox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Claims = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ConfirmedRole = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Dead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Confirmed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Notes_Lw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllNamesList = new System.Windows.Forms.ListBox();
            this.graveyardList = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.voteForButton = new System.Windows.Forms.Button();
            this.forceDayActionButton = new System.Windows.Forms.Button();
            this.forceNightActionButton = new System.Windows.Forms.Button();
            this.nameActionCombo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sendChatButton = new System.Windows.Forms.Button();
            this.sendMessageText = new System.Windows.Forms.TextBox();
            this.mainTextRichText = new System.Windows.Forms.RichTextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.testRichText = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.TCPStatusLogText = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ServerStatusLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clientStatusLabel = new System.Windows.Forms.Label();
            this.TCPStatusUpdater = new System.Windows.Forms.Timer(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.customCommand = new System.Windows.Forms.TextBox();
            this.sendCustomCommandButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startStopToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(781, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // startStopToolStripButton
            // 
            this.startStopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startStopToolStripButton.Image = global::TosAssist.Properties.Resources.stop_icon_disabled;
            this.startStopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startStopToolStripButton.Name = "startStopToolStripButton";
            this.startStopToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.startStopToolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureStatisticsToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(3, 465);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(781, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // captureStatisticsToolStripStatusLabel
            // 
            this.captureStatisticsToolStripStatusLabel.Name = "captureStatisticsToolStripStatusLabel";
            this.captureStatisticsToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(781, 236);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.SelectionChanged += new System.EventHandler(this.dataGridView_SelectionChanged);
            // 
            // packetInfoTextbox
            // 
            this.packetInfoTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packetInfoTextbox.Location = new System.Drawing.Point(0, 0);
            this.packetInfoTextbox.Name = "packetInfoTextbox";
            this.packetInfoTextbox.Size = new System.Drawing.Size(781, 191);
            this.packetInfoTextbox.TabIndex = 1;
            this.packetInfoTextbox.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 516);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.AllNamesList);
            this.tabPage3.Controls.Add(this.graveyardList);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(787, 490);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Main";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Role,
            this.Claims,
            this.ConfirmedRole,
            this.Dead,
            this.Confirmed,
            this.Notes_Lw});
            this.dataGridView1.Location = new System.Drawing.Point(134, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(645, 484);
            this.dataGridView1.TabIndex = 4;
            // 
            // Role
            // 
            this.Role.HeaderText = "Role";
            this.Role.Name = "Role";
            // 
            // Claims
            // 
            this.Claims.HeaderText = "Claims";
            this.Claims.Name = "Claims";
            // 
            // ConfirmedRole
            // 
            this.ConfirmedRole.HeaderText = "ConfirmedRole";
            this.ConfirmedRole.Name = "ConfirmedRole";
            // 
            // Dead
            // 
            this.Dead.HeaderText = "Dead";
            this.Dead.Name = "Dead";
            this.Dead.Width = 40;
            // 
            // Confirmed
            // 
            this.Confirmed.HeaderText = "Confirmed";
            this.Confirmed.Name = "Confirmed";
            this.Confirmed.Width = 60;
            // 
            // Notes_Lw
            // 
            this.Notes_Lw.HeaderText = "Notes / LW";
            this.Notes_Lw.Name = "Notes_Lw";
            this.Notes_Lw.Width = 200;
            // 
            // AllNamesList
            // 
            this.AllNamesList.FormattingEnabled = true;
            this.AllNamesList.Location = new System.Drawing.Point(8, 234);
            this.AllNamesList.Name = "AllNamesList";
            this.AllNamesList.Size = new System.Drawing.Size(120, 212);
            this.AllNamesList.TabIndex = 2;
            // 
            // graveyardList
            // 
            this.graveyardList.FormattingEnabled = true;
            this.graveyardList.Location = new System.Drawing.Point(8, 3);
            this.graveyardList.Name = "graveyardList";
            this.graveyardList.Size = new System.Drawing.Size(120, 225);
            this.graveyardList.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox5);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(787, 490);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Utilities";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.voteForButton);
            this.groupBox2.Controls.Add(this.forceDayActionButton);
            this.groupBox2.Controls.Add(this.forceNightActionButton);
            this.groupBox2.Controls.Add(this.nameActionCombo);
            this.groupBox2.Location = new System.Drawing.Point(14, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 101);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Force Action";
            // 
            // voteForButton
            // 
            this.voteForButton.Location = new System.Drawing.Point(6, 72);
            this.voteForButton.Name = "voteForButton";
            this.voteForButton.Size = new System.Drawing.Size(75, 23);
            this.voteForButton.TabIndex = 3;
            this.voteForButton.Text = "Vote For";
            this.voteForButton.UseVisualStyleBackColor = true;
            this.voteForButton.Click += new System.EventHandler(this.voteForButton_Click);
            // 
            // forceDayActionButton
            // 
            this.forceDayActionButton.Location = new System.Drawing.Point(87, 46);
            this.forceDayActionButton.Name = "forceDayActionButton";
            this.forceDayActionButton.Size = new System.Drawing.Size(75, 23);
            this.forceDayActionButton.TabIndex = 2;
            this.forceDayActionButton.Text = "Day";
            this.forceDayActionButton.UseVisualStyleBackColor = true;
            // 
            // forceNightActionButton
            // 
            this.forceNightActionButton.Location = new System.Drawing.Point(6, 46);
            this.forceNightActionButton.Name = "forceNightActionButton";
            this.forceNightActionButton.Size = new System.Drawing.Size(75, 23);
            this.forceNightActionButton.TabIndex = 1;
            this.forceNightActionButton.Text = "Night";
            this.forceNightActionButton.UseVisualStyleBackColor = true;
            this.forceNightActionButton.Click += new System.EventHandler(this.forceNightActionButton_Click);
            // 
            // nameActionCombo
            // 
            this.nameActionCombo.FormattingEnabled = true;
            this.nameActionCombo.Location = new System.Drawing.Point(6, 19);
            this.nameActionCombo.Name = "nameActionCombo";
            this.nameActionCombo.Size = new System.Drawing.Size(188, 21);
            this.nameActionCombo.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sendChatButton);
            this.groupBox1.Controls.Add(this.sendMessageText);
            this.groupBox1.Controls.Add(this.mainTextRichText);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 365);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // sendChatButton
            // 
            this.sendChatButton.Location = new System.Drawing.Point(487, 339);
            this.sendChatButton.Name = "sendChatButton";
            this.sendChatButton.Size = new System.Drawing.Size(63, 20);
            this.sendChatButton.TabIndex = 3;
            this.sendChatButton.Text = "Send";
            this.sendChatButton.UseVisualStyleBackColor = true;
            this.sendChatButton.Click += new System.EventHandler(this.sendChatButton_Click);
            // 
            // sendMessageText
            // 
            this.sendMessageText.Location = new System.Drawing.Point(6, 339);
            this.sendMessageText.Name = "sendMessageText";
            this.sendMessageText.Size = new System.Drawing.Size(475, 20);
            this.sendMessageText.TabIndex = 2;
            // 
            // mainTextRichText
            // 
            this.mainTextRichText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTextRichText.Location = new System.Drawing.Point(6, 19);
            this.mainTextRichText.Name = "mainTextRichText";
            this.mainTextRichText.Size = new System.Drawing.Size(544, 317);
            this.mainTextRichText.TabIndex = 1;
            this.mainTextRichText.Text = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.testRichText);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(787, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Events";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // testRichText
            // 
            this.testRichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testRichText.Location = new System.Drawing.Point(3, 3);
            this.testRichText.Name = "testRichText";
            this.testRichText.Size = new System.Drawing.Size(781, 484);
            this.testRichText.TabIndex = 0;
            this.testRichText.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.statusStrip1);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(787, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WinPCapRawPackets";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.packetInfoTextbox);
            this.splitContainer1.Size = new System.Drawing.Size(781, 484);
            this.splitContainer1.SplitterDistance = 264;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.TCPStatusLogText);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(787, 490);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "TCP";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // TCPStatusLogText
            // 
            this.TCPStatusLogText.Location = new System.Drawing.Point(8, 111);
            this.TCPStatusLogText.Name = "TCPStatusLogText";
            this.TCPStatusLogText.Size = new System.Drawing.Size(771, 371);
            this.TCPStatusLogText.TabIndex = 2;
            this.TCPStatusLogText.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ServerStatusLabel);
            this.groupBox4.Location = new System.Drawing.Point(8, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 48);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ServerStatus";
            // 
            // ServerStatusLabel
            // 
            this.ServerStatusLabel.Location = new System.Drawing.Point(6, 16);
            this.ServerStatusLabel.Name = "ServerStatusLabel";
            this.ServerStatusLabel.Size = new System.Drawing.Size(203, 21);
            this.ServerStatusLabel.TabIndex = 0;
            this.ServerStatusLabel.Text = "status";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clientStatusLabel);
            this.groupBox3.Location = new System.Drawing.Point(8, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 48);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ClientStatus";
            // 
            // clientStatusLabel
            // 
            this.clientStatusLabel.Location = new System.Drawing.Point(6, 16);
            this.clientStatusLabel.Name = "clientStatusLabel";
            this.clientStatusLabel.Size = new System.Drawing.Size(203, 21);
            this.clientStatusLabel.TabIndex = 0;
            this.clientStatusLabel.Text = "status";
            // 
            // TCPStatusUpdater
            // 
            this.TCPStatusUpdater.Enabled = true;
            this.TCPStatusUpdater.Interval = 1;
            this.TCPStatusUpdater.Tick += new System.EventHandler(this.TCPStatusUpdater_Tick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.sendCustomCommandButton);
            this.groupBox5.Controls.Add(this.customCommand);
            this.groupBox5.Location = new System.Drawing.Point(220, 382);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 93);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Send Custom Command";
            // 
            // customCommand
            // 
            this.customCommand.Location = new System.Drawing.Point(6, 19);
            this.customCommand.Name = "customCommand";
            this.customCommand.Size = new System.Drawing.Size(136, 20);
            this.customCommand.TabIndex = 0;
            // 
            // sendCustomCommandButton
            // 
            this.sendCustomCommandButton.Location = new System.Drawing.Point(148, 16);
            this.sendCustomCommandButton.Name = "sendCustomCommandButton";
            this.sendCustomCommandButton.Size = new System.Drawing.Size(46, 23);
            this.sendCustomCommandButton.TabIndex = 1;
            this.sendCustomCommandButton.Text = "button1";
            this.sendCustomCommandButton.UseVisualStyleBackColor = true;
            this.sendCustomCommandButton.Click += new System.EventHandler(this.sendCustomCommandButton_Click);
            // 
            // CaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 516);
            this.Controls.Add(this.tabControl1);
            this.Name = "CaptureForm";
            this.Text = "TosAssist";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CaptureForm_FormClosing);
            this.Load += new System.EventHandler(this.CaptureForm_Load);
            this.Shown += new System.EventHandler(this.CaptureForm_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton startStopToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel captureStatisticsToolStripStatusLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.RichTextBox packetInfoTextbox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox testRichText;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox mainTextRichText;
        private System.Windows.Forms.ListBox graveyardList;
        private System.Windows.Forms.ListBox AllNamesList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox sendMessageText;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button forceNightActionButton;
        private System.Windows.Forms.ComboBox nameActionCombo;
        private System.Windows.Forms.Button forceDayActionButton;
        private System.Windows.Forms.Button sendChatButton;
        private System.Windows.Forms.Button voteForButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role;
        private System.Windows.Forms.DataGridViewComboBoxColumn Claims;
        private System.Windows.Forms.DataGridViewComboBoxColumn ConfirmedRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Dead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Confirmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes_Lw;
        private System.Windows.Forms.Timer TCPStatusUpdater;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label clientStatusLabel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ServerStatusLabel;
        private System.Windows.Forms.RichTextBox TCPStatusLogText;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button sendCustomCommandButton;
        private System.Windows.Forms.TextBox customCommand;
    }
}