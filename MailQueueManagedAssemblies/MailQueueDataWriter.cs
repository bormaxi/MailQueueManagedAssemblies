using System;
using System.Data;
using System.Data.SqlClient;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class MailQueueDataWriter
    {
    
        private const int DEFAULT_COMMAND_TIMEOUT = 600;

        private string _connectionString;
        private int _commandTimeout = DEFAULT_COMMAND_TIMEOUT;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public MailQueueDataWriter(string ConnectionString)
        {
            Initialize(ConnectionString, DEFAULT_COMMAND_TIMEOUT);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="CommandTimeout"></param>
        public MailQueueDataWriter(string ConnectionString, int CommandTimeout)
        {
            Initialize(ConnectionString, CommandTimeout);
        }

        /// <summary>
        /// Процедура инициализации параметров класса
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="CommandTimeout"></param>
        private void Initialize(string ConnectionString, int CommandTimeout)
        {
            DebugMode = false;
            _connectionString = ConnectionString;
            _commandTimeout = CommandTimeout;
        }

        /// <summary>
        /// Свойство определяет включение/выключение режима debug в классе
        /// </summary>
        public bool DebugMode { get; set; }

        // <summary>
        /// 
        /// 
        /// <param name="Id"></param>
        /// <param name="State"></param>
        public void MarkMessage(int Id, string State)
        {

            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[MarkMessage]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Id", Id);
                    _cmd.Parameters.AddWithValue("State", State);
                    _cmd.ExecuteNonQuery();
                }
                finally
                {
                    _conn.Close();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <param name="State"></param>
        public void UnmarkMessages(Guid ThreadId, string State)
        {
            UnmarkMessages(ThreadId.ToString(), State);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ThreadId"></param>
        /// <param name="State"></param>
        public void UnmarkMessages(string ThreadId, string State)
        {

            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[UnmarkMessages]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("ThreadId", ThreadId);
                    _cmd.Parameters.AddWithValue("State", State);
                    _cmd.ExecuteNonQuery();
                }
                finally
                {
                    _conn.Close();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Attachment"></param>
        /// <returns></returns>
        private int AddAttachment(MailAttachment Attachment)
        {
            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[AddAttachment]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Name", Attachment.Name);
                    _cmd.Parameters.AddWithValue("Source", Attachment.Source);
                    var _attachmentId = _cmd.Parameters.Add("@IDAttachment", SqlDbType.Int);
                    _attachmentId.Direction = ParameterDirection.Output;
                    _cmd.ExecuteNonQuery();
                    return Convert.ToInt32(_attachmentId);
                }
                finally
                {
                    _conn.Close();
                }
            }
        
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDMessage"></param>
        /// <param name="IDAttachment"></param>
        private void AddAttachmentRelation(int IDMessage, int IDAttachment)
        {
            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[AddAttachmentRelation]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("IDMessage", IDMessage);
                    _cmd.Parameters.AddWithValue("IDAttachment", IDAttachment);
                    _cmd.ExecuteNonQuery();
                }
                finally
                {
                    _conn.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public int AddMessage(MailQueueRecord Message)
        {

            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {

                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[AddMessage]",
                        Connection = _conn
                    };

                    _cmd.Parameters.AddWithValue("Subject", Message.Subject);
                    _cmd.Parameters.AddWithValue("SubjectEncoding", Message.SubjectEncoding);
                    _cmd.Parameters.AddWithValue("Body", Message.Body);
                    _cmd.Parameters.AddWithValue("BodyEncoding", Message.BodyEncoding);
                    _cmd.Parameters.AddWithValue("From", Message.From.Address);
                    _cmd.Parameters.AddWithValue("DisplayName", Message.DisplayName);
                    _cmd.Parameters.AddWithValue("CC", Message.CC.ToString());
                    _cmd.Parameters.AddWithValue("BCC", Message.BCC.ToString());
                    _cmd.Parameters.AddWithValue("MailPriority", Message.MailPriority);
                    _cmd.Parameters.AddWithValue("IsBodyHtml", Message.IsBodyHtml);
                    _cmd.Parameters.AddWithValue("SendPriority", Message.SendPriority);
                    
                    if(Message.Attachments.Count > 0)
                        _cmd.Parameters.AddWithValue("State", "stAddingAttachments");      // состояние добавления вложений

                    var _idMessage = _cmd.Parameters.Add("@IDMessage", SqlDbType.Int);
                    _idMessage.Direction = ParameterDirection.Output;
                    _cmd.ExecuteNonQuery();
                    
                    // Получаем идентификатор добавленной записи
                    var _id_message = Convert.ToInt32(_idMessage);                             

                    if(Message.Attachments.Count > 0)
                    {
                        // Добавление вложения
                        for (var i = 0; i < Message.Attachments.Count; i++ )
                        {
                            var _idAttachment = AddAttachment(Message.Attachments.GetAttachment(i));
                            AddAttachmentRelation(_id_message, _idAttachment);
                        }
                        // Маркировка статуом 'stNew' == на отправку
                        MarkMessage(_id_message, "stNew");
                    }
                    
                    return _id_message;

                }
                finally
                {
                    _conn.Close();
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteMessage(int Id)
        {

            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[DeleteMessage]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Id", Id);
                    _cmd.ExecuteNonQuery();
                }
                finally
                {
                    _conn.Close();
                }
            }

        }

    }

}
