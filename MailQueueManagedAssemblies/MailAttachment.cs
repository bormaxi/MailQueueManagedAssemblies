using System;
using System.IO;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// Класс представляет объект-вложение электронной почты
    /// </summary>
    public class MailAttachment
    {

        private readonly string _name = string.Empty;
        private readonly string _source = string.Empty;
/*
        private readonly string _contentType = null;
        private readonly string _mediaType = null;
*/

        /// <summary>
        /// MailAttachment class constructor
        /// </summary>
        public MailAttachment(string Path)
        {

            var _fi = new FileInfo(Path);
            _name = _fi.Name;

            using (var _fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                var _buffer = new byte[(int)_fs.Length];
                try
                {
                    _fs.Read(_buffer, 0, (int)_fs.Length);
                }
                finally
                {
                    _fs.Close();
                }
                _source = Convert.ToBase64String(_buffer);
            }
            
        }

        /// <summary>
        /// MailAttachment class constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Source"></param>
        public MailAttachment(string Name, string Source)
        {
            _name = Name;
            _source = Source;
        }

        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Тело файла / указатель на размещение
        /// </summary>
        public string Source
        {
            get { return _source; }
        }

    }

}
