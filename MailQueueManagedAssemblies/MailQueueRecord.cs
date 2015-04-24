using System;
using System.Text;
using System.Net.Mail;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// 
    /// </summary>
    public class MailQueueRecord
    {

        private MailDelimiter _mailDelimiter = MailDelimiter.Default;
        private string _subject = string.Empty;
        private string _body = string.Empty;
        private MailAddressList _to = new MailAddressList();
        private MailAddress _from = new MailAddress();
        private Encoding _subjectEncoding = Encoding.Default;
        private Encoding _bodyEncoding = Encoding.Default;
        private string _displayName = string.Empty;
        private MailAddressList _cc = new MailAddressList();
        private MailAddressList _bcc = new MailAddressList();
        private MailPriority _mailPriority = MailPriority.Normal;
        private MailAttachmentList _attachmentList = new MailAttachmentList();
        private bool _isBodyHtml = true;
        private int? _templateId;
        private int _sendPriority = 50;
        //private string _owner = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        public MailQueueRecord(string Subject, string Body, string From, string To)
        {
            _subject = Subject;
            _body = Body;
            _from.Address = From;
            _to.AddAddresses(To, _mailDelimiter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Subject"></param>
        /// <param name="Body"></param>
        /// <param name="From"></param>
        /// <param name="To"></param>
        public MailQueueRecord(string Subject, string Body, MailAddress From, MailAddressList To)
        {
            if(To.Delimiter != _mailDelimiter)
                throw new Exception("MailDelimiter value conflict to applied value");
            _subject = Subject;
            _body = Body;
            _from = From;
            _to = To;
        }

        /// <summary>
        /// MailDelimiter
        /// </summary>
        public MailDelimiter MailDelimiter
        {
            get { return _mailDelimiter; }
            set { _mailDelimiter = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Encoding SubjectEncoding
        {
            get { return _subjectEncoding;  }
            set { _subjectEncoding = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        public void SetSubjectEncoding(string encoding)
        {
            var _e = new EncodingEnumerator();
            _subjectEncoding = _e.GetEncoding(encoding);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Encoding BodyEncoding
        {
            get { return _bodyEncoding; }
            set { _bodyEncoding = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        public void SetBodyEncoding(string encoding)
        {
            var _e = new EncodingEnumerator();
            _bodyEncoding = _e.GetEncoding(encoding);
        }

        /// <summary>
        /// 
        /// </summary>
// ReSharper disable ConvertToAutoProperty
        public MailAddress From
// ReSharper restore ConvertToAutoProperty
        {
            get { return _from; }
            set { _from = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        /// <summary>
        /// 
        /// </summary>
// ReSharper disable ConvertToAutoProperty
        public MailAddressList To
// ReSharper restore ConvertToAutoProperty
        {
            get { return _to; }
            set
            {
                if (value.Delimiter != _mailDelimiter)
                    throw new Exception("MailDelimiter value conflict to applied value");
                _to = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
// ReSharper disable ConvertToAutoProperty
        public MailAddressList CC
// ReSharper restore ConvertToAutoProperty
        {
            get { return _cc; }
            set
            {
                if (value.Delimiter != _mailDelimiter)
                    throw new Exception("MailDelimiter value conflict to applied value");
                _cc = value;
            } 
        }

        /// <summary>
        /// 
        /// </summary>
// ReSharper disable ConvertToAutoProperty
        public MailAddressList BCC
// ReSharper restore ConvertToAutoProperty
        {
            get { return _bcc; }
            set
            {
                if (value.Delimiter != _mailDelimiter)
                    throw new Exception("MailDelimiter value conflict to applied value");
                _bcc = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MailPriority MailPriority
        {
            get { return _mailPriority; }
            set { _mailPriority = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Priority"></param>
        public void SetMailPriority(string Priority)
        {
            var _e = new MailPriorityEnumerator();
            _mailPriority = _e.GetMailPriority(Priority);
        }

        /// <summary>
        /// 
        /// </summary>
        public MailAttachmentList Attachments
        {
            get { return _attachmentList; }
            set { _attachmentList = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsBodyHtml
        {
            get { return _isBodyHtml; }
            set { _isBodyHtml = value; }
        }

        /// <summary>
        /// 
        /// </summary>
// ReSharper disable ConvertToAutoProperty
        public int? TemplateId
// ReSharper restore ConvertToAutoProperty
        {
            get { return _templateId; }
            set { _templateId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SendPriority
        {
            get { return _sendPriority; }
            set
            {
                if(value <1)
                    throw new Exception("Incorrect SendPriority parameter value");
                if(value >100)
                    throw new Exception("Incorrect SendPriority parameter value");
                _sendPriority = value;
            }
        }

    }

}
