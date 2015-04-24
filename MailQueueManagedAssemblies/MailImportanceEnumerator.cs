using System;
using System.Collections.Generic;
using System.Text;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class MailImportanceEnumerator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToString(MailImportance value)
        {
            switch (value)
            {
                case MailImportance.Lowest:
                    return "mpLowest";
                case MailImportance.Low:
                    return "mpLow";
                case MailImportance.Normal:
                    return "mpNormal";
                case MailImportance.High:
                    return "mpHigh";
                case MailImportance.Highest:
                    return "mpHighest";
                default:
                    throw new Exception("Unrecognized MailImportance enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MailImportance GetEnumerationValue(string value)
        {
            switch (value.ToLower())
            {
                case "mplowest":
                case "lowest":
                case "1":
                    return MailImportance.Lowest;
                case "mplow":
                case "low":
                case "2":
                    return MailImportance.Low;
                case "mpnormal":
                case "normal":
                case "3":
                case "":
                    return MailImportance.Normal;
                case "mphigh":
                case "high":
                case "4":
                    return MailImportance.High;
                case "mphighest":
                case "highest":
                case "5":
                    return MailImportance.Highest;
                default:
                    throw new Exception("Unrecognized MailImportance enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MailImportance GetEnumerationValue(int value)
        {
            switch (value)
            {
                case 1:
                    return MailImportance.Lowest;
                case 2:
                    return MailImportance.Low;
                case 3:
                    return MailImportance.Normal;
                case 4:
                    return MailImportance.High;
                case 5:
                    return MailImportance.Highest;
                default:
                    throw new Exception("Unrecognized MailImportance enumeration value");
            }
        }

    }

}
