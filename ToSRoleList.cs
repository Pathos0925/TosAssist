using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TosAssist
{
    class ToSRoleList
    {
        public static ToSRoleList instance;

        public string[] m_roleIdToNameMap = new string[202];
        public string[] m_roleIdToColorMap = new string[202];

        public int[][] m_bucketToListMap = new int[76][];

        //public static string COLOR_Town = "#7FFF00";      
        public static string COLOR_Town = "#008000";

            public static string COLOR_Mafia = "#DD0000";      
          public static string COLOR_Coven = "#BF5FFF";      
          public static string COLOR_Neutral = "#CCCCCC";      
          public static string COLOR_Random = "#1D7CF2";      
          public static string COLOR_Any = "#FFFFFF";

        public ToSRoleList()
        {
            instance = this;
            for (int i = 0; i < 201;i++)
            {
                m_roleIdToNameMap[i] = "unknown";
                m_roleIdToColorMap[i] = "#000000";
            }

            m_roleIdToNameMap[0] = "Bodyguard";
            m_roleIdToNameMap[1] = "Doctor";
            m_roleIdToNameMap[2] = "Escort";
            m_roleIdToNameMap[3] = "Investigator";
            m_roleIdToNameMap[4] = "Jailor";
            m_roleIdToNameMap[5] = "Lookout";
            m_roleIdToNameMap[6] = "Mayor";
            m_roleIdToNameMap[7] = "Medium";
            m_roleIdToNameMap[8] = "Retributionist";
            m_roleIdToNameMap[9] = "Sheriff";
            m_roleIdToNameMap[10] = "Spy";
            m_roleIdToNameMap[11] = "Transporter";
            m_roleIdToNameMap[12] = "Vampire Hunter";
            m_roleIdToNameMap[13] = "Veteran";
            m_roleIdToNameMap[14] = "Vigilante";
            m_roleIdToNameMap[15] = "Blackmailer";
            m_roleIdToNameMap[16] = "Consigliere";
            m_roleIdToNameMap[17] = "Consort";
            m_roleIdToNameMap[18] = "Disguiser";
            m_roleIdToNameMap[19] = "Forger";
            m_roleIdToNameMap[20] = "Framer";
            m_roleIdToNameMap[21] = "Godfather";
            m_roleIdToNameMap[22] = "Janitor";
            m_roleIdToNameMap[23] = "Mafioso";
            m_roleIdToNameMap[24] = "Amnesiac";
            m_roleIdToNameMap[25] = "Arsonist";
            m_roleIdToNameMap[26] = "Executioner";
            m_roleIdToNameMap[27] = "Jester";
            m_roleIdToNameMap[28] = "Serial Killer";
            m_roleIdToNameMap[29] = "Survivor";
            m_roleIdToNameMap[30] = "Vampire";
            m_roleIdToNameMap[31] = "Werewolf";
            m_roleIdToNameMap[32] = "Witch";
            m_roleIdToNameMap[33] = "Random Town";
            m_roleIdToNameMap[34] = "Town Investigative";
            m_roleIdToNameMap[35] = "Town Protective";
            m_roleIdToNameMap[36] = "Town Killing";
            m_roleIdToNameMap[37] = "Town Support";
            m_roleIdToNameMap[38] = "Random Mafia";
            m_roleIdToNameMap[39] = "Mafia Support";
            m_roleIdToNameMap[40] = "Mafia Deception";
            m_roleIdToNameMap[41] = "Random Neutral";
            m_roleIdToNameMap[42] = "Neutral Benign";
            m_roleIdToNameMap[43] = "Neutral Evil";
            m_roleIdToNameMap[44] = "Neutral Killing";
            m_roleIdToNameMap[45] = "Any";
            m_roleIdToNameMap[46] = "Crusader";
            m_roleIdToNameMap[47] = "Tracker";
            m_roleIdToNameMap[48] = "Trapper";
            m_roleIdToNameMap[49] = "Psychic";
            m_roleIdToNameMap[50] = "Hypnotist";
            m_roleIdToNameMap[51] = "Ambusher";
            m_roleIdToNameMap[52] = "Plaguebearer";
            m_roleIdToNameMap[53] = "Juggernaut";
            m_roleIdToNameMap[54] = "Guardian Angel";
            m_roleIdToNameMap[55] = "Pirate";
            m_roleIdToNameMap[56] = "Coven Leader";
            m_roleIdToNameMap[57] = "Potion Master";
            m_roleIdToNameMap[58] = "Hex Master";
            m_roleIdToNameMap[59] = "Necromancer";
            m_roleIdToNameMap[60] = "Poisoner";
            m_roleIdToNameMap[61] = "Medusa";
            m_roleIdToNameMap[100] = "Pestilence";
            m_roleIdToNameMap[101] = "Ghoul";
            m_roleIdToNameMap[63] = "Random Town";
            m_roleIdToNameMap[64] = "Town Investigative";
            m_roleIdToNameMap[65] = "Town Protective";
            m_roleIdToNameMap[66] = "Town Killing";
            m_roleIdToNameMap[67] = "Town Support";
            m_roleIdToNameMap[68] = "Random Mafia";
            m_roleIdToNameMap[69] = "Mafia Support";
            m_roleIdToNameMap[70] = "Mafia Deception";
            m_roleIdToNameMap[71] = "Random Neutral";
            m_roleIdToNameMap[72] = "Neutral Benign";
            m_roleIdToNameMap[73] = "Neutral Evil";
            m_roleIdToNameMap[74] = "Neutral Killing";
            m_roleIdToNameMap[62] = "Random Witch";
            m_roleIdToNameMap[76] = "Neutral Chaos";
            m_roleIdToNameMap[75] = "Any";
            m_roleIdToNameMap[200] = "Cleaned";
            m_roleIdToNameMap[201] = "Stoned";


            m_bucketToListMap[33] = RANDOM_TOWN_LIST;
            m_bucketToListMap[63] = COVEN_RANDOM_TOWN_LIST;
            m_bucketToListMap[34] = TOWN_INVESTIGATIVE_LIST;
            m_bucketToListMap[64] = COVEN_TOWN_INVESTIGATIVE_LIST;
            m_bucketToListMap[35] = TOWN_PROTECTIVE_LIST;
            m_bucketToListMap[65] = COVEN_TOWN_PROTECTIVE_LIST;
            m_bucketToListMap[36] = TOWN_KILLING_LIST;
            m_bucketToListMap[66] = COVEN_TOWN_KILLING_LIST;
            m_bucketToListMap[37] = TOWN_SUPPORT_LIST;
            m_bucketToListMap[67] = COVEN_TOWN_SUPPORT_LIST;
            m_bucketToListMap[38] = RANDOM_MAFIA_LIST;
            m_bucketToListMap[68] = COVEN_RANDOM_MAFIA_LIST;
            m_bucketToListMap[39] = MAFIA_SUPPORT_LIST;
            m_bucketToListMap[69] = COVEN_MAFIA_SUPPORT_LIST;
            m_bucketToListMap[40] = MAFIA_DECEPTION_LIST;
            m_bucketToListMap[70] = COVEN_MAFIA_DECEPTION_LIST;
            m_bucketToListMap[41] = RANDOM_NEUTRAL_LIST;
            m_bucketToListMap[71] = COVEN_RANDOM_NEUTRAL_LIST;
            m_bucketToListMap[42] = NEUTRAL_BENIGN_LIST;
            m_bucketToListMap[72] = COVEN_NEUTRAL_BENIGN_LIST;
            m_bucketToListMap[43] = NEUTRAL_EVIL_LIST;
            m_bucketToListMap[73] = COVEN_NEUTRAL_EVIL_LIST;
            m_bucketToListMap[44] = NEUTRAL_KILLING_LIST;
            m_bucketToListMap[74] = COVEN_NEUTRAL_KILLING_LIST;
            m_bucketToListMap[62] = COVEN_RANDOM_COVEN_LIST;
            m_bucketToListMap[45] = CLASSIC_ROLES;
            m_bucketToListMap[75] = COVEN_ROLES;

            m_roleIdToColorMap[0] = COLOR_Town;
            m_roleIdToColorMap[1] = COLOR_Town;
            m_roleIdToColorMap[2] = COLOR_Town;
            m_roleIdToColorMap[3] = COLOR_Town;
            m_roleIdToColorMap[4] = COLOR_Town;
            m_roleIdToColorMap[5] = COLOR_Town;
            m_roleIdToColorMap[6] = COLOR_Town;
            m_roleIdToColorMap[7] = COLOR_Town;
            m_roleIdToColorMap[8] = COLOR_Town;
            m_roleIdToColorMap[9] = COLOR_Town;
            m_roleIdToColorMap[10] = COLOR_Town;
            m_roleIdToColorMap[11] = COLOR_Town;
            m_roleIdToColorMap[12] = COLOR_Town;
            m_roleIdToColorMap[13] = COLOR_Town;
            m_roleIdToColorMap[14] = COLOR_Town;
            m_roleIdToColorMap[15] = COLOR_Mafia;
            m_roleIdToColorMap[16] = COLOR_Mafia;
            m_roleIdToColorMap[17] = COLOR_Mafia;
            m_roleIdToColorMap[18] = COLOR_Mafia;
            m_roleIdToColorMap[19] = COLOR_Mafia;
            m_roleIdToColorMap[20] = COLOR_Mafia;
            m_roleIdToColorMap[21] = COLOR_Mafia;
            m_roleIdToColorMap[22] = COLOR_Mafia;
            m_roleIdToColorMap[23] = COLOR_Mafia;
            m_roleIdToColorMap[24] = "#22FFFF";
            m_roleIdToColorMap[25] = "#EE7600";
            m_roleIdToColorMap[26] = "#CCCCCC";
            m_roleIdToColorMap[27] = "#F7B3DA";
            m_roleIdToColorMap[28] = "#000080";
            m_roleIdToColorMap[29] = "#DDDD00";
            m_roleIdToColorMap[30] = "#7B8968";
            m_roleIdToColorMap[31] = "#9F703A";
            m_roleIdToColorMap[32] = COLOR_Coven;
            m_roleIdToColorMap[46] = COLOR_Town;
            m_roleIdToColorMap[47] = COLOR_Town;
            m_roleIdToColorMap[48] = COLOR_Town;
            m_roleIdToColorMap[49] = COLOR_Town;
            m_roleIdToColorMap[50] = COLOR_Mafia;
            m_roleIdToColorMap[51] = COLOR_Mafia;
            m_roleIdToColorMap[52] = "#Cfff63";
            m_roleIdToColorMap[100] = "#424242";
            m_roleIdToColorMap[53] = "#631A35";
            m_roleIdToColorMap[54] = "#FFFFFF";
            m_roleIdToColorMap[55] = "#EDC240";
            m_roleIdToColorMap[56] = COLOR_Coven;
            m_roleIdToColorMap[57] = COLOR_Coven;
            m_roleIdToColorMap[58] = COLOR_Coven;
            m_roleIdToColorMap[59] = COLOR_Coven;
            m_roleIdToColorMap[60] = COLOR_Coven;
            m_roleIdToColorMap[61] = COLOR_Coven;
            m_roleIdToColorMap[200] = "#FFFFFF";
            m_roleIdToColorMap[201] = "#CCCCCC";
        }

        public int[] getConfirmedFromRole(int role)
        {
            return m_bucketToListMap[role];
        }


      public static int[] RANDOM_TOWN_LIST = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14};
      
      public static int[] COVEN_RANDOM_TOWN_LIST = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 46, 48, 47, 49 };
      
      public static int[] TOWN_INVESTIGATIVE_LIST = new int[] { 3,9,5,10};
      
      public static int[] COVEN_TOWN_INVESTIGATIVE_LIST = new int[] { 3,9,5,10,47,49};
      
      public static int[] TOWN_PROTECTIVE_LIST = new int[] { 0,1};
      
      public static int[] COVEN_TOWN_PROTECTIVE_LIST = new int[] { 0,1,46,48};
      
      public static int[] TOWN_KILLING_LIST = new int[] { 4,12,13,14};
      
      public static int[] COVEN_TOWN_KILLING_LIST = new int[] { 4,12,13,14};
      
      public static int[] TOWN_SUPPORT_LIST = new int[] { 2,6,7,8,11};
      
      public static int[] COVEN_TOWN_SUPPORT_LIST = new int[] { 2,6,7,8,11};
      
      public static int[] RANDOM_MAFIA_LIST = new int[] { 15,16,17,18,19,20,21,22,23};
      
      public static int[] COVEN_RANDOM_MAFIA_LIST = new int[] { 15,16,17,18,19,20,21,22,23,50,51};
      
      public static int[] MAFIA_SUPPORT_LIST = new int[] { 16,17,15};
      
      public static int[] COVEN_MAFIA_SUPPORT_LIST = new int[] { 16,17,15};
      
      public static int[] MAFIA_DECEPTION_LIST = new int[] { 18,19,20,22};
      
      public static int[] COVEN_MAFIA_DECEPTION_LIST = new int[] { 18,19,20,22,50};
      
      public static int[] RANDOM_NEUTRAL_LIST = new int[] { 24,25,26,27,28,29,30,31,32};
      
      public static int[] COVEN_RANDOM_NEUTRAL_LIST = new int[] { 24,25,26,27,28,29,30,31,54};
      
      public static int[] NEUTRAL_BENIGN_LIST = new int[] { 24,29};
      
      public static int[] COVEN_NEUTRAL_BENIGN_LIST = new int[] { 24,29,54};
      
      public static int[] NEUTRAL_EVIL_LIST = new int[] { 26,27,32};
      
      public static int[] COVEN_NEUTRAL_EVIL_LIST = new int[] { 26,27};
      
      public static int[] NEUTRAL_KILLING_LIST = new int[] { 25,28,31};
      
      public static int[] COVEN_NEUTRAL_KILLING_LIST = new int[] { 25,28,31};
      
      public static int[] NEUTRAL_CHAOS_LIST = new int[] { 30};
      
      public static int[] COVEN_NEUTRAL_CHAOS_LIST = new int[] { 30,55,52};
      
      public static int[] COVEN_RANDOM_COVEN_LIST = new int[] { 56,57,58,59,60,61};


      private static int[] CLASSIC_ROLES = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32 };
      
      private static int[] COVEN_ROLES = new int[] { 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61 };
        
    }
}
