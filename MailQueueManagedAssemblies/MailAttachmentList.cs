using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// Класс представляет список вложений объектов MailAttachment
    /// </summary>
    public class MailAttachmentList
    {

        private readonly SortedList _attachments = new SortedList();

        /// <summary>
        /// MailAttachmentList class constructor
        /// </summary>
        public MailAttachmentList()
        {
            // Do nothing
        }

        /// <summary>
        /// Функция проверяет наличие адресов email в списке адресов объекта MailAddressList
        /// </summary>
        /// <returns>true если объект MailAttachmentList содержит вложения, false - в противном случае</returns>
        public bool HasAttachments()
        {
            return Count > 0;
        }

        /// <summary>
        /// Свойство возвращает количество записей о вложениях из объекта
        /// </summary>
        public int Count
        {
            get { return _attachments.Count; }
        }

        /// <summary>
        /// Процедура удаления всех записей о вложениях из объекта MailAttachmentList
        /// </summary>
        public void Clear()
        {
            _attachments.Clear();
        }

        /// <summary>
        /// Процедура добавления вложения в список вложений объекта MailAttachmentList
        /// </summary>
        /// <param name="attachment">Объект, представляющий вложение</param>
        public void AddAttachment(MailAttachment attachment)
        {
            _attachments.Add(_attachments.Count, attachment);
        }

        /// <summary>
        /// Процедура удаляет адрес с индексом index из списка адресов объекта MailAttachmentList
        /// </summary>
        /// <param name="index">Индекс адреса email в списке адресов объекта MailAttachmentList</param>
        public void Remove(int index)
        {
            if (_attachments.IndexOfKey(index) < 0)
                throw new Exception(string.Format("Invalid attachment index: {0}", index));
            _attachments.Remove(index);
        }

        /// <summary>
        /// Функция возвращает адрес email с заданным индексом index
        /// </summary>
        /// <param name="index">Индекс адреса email в списке адресов объекта MailAddressList</param>
        /// <returns>Объект, представляющий адрес email</returns>
        public MailAttachment GetAttachment(int index)
        {
            if (index < 0)
                throw new Exception(string.Format("Invalid attachment index: {0}", index));
            if (index >= Count)
                throw new Exception(string.Format("Invalid attachment index: {0}", index));
            return (MailAttachment)_attachments.GetByIndex(index);
        }


    }

}
