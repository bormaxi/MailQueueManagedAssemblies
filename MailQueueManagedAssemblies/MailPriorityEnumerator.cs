using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace MailQueueManagedAssemblies
{
    
    /// <summary>
    /// 
    /// </summary>
    public class MailPriorityEnumerator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Priority"></param>
        /// <returns></returns>
        public string ToString(MailPriority Priority)
        {
            switch (Priority)
            {
                case MailPriority.Low:
                    return "Low";
                case MailPriority.Normal:
                    return "Normal";
                case MailPriority.High:
                    return "High";
                default:
                    throw new Exception("Unknown MailPriority value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Priority"></param>
        /// <returns></returns>
        public MailPriority GetMailPriority(string Priority)
        {
            switch(Priority.ToLower())
            {
                case "low":
                    return MailPriority.Low;
                case "normal":
                    return MailPriority.Normal;
                case "high":
                    return MailPriority.High;
                default:
                    return MailPriority.Normal;
            }
        }

    }

}
