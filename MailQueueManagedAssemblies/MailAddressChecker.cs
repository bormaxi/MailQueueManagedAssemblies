using System.Text.RegularExpressions;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// Класс предоставляет методы проверки адресов email на валидность
    /// </summary>
    public class MailAddressChecker
    {

        private string _validationRegEx;

        /// <summary>
        /// MailAddressChecker class constructor
        /// </summary>
        public MailAddressChecker()
        {
            _validationRegEx = @"^[a-zA-Z0-9](\.[a-zA-Z0-9]|\-[a-zA-Z0-9]|_[a-zA-Z0-9]|([a-zA-Z0-9]*))*@[a-zA-Z0-9][a-zA-Z0-9\-_!]*\.[a-z0-9]{2,4}";
        }

        /// <summary>
        /// MailAddressChecker class constructor
        /// </summary>
        /// <param name="ValidateRegex"></param>
        public MailAddressChecker(string ValidateRegex)
        {
            _validationRegEx = ValidateRegex;
        }

        /// <summary>
        /// Свойство возвращает строку валидации адресов email
        /// </summary>
// ReSharper disable ConvertToAutoProperty
        public string ValidationRegEx
// ReSharper restore ConvertToAutoProperty
        {
            get { return _validationRegEx; }
            set { _validationRegEx = value; }
        }

        /// <summary>
        /// Функция проверки валидности адреса email
        /// </summary>
        /// <param name="address">Строка адреса email</param>
        /// <returns>true если адрес email валидный, false в противном случае</returns>
        public bool AddressIsValid(string address)
        {
            return ValidateAddress(address, _validationRegEx);
        }

        /// <summary>
        /// Функция проверки валидности адреса email по заданному регулярному выражению
        /// </summary>
        /// <param name="address">Проверяемый адрес email</param>
        /// <param name="regex">Строка регулярного выражения для проверки</param>
        /// <returns>true если адрес email валидный, false в противном случае</returns>
        private static bool ValidateAddress(string address, string regex)
        {
            var _result = true;
            var r = new Regex(regex, RegexOptions.Compiled);
            var m = r.Match(address);
            if (m.Groups[1].Length > 0)
                _result = false;
            return _result;
        }

    }

}
