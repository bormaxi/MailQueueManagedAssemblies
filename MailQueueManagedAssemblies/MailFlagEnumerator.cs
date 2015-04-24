using System;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class MailFlagEnumerator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToString(MailFlag value)
        {
            switch (value)
            {
                case MailFlag.Answered:
                    return "mfAnswered";
                case MailFlag.Flagged:
                    return "mfFlagged";
                case MailFlag.Deleted:
                    return "mfDeleted";
                case MailFlag.Draft:
                    return "mfDraft";
                case MailFlag.Seen:
                    return "mfSeen";
                case MailFlag.Recent:
                    return "mfRecent";
                default:
                    throw new Exception("Unrecognized MailFlag enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MailFlag GetEnumerationValue(string value)
        {
            switch (value.ToLower())
            {
                case "mfanswered":
                case "answered":
                    return MailFlag.Answered;
                case "mfflagged":
                case "flagged":
                    return MailFlag.Flagged;
                case "mfdeleted":
                case "deleted":
                    return MailFlag.Deleted;
                case "mfdraft":
                case "draft":
                    return MailFlag.Draft;
                case "mfseen":
                case "seen":
                    return MailFlag.Seen;
                case "mfrecent":
                case "recent":
                    return MailFlag.Recent;
                default:
                    throw new Exception("Unrecognized MailFlag enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MailFlag GetEnumerationValue(int value)
        {
            switch (value)
            {
                case 1:
                    return MailFlag.Answered;
                case 2:
                    return MailFlag.Flagged;
                case 3:
                    return MailFlag.Deleted;
                case 4:
                    return MailFlag.Draft;
                case 5:
                    return MailFlag.Seen;
                case 6:
                    return MailFlag.Recent;
                default:
                    throw new Exception("Unrecognized MailFlag enumeration value");
            }
        }

    }

}
