using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TosAssist
{
    class Utilities
    {
        public static string GetCommandNameFromIndex(int index)
        {
            switch (index)
            {
                case 0: return "DefaultFunction";
                case 1: return "DefaultFunction";
                case 2: return "DefaultFunction";
                case 3: return "DefaultFunction";
                case 4: return "DefaultFunction";
                case 5: return "UserLeftGame";
                case 6: return "ChatBoxMessage";
                case 7: return "DefaultFunction";
                case 8: return "DefaultFunction";
                case 9: return "DefaultFunction";
                case 10: return "DefaultFunction";
                case 11: return "DefaultFunction";
                case 12: return "DefaultFunction";
                case 13: return "DefaultFunction";
                case 14: return "DefaultFunction";
                case 15: return "DefaultFunction";
                case 16: return "DoNotSpam";
                case 17: return "DefaultFunction";
                case 18: return "SystemMessage";
                case 19: return "StringTableMessage";
                case 20: return "DefaultFunction";
                case 21: return "DefaultFunction";
                case 22: return "DefaultFunction";
                case 23: return "DefaultFunction";
                case 24: return "DefaultFunction";
                case 25: return "DefaultFunction";
                case 26: return "FriendUpdate";
                case 27: return "DefaultFunction";
                case 28: return "DefaultFunction";
                case 29: return "DefaultFunction";
                case 30: return "DefaultFunction";
                case 31: return "DefaultFunction";
                case 32: return "DefaultFunction";
                case 33: return "DefaultFunction";
                case 34: return "DefaultFunction";
                case 35: return "DefaultFunction";
                case 36: return "DefaultFunction";
                case 37: return "DefaultFunction";
                case 38: return "DefaultFunction";
                case 39: return "ForcedLogout";
                case 40: return "ReturnToHomePage";
                case 41: return "DefaultFunction";
                case 42: return "ShopPurchaseSuccess";
                case 43: return "DefaultFunction";
                case 44: return "DefaultFunction";
                case 45: return "DefaultFunction";
                case 46: return "DefaultFunction";
                case 47: return "DefaultFunction";
                case 48: return "UpdatePaidCurrency";
                case 49: return "DefaultFunction";
                case 50: return "DefaultFunction";
                case 51: return "SetLastBonusWinTime";
                case 52: return "DefaultFunction";
                case 53: return "DefaultFunction";
                case 54: return "DefaultFunction";
                case 55: return "DefaultFunction";
                case 56: return "DefaultFunction";
                case 57: return "DefaultFunction";
                case 58: return "DefaultFunction";
                case 59: return "DefaultFunction";
                case 60: return "DefaultFunction";
                case 61: return "DefaultFunction";
                case 62: return "DefaultFunction";
                case 63: return "DefaultFunction";
                case 64: return "DefaultFunction";
                case 65: return "DefaultFunction";
                case 66: return "UpdateFriendName";
                case 67: return "DefaultFunction";
                case 68: return "DefaultFunction";
                case 69: return "DefaultFunction";
                case 70: return "DefaultFunction";
                case 71: return "DefaultFunction";
                case 72: return "DefaultFunction";
                case 73: return "DefaultFunction";
                case 74: return "UserStatistics";
                case 75: return "DefaultFunction";
                case 76: return "DefaultFunction";
                case 77: return "ModeratorMessage";
                case 78: return "ReferAFriendUpdate";
                case 79: return "PlayerStatistics";
                case 80: return "ScrollConsumed";
                case 81: return "DefaultFunction";
                case 82: return "DefaultFunction";
                case 83: return "PromotionPopup";
                case 84: return "DefaultFunction";
                case 85: return "DefaultFunction";
                case 86: return "DefaultFunction";
                case 87: return "DefaultFunction";
                case 88: return "CurrencyMultiplier";
                case 89: return "DefaultFunction";
                case 90: return "PickNames";
                case 91: return "NamesAndPositionsOfUsers";
                case 92: return "RoleAndPosition";
                case 93: return "StartNight";
                case 94: return "StartDay";
                case 95: return "WhoDiedAndHow";
                case 96: return "StartDiscussion";
                case 97: return "StartVoting";
                case 98: return "StartDefenseTransition";
                case 99: return "StartJudgement";
                case 100: return "TrialFoundGuilty";
                case 101: return "TrialFoundNotGuilty";
                case 102: return "LookoutNightAbilityMessage";
                case 103: return "UserVoted";
                case 104: return "UserCanceledVote";
                case 105: return "UserChangedVote";
                case 106: return "UserDied";
                case 107: return "Resurrection";
                case 108: return "TellRoleList";
                case 109: return "UserChosenName";
                case 110: return "OtherMafia";
                case 111: return "TellTownAmnesiacChangedRole";
                case 112: return "AmnesiacChangedRole";
                case 113: return "BroughtBackToLife";
                case 114: return "StartFirstDay";
                case 115: return "BeingJailed";
                case 116: return "JailedTarget";
                case 117: return "UserJudgementVoted";
                case 118: return "UserChangedJudgementVote";
                case 119: return "UserCanceledJudgementVote";
                case 120: return "TellJudgementVotes";
                case 121: return "ExecutionerCompletedGoal";
                case 122: return "JesterCompletedGoal";
                case 123: return "MayorRevealed";
                case 124: return "MayorRevealedAndAlreadyVoted";
                case 125: return "DisguiserStoleYourIdentity";
                case 126: return "DisguiserChangedIdentity";
                case 127: return "DisguiserChangedUpdateMafia";
                case 128: return "MediumIsTalkingToUs";
                case 129: return "MediumCommunicating";
                case 130: return "TellLastWill";
                case 131: return "HowManyAbilitiesLeft";
                case 132: return "MafiaTargeting";
                case 133: return "TellJanitorTargetsRole";
                case 134: return "TellJanitorTargetsWill";
                case 135: return "SomeoneHasWon";
                case 136: return "MafiosoPromotedToGodfather";
                case 137: return "MafiosoPromotedToGodfatherUpdateMafia";
                case 138: return "MafiaPromotedToMafioso";
                case 139: return "TellMafiaAboutMafiosoPromotion";
                case 140: return "ExecutionerConvertedToJester";
                case 141: return "AmnesiacBecameMafiaOrWitch";
                case 142: return "UserDisconnected";
                case 143: return "MafiaWasJailed";
                case 144: return "InvalidNameMessage";
                case 145: return "StartNightTransition";
                case 146: return "StartDayTransition";
                case 147: return "LynchUser";
                case 148: return "DeathNote";
                case 149: return "DefaultFunction";
                case 150: return "HousesChosen";
                case 151: return "FirstDayTransition";
                case 152: return "DefaultFunction";
                case 153: return "CharactersChosen";
                case 154: return "ResurrectionSetAlive";
                case 155: return "StartDefense";
                case 156: return "DefaultFunction";
                case 157: return "UserLeftDuringSelection";
                case 158: return "VigilanteKilledTown";
                case 159: return "NotifyUsersOfPrivateMessage";
                case 160: return "PrivateMessage";
                case 161: return "EarnedAchievements";
                case 162: return "DefaultFunction";
                case 163: return "SpyNightAbilityMessage";
                case 164: return "OneDayBeforeStalemate";
                case 165: return "PetsChosen";
                case 166: return "FacebookShareAchievement";
                case 167: return "FacebookShareWin";
                case 168: return "DeathAnimationsChosen";
                case 169: return "FullMoonNight";
                case 170: return "Identify";
                case 171: return "EndGameInfo";
                case 172: return "EndGameChatMessage";
                case 173: return "EndGameUserUpdate";
                case 174: return "DefaultFunction";
                case 175: return "RoleLotsInfoMesssage";
                case 176: return "PayPalShowApprovalPage";
                case 177: return "DefaultFunction";
                case 178: return "DefaultFunction";
                case 179: return "DefaultFunction";
                case 180: return "VampirePromotion";
                case 181: return "OtherVampires";
                case 182: return "AddVampire";
                case 183: return "CanVampiresConvert";
                case 184: return "VampireDied";
                case 185: return "VampireHunterPromoted";
                case 186: return "VampireVisitedMessage";
                case 187: return "DefaultFunction";
                case 188: return "DefaultFunction";
                case 189: return "DefaultFunction";
                case 190: return "DefaultFunction";
                case 191: return "DefaultFunction";
                case 192: return "TransporterNotification";
                case 193: return "DefaultFunction";
                case 194: return "UpdateFreeCurrency";
                case 195: return "ActiveEvents";
                case 196: return "DefaultFunction";
                case 197: return "TauntResult";
                case 198: return "TauntActivated";
                case 199: return "TauntConsumed";
                case 200: return "TrackerNightAbility";
                case 201: return "AmbusherNightAbility";
                case 202: return "GuardianAngelProtection";
                case 203: return "PirateDuel";
                case 204: return "DuelTarget";
                case 205: return "PotionMasterPotions";
                case 206: return "HasNecronomicon";
                case 207: return "OtherWitches";
                case 208: return "PsychicNightAbility";
                case 209: return "TrapperNightAbility";
                case 210: return "TrapperTrapStatus";
                case 211: return "PestilenceConversion";
                case 212: return "JuggernautKillCount";
                case 213: return "CovenGotNecronomicon";
                case 214: return "GuardianAngelPromoted";
                case 215: return "VIPTarget";
                case 216: return "PirateDuelOutcome";
                case 217: return "DefaultFunction";
                case 218: return "DefaultFunction";
                case 219: return "AccountFlags";
                case 220: return "ZombieRotted";
                case 221: return "LoverTarget";
                case 222: return "PlagueSpread";
                case 223: return "RivalTarget";
                case 224: return "RankedInfo";
                case 225: return "JailorDeathNote";
                case 226: return "DefaultFunction";
                case 227: return "SpyNightInfo";
                default: return "UNKNOWN";
            }

        }


        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2} ", b);
            return hex.ToString();
        }

        public static byte[] RemoveStartingBytes(int ammount, byte[] command)
        {
            byte[] newCommand = new byte[command.Length - ammount];
            Array.Copy(command, ammount, newCommand, 0, newCommand.Length);
            return newCommand;
        }


        public static byte[][] Separate(byte[] source, byte[] separator)
        {
            var Parts = new List<byte[]>();
            var Index = 0;
            byte[] Part;
            for (var I = 0; I < source.Length; ++I)
            {
                if (Equals(source, separator, I))
                {
                    Part = new byte[I - Index];
                    Array.Copy(source, Index, Part, 0, Part.Length);
                    Parts.Add(Part);
                    Index = I + separator.Length;
                    I += separator.Length - 1;
                }
            }
            Part = new byte[source.Length - Index];
            Array.Copy(source, Index, Part, 0, Part.Length);
            Parts.Add(Part);
            return Parts.ToArray();
        }

        public static bool Equals(byte[] source, byte[] separator, int index)
        {
            for (int i = 0; i < separator.Length; ++i)
                if (index + i >= source.Length || source[index + i] != separator[i])
                    return false;
            return true;
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }


    }

    [Serializable, XmlRoot("Entries")]
    public class Entry
    {
        public string id;
        public string Text;
        public string Color;
    }

    [Serializable]
    public class ChatItem
    {
        public string text;
        public int number;

        public ChatItem(string Text, int Number)
        {
            text = Text;
            number = Number;
        }

    }

}
