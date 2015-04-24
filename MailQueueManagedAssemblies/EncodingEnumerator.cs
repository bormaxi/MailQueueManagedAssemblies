using System.Text;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class EncodingEnumerator
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public Encoding GetEncoding(string encoding)
        {
            switch (encoding)
            {
                case "ASCII":
                    return Encoding.ASCII;
                case "UTF7":
                    return Encoding.UTF7;
                case "UTF8":
                    return Encoding.UTF8;
                case "UTF32":
                    return Encoding.UTF32;
                case "Unicode":
                    return Encoding.Unicode;
                default:
                    return Encoding.Default;
            }
        }

    }

}
