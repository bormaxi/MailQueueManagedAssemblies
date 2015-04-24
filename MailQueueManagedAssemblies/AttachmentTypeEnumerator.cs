using System;

namespace MailQueueManagedAssemblies
{
    
    /// <summary>
    /// 
    /// </summary>
    public class AttachmentTypeEnumerator
    {
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AttachmentType"></param>
        /// <returns></returns>
        public string ToString(AttachmentType AttachmentType)
        {
            switch (AttachmentType)
            {
                case AttachmentType.Default:
                    return "atFromFile";
                case AttachmentType.AtFromFile:
                    return "atFromFile";
                case AttachmentType.AtFromBase64String:
                    return "atFromBase64String";
                default:
                    throw new Exception("Unkown AttachmentType value");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AttachmentType"></param>
        /// <returns></returns>
        public AttachmentType GetAttachmentType(string AttachmentType)
        {
            switch (AttachmentType)
            {
                case "Default":
                    return MailQueueManagedAssemblies.AttachmentType.AtFromFile;
                case "atFromFile":
                    return MailQueueManagedAssemblies.AttachmentType.AtFromFile;
                case "atFromBase64String":
                    return MailQueueManagedAssemblies.AttachmentType.AtFromBase64String;
                default:
                    throw new Exception("Unkown AttachmentType value");
            }
        }

    }

}
