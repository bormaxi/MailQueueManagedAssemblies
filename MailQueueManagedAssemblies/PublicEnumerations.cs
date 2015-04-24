namespace MailQueueManagedAssemblies
{

    #region MailDelimiter enumeration

    /// <summary>
    /// MailDelimiter enumeration
    /// </summary>
    public enum MailDelimiter
    {
        /// <summary>
        /// Semicolon delimiter
        /// </summary>
        Default = 0,
        /// <summary>
        /// Comma delimiter
        /// </summary>
        Comma = 1,             // ,
        /// <summary>
        /// Semicolon delimiter
        /// </summary>
        Semicolon = 2          // ;
    }

    #endregion

    #region AttachmentType enumeration

    /// <summary>
    /// AttachmentType enumeration
    /// </summary>
    public enum AttachmentType
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 0,
        /// <summary>
        /// 
        /// </summary>
        AtFromFile = 1,
        /// <summary>
        /// 
        /// </summary>
        AtFromBase64String = 2
    }

    #endregion

    #region SendPriority enumeration

    /// <summary>
    /// SendPriority enumeration
    /// </summary>
    public enum SendPriority
    {
        /// <summary>
        /// 
        /// </summary>
        Default = 0,
        /// <summary>
        /// 
        /// </summary>
        Internal = 5,
        /// <summary>
        /// 
        /// </summary>
        Reserved = 10,
        /// <summary>
        /// 
        /// </summary>
        Lowest = 15,
        /// <summary>
        /// 
        /// </summary>
        Low = 20,
        /// <summary>
        /// 
        /// </summary>
        Normal = 25,
        /// <summary>
        /// 
        /// </summary>
        High = 30,
        /// <summary>
        /// 
        /// </summary>
        Highest = 35,
        /// <summary>
        /// 
        /// </summary>
        Debug = 40,
        /// <summary>
        /// 
        /// </summary>
        Info = 45,
        /// <summary>
        /// 
        /// </summary>
        Warn = 50,
        /// <summary>
        /// 
        /// </summary>
        Error = 55,
        /// <summary>
        /// 
        /// </summary>
        Fatal = 60,
        /// <summary>
        /// 
        /// </summary>
        NotificationDebug = 65,
        /// <summary>
        /// 
        /// </summary>
        NotificationInfo = 70,
        /// <summary>
        /// 
        /// </summary>
        NotificationWarn = 75,
        /// <summary>
        /// 
        /// </summary>
        NotificationError = 80,
        /// <summary>
        /// 
        /// </summary>
        NotificationFatal = 85,
        /// <summary>
        /// 
        /// </summary>
        SystemInfo = 90,
        /// <summary>
        /// 
        /// </summary>
        SystemWarn = 95,
        /// <summary>
        /// 
        /// </summary>
        SytemError = 100
    }

    #endregion

    #region MailImportance enumeration

    /// <summary>
    /// MailImportance enumeration
    /// </summary>
    public enum MailImportance
    {
        /// <summary>
        /// 
        /// </summary>
        Lowest = 1,
        /// <summary>
        /// 
        /// </summary>
        Low = 2,
        /// <summary>
        /// 
        /// </summary>
        Normal = 3,
        /// <summary>
        /// 
        /// </summary>
        High = 4,
        /// <summary>
        /// 
        /// </summary>
        Highest = 5
    }

    #endregion

    #region MailFlag enumeration

    /// <summary>
    /// MailFlag enumeration
    /// </summary>
    public enum MailFlag
    {
        /// <summary>
        /// 
        /// </summary>
        Answered = 1,
        /// <summary>
        /// 
        /// </summary>
        Flagged = 2,
        /// <summary>
        /// 
        /// </summary>
        Deleted = 3,
        /// <summary>
        /// 
        /// </summary>
        Draft = 4,
        /// <summary>
        /// 
        /// </summary>
        Seen = 5,
        /// <summary>
        /// 
        /// </summary>
        Recent = 6
    }

    #endregion

}