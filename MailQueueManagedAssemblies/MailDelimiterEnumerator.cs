using System;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class MailDelimiterEnumerator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Delimiter"></param>
        /// <returns></returns>
        public string ToString(MailDelimiter Delimiter)
        {
            switch (Delimiter)
            {
                case MailDelimiter.Semicolon:
                    return ";";
                case MailDelimiter.Comma:
                    return ",";
                case MailDelimiter.Default:
                    return ";";
                default:
                    throw new Exception("Unrecognized MailDelimiter enumeration value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public MailDelimiter GetEnumerationValue(string value)
        {
            switch (value)
            {
                case ";":
                    return MailDelimiter.Semicolon;
                case ",":
                    return MailDelimiter.Comma;
                default:
                    throw new Exception("Unrecognized MailDelimiter enumeration value");
            }
        }

    }

}
