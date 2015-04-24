using System;
using System.Collections;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// Класс представляет адрес email и операции для работы с ним
    /// </summary>
    public class MailAddressList
    {

        private readonly SortedList _addresses = new SortedList();
        private MailDelimiter _mailDelimiter = MailDelimiter.Semicolon;

        private bool _useBackspace = true;

        #region MailAddressList class constructors

        /// <summary>
        /// MailAddressList class constructor
        /// </summary>
        public MailAddressList()
        {
            // Do nothing
        }

        /// <summary>
        /// MailAddressList class constructor
        /// </summary>
        /// <param name="delimiter">Символ-разделитель адресов email</param>
        public MailAddressList(MailDelimiter delimiter)
        {
            _mailDelimiter = delimiter;
        }

        /// <summary>
        /// MailAddressList class constructor
        /// </summary>
        /// <param name="addresses">Строка адресов email</param>
        public MailAddressList(string addresses)
        {
            AddAddresses(addresses);
        }

        /// <summary>
        /// MailAddressList class constructor
        /// </summary>
        /// <param name="addresses">Строка адресов email</param>
        /// <param name="delimiter">Символ-разделитель адресов email</param>
        public MailAddressList(string addresses, MailDelimiter delimiter)
        {
            _mailDelimiter = delimiter;
            AddAddresses(addresses);
        }

        #endregion

        #region MailAddressList class properties

        /// <summary>
        /// Свойство задает разделитель между адресами email в списке адресов объекта MailAddressList
        /// </summary>
        public MailDelimiter Delimiter
        {
            get { return _mailDelimiter; }
            set { _mailDelimiter = value; }
        }

        /// <summary>
        /// Свойство определяет, разрешать (true) или запрещать (false) хранение дублирующихся адресов email в списке адресов объекта MailAddressList
        /// </summary>
        public bool AllowDuplicateAddresses { get; set; }

        /// <summary>
        /// Свойство определяет, нужно ли использовать пробел между адресами при выгрузке списка адресов объекта MailAddressList методом Totring()
        /// </summary>
        public bool UseBackspace
        {
            get { return _useBackspace; }
            set { _useBackspace = value; }
        }

        /// <summary>
        /// Свойство определяет, нужно ли использовать кавычки при выгрузке списка адресов объекта MailAddressList методом ToString()
        /// </summary>
        public bool UseQuotes { get; set; }

        /// <summary>
        /// Свойство возвращает количество адресов, содержащихся в списке адресов объекта MailAddressList
        /// </summary>
        public int Count
        {
            get { return _addresses.Count; }
        }

        #endregion

        /// <summary>
        /// Функция проверяет наличие адресов email в списке адресов объекта MailAddressList
        /// </summary>
        /// <returns>true если объект MailAddressList содержит адреса email, false в противном случае</returns>
        public bool HasAddresses()
        {
            return Count > 0;
        }

        /// <summary>
        /// Функция проверки наличия адреса email в списке адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Строка, представляющая искомый адрес email</param>
        /// <returns>true если адрес есть в списке адресов объекта MailAddressList, false в противном случае</returns>
        public bool Exists(string address)
        {
            var _address = new MailAddress(address);
            return Count > 0 && Exists(_address);
        }

        /// <summary>
        /// Функция проверки наличия адреса email в объекте MailAddressList
        /// </summary>
        /// <param name="address">Искомый адрес email</param>
        /// <returns>true если адрес есть в списке адресов объекта MailAddresses, false в противном случае</returns>
        public bool Exists(MailAddress address)
        {
            if (Count > 0)
                for (var i = 0; i < _addresses.Count; i++)
                    if (((MailAddress)_addresses.GetByIndex(i)).Equals(address))
                        return true;
            return false;
        }

        /// <summary>
        /// Функция возвращает адрес email с заданным индексом index
        /// </summary>
        /// <param name="index">Индекс адреса email в списке адресов объекта MailAddressList</param>
        /// <returns>Объект, представляющий адрес email</returns>
        public MailAddress GetAddress(int index)
        {
            if (index < 0)
                throw new Exception(string.Format("Invalid address index: {0}", index));
            if (index >= Count)
                throw new Exception(string.Format("Invalid address index: {0}", index));
            return (MailAddress)_addresses.GetByIndex(index);
        }

        /// <summary>
        /// Функция возвращает строковое представление адреса email с заданным индексом index
        /// </summary>
        /// <param name="index">Индекс адреса email в списке адресов объекта MailAddressList</param>
        /// <returns>Строка, представляющая адрес email</returns>
        public string GetStringAddress(int index)
        {
            return GetAddress(index).Address;
        }

        /// <summary>
        /// Процедура добавления адреса email, заданного строкой address в список адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Строка, задающая адрес email</param>
        public void AddAddress(string address)
        {
            var _addr = new MailAddress(address);
            AddAddress(_addr);
        }

        /// <summary>
        /// Процедура добавления адреса email в список адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Объект, представляющий адрес email</param>
        public void AddAddress(MailAddress address)
        {
            if ((AllowDuplicateAddresses) && (IndexOf(address) >= 0))
                throw new Exception(string.Format("Address '{0}' already exists in address list", address.Address));
            _addresses.Add(_addresses.Count, address);
        }

        /// <summary>
        /// Процедура добавляет строку адресов email в список адресов объекта MailAddressList;
        /// При добавлении используется указанный в параметре MailDelimiter разделитель;
        /// ВАЖНО: при добавлении дублирующиеся адреса выбрасываются!
        /// </summary>
        /// <param name="addresses">Строка адресов email для добавления</param>
        /// <param name="delimiter">Разделитель адресов email</param>
        public void AddAddresses(string addresses, MailDelimiter delimiter)
        {

            var _checker = new MailAddressChecker();

            // Разбивка строки адресов на подадреса
            var _addresses_tmp = delimiter == MailDelimiter.Comma ? addresses.Replace(";", ",") : addresses.Replace(",", ";");
            var _separator = delimiter == MailDelimiter.Comma ? "," : ";";
            var _addr = _addresses_tmp.Split(Convert.ToChar(_separator));

            // Очистка от символов quote, проверка валидности адресов
            for (var i = 0; i < _addr.Length; i++)
            {
                _addr[i] = _addr[i].Trim();
                if (_addr[i].Length > 0)
                {
                    if (_addr[i][0] == Convert.ToChar("<"))
                        _addr[i] = _addr[i].Substring(1, _addr[i].Length - 1);
                    if (_addr[i][_addr[i].Length - 1] == Convert.ToChar(">"))
                        _addr[i] = _addr[i].Substring(0, _addr[i].Length - 1);
                }
                var _res = _checker.AddressIsValid(_addr[i]);
                if (!_res)
                    throw new Exception(string.Format("One or more addresses is not valid: '{0}'. Invalid address: '{1}', index: {2}", addresses, _addr[i], i));
            }

            // Добавление адресов в объект MailAddressList
            for (var i = 0; i < _addr.Length; i++)
            {
                if (_addr[i].Length > 0)
                    AddAddress(_addr[i]);
            }

        }

        /// <summary>
        /// Процедура добавляет строку адресов email в список адресов объекта MailAddressList;
        /// При добавлении используется установленный разделитель;
        /// ВАЖНО: при добавлении дублирующиеся адреса выбрасываются!
        /// </summary>
        /// <param name="addresses">Строка адресов email для добавления</param>
        public void AddAddresses(string addresses)
        {
            AddAddresses(addresses, Delimiter);
        }

        /// <summary>
        /// Процедура удаления всех адресов из объекта MailAddresses
        /// </summary>
        public void Clear()
        {
            _addresses.Clear();
        }

        /// <summary>
        /// Процедура возвращает индекс строкового представления адреса email в список адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Строковое представление искомого адреса email</param>
        /// <returns>Индекс адреса в объекте MailAddressList, -1 если адрес не найден</returns>
        public int IndexOf(string address)
        {
            var _addr = new MailAddress(address);
            return IndexOf(_addr);
        }

        /// <summary>
        /// Процедура возвращает индекс адреса email в список адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Объект, представляющий искомый адрес email</param>
        /// <returns>Индекс адреса в объекте MailAddressList, -1 если адрес не найден</returns>
        public int IndexOf(MailAddress address)
        {
            return _addresses.IndexOfValue(address);
        }

        /// <summary>
        /// Процедура удаляет адрес, представленный строкой email, из списка адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Строка, представляющая адрес email</param>
        public void Remove(string address)
        {
            var _addr = new MailAddress(address);
            Remove(_addr);
        }

        /// <summary>
        /// Процедура удаляет адрес из списка адресов объекта MailAddressList
        /// </summary>
        /// <param name="address">Объект, представляющий адрес email</param>
        public void Remove(MailAddress address)
        {
            var index = IndexOf(address);
            Remove(index);
        }

        /// <summary>
        /// Процедура удаляет адрес с индексом index из списка адресов объекта MailAddressList
        /// </summary>
        /// <param name="index">Индекс адреса email в списке адресов объекта MailAddressList</param>
        public void Remove(int index)
        {
            if (_addresses.IndexOfKey(index) < 0)
                throw new Exception(string.Format("Invalid address index: {0}", index));
            _addresses.Remove(index);
        }

        /// <summary>
        /// Функция преобразует адреса, содержащиеся в объекте mailAddressList, в строку email
        /// При преобразовании используется указанный разделитель email
        /// </summary>
        /// <param name="delimiter">Разделтель адресов email</param>
        /// <returns>Строковое предтавление списка адресов объекта MailAddressList</returns>
        public string ToString(MailDelimiter delimiter)
        {

            if (!HasAddresses())
                return string.Empty;

            var _restore = string.Empty;
            var _prefix = string.Empty;
            var _postfix = string.Empty;
            if (UseQuotes)
            {
                _prefix = "<";
                _postfix = ">";
            }
            if (_addresses.Count > 1)
            {
                _postfix += Delimiter == MailDelimiter.Comma ? "," : ";";
                if (UseBackspace)
                    _postfix += " ";
            }
            for (var i = 0; i < _addresses.Count; i++)
            {
                var _representation = UseQuotes ? ((MailAddress)_addresses.GetByIndex(i)).QuotedRepresentation : ((MailAddress)_addresses.GetByIndex(i)).Address;
                _restore += string.Format("{0}{1}{2}", _prefix, _representation, _postfix);
            }
            _restore = _restore.Trim();
            if (Count > 1)
                _restore = _restore.Substring(0, _restore.Length - 1);
            return _restore;

        }

        /// <summary>
        /// Функция преобразует адреса, содержащиеся в списке адресов объекта MailAddressList, в строку email
        /// </summary>
        /// <returns>Строковое предтавление списка адресов объекта MailAddressList</returns>
        public new string ToString()
        {
            return ToString(Delimiter);
        }

    }

}
