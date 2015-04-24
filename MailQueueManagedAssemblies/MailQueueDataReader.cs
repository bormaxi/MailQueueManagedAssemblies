using System;
using System.Data;
using System.Data.SqlClient;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class MailQueueDataReader
    {

        private const int DEFAULT_COMMAND_TIMEOUT = 600;

        private string _connectionString;
        private int _commandTimeout = DEFAULT_COMMAND_TIMEOUT;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        public MailQueueDataReader(string ConnectionString)
        {
            Initialize(ConnectionString, DEFAULT_COMMAND_TIMEOUT);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="CommandTimeout"></param>
        public MailQueueDataReader(string ConnectionString, int CommandTimeout)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet GetMessage(int Id)
        {

            var _ds = new DataSet();
            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[GetMessage]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Id", Id);
                    var adapter = new SqlDataAdapter(_cmd);
                    adapter.Fill(_ds, "Message");
                    return _ds;
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
        /// <returns></returns>
        public DataSet GetMessageAttachments(int Id)
        {

            var _ds = new DataSet();
            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[GetMessageAttachments]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Id", Id);
                    var adapter = new SqlDataAdapter(_cmd);
                    adapter.Fill(_ds, "Attachments");
                    return _ds;
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
        /// <param name="Count"></param>
        /// <returns></returns>
        public DataSet GetMessages(int Count)
        {

            var _ds = new DataSet();
            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[GetMessages]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Count", Count);
                    var adapter = new SqlDataAdapter(_cmd);
                    adapter.Fill(_ds, "MessagesList");
                    return _ds;
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
        /// <param name="Count"></param>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        public DataSet GetMessagesThreadLock(int Count, Guid ThreadId)
        {
            return GetMessagesThreadLock(Count, ThreadId.ToString());   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Count"></param>
        /// <param name="ThreadId"></param>
        /// <returns></returns>
        public DataSet GetMessagesThreadLock(int Count, string ThreadId)
        {

            var _ds = new DataSet();
            using (var _conn = new SqlConnection { ConnectionString = _connectionString })
            {
                try
                {
                    var _cmd = new SqlCommand
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = Convert.ToInt32(_commandTimeout),
                        CommandText = "[mq].[GetMessagesThreadLock]",
                        Connection = _conn
                    };
                    _cmd.Parameters.AddWithValue("Count", Count);
                    _cmd.Parameters.AddWithValue("ThreadId", ThreadId);
                    var adapter = new SqlDataAdapter(_cmd);
                    adapter.Fill(_ds, "MessagesList");
                    return _ds;
                }
                finally
                {
                    _conn.Close();
                }
            }

        }

    }

}
