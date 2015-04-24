using System;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class SendPriorityEnumerator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string ToString(SendPriority value)
        {
            switch (value)
            {
                case SendPriority.Default:
                    return "0";
                case SendPriority.Internal:
                    return "5";
                case SendPriority.Reserved:
                    return "10";
                case SendPriority.Lowest:
                    return "15";
                case SendPriority.Low:
                    return "20";
                case SendPriority.Normal:
                    return "25";
                case SendPriority.High:
                    return "30";
                case SendPriority.Highest:
                    return "35";
                case SendPriority.Debug:
                    return "40";
                case SendPriority.Info:
                    return "45";
                case SendPriority.Warn:
                    return "50";
                case SendPriority.Error:
                    return "55";
                case SendPriority.Fatal:
                    return "60";
                case SendPriority.NotificationDebug:
                    return "65";
                case SendPriority.NotificationInfo:
                    return "70";
                case SendPriority.NotificationWarn:
                    return "75";
                case SendPriority.NotificationError:
                    return "80";
                case SendPriority.NotificationFatal:
                    return "85";
                case SendPriority.SystemInfo:
                    return "90";
                case SendPriority.SystemWarn:
                    return "95";
                case SendPriority.SytemError:
                    return "100";
                default:
                    throw new Exception("Unrecognized SendPriority enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SendPriority GetEnumerationValue(string value)
        {
            switch (value.ToLower())
            {
                case "":
                case "0":
                case "default":
                case "spdefault":
                    return SendPriority.Default;
                case "5":
                case "internal":
                case "spinternal":
                    return SendPriority.Internal;
                case "10":
                case "reserved":
                case "spreserved":
                    return SendPriority.Reserved;
                case "15":
                case "lowest":
                case "splowest":
                    return SendPriority.Lowest;
                case "20":
                case "low":
                case "splow":
                    return SendPriority.Low;
                case "25":
                case "normal":
                case "spnormal":
                    return SendPriority.Normal;
                case "30":
                case "high":
                case "sphigh":
                    return SendPriority.High;
                case "35":
                case "highest":
                case "sphighest":
                    return SendPriority.Highest;
                case "40":
                case "debug":
                case "spdebug":
                    return SendPriority.Debug;
                case "45":
                case "info":
                case "spinfo":
                    return SendPriority.Info;
                case "50":
                case "warn":
                case "spwarn":
                    return SendPriority.Warn;
                case "55":
                case "error":
                case "sperror":
                    return SendPriority.Error;
                case "60":
                case "fatal":
                case "spfatal":
                    return SendPriority.Fatal;
                case "65":
                case "notificationdebug":
                case "spnotificationdebug":
                    return SendPriority.NotificationDebug;
                case "70":
                case "notificationinfo":
                case "spnotificationinfo":
                    return SendPriority.NotificationInfo;
                case "75":
                case "notificationwarn":
                case "spnotificationwarn":
                    return SendPriority.NotificationWarn;
                case "80":
                case "notificationerror":
                case "spnotificationerror":
                    return SendPriority.NotificationError;
                case "85":
                case "notificationfatal":
                case "spnotificationfatal":
                    return SendPriority.NotificationFatal;
                case "90":
                case "systeminfo":
                case "spsysteminfo":
                    return SendPriority.SystemInfo;
                case "95":
                case "systemwarn":
                case "spsystemwarn":
                    return SendPriority.SystemWarn;
                case "100":
                case "systemerror":
                case "spsystemerror":
                    return SendPriority.SytemError;
                default:
                    throw new Exception("Unrecognized SendPriority enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SendPriority GetEnumerationValue(int value)
        {
            return GetEnumerationValue(value.ToString());
        }

    }

}
