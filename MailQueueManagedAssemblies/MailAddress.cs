using System;

namespace MailQueueManagedAssemblies
{

    /// <summary>
    /// MailAddress class
    /// </summary>
    public class MailAddress
    {

        private readonly MailAddressChecker _mailChecker = new MailAddressChecker();
        private string _address = string.Empty;

        /// <summary>
        /// MailAddress class constructor
        /// </summary>
        public MailAddress()
        {
            // Do nothing
        }

        /// <summary>
        /// MailAddress class constructor
        /// </summary>
        /// <param name="address">email address</param>
        public MailAddress(string address)
        {
            if (!_mailChecker.AddressIsValid(address))
                throw new Exception(string.Format("Email address '{0}' is not valid", address));
            _address = address;
        }

        /// <summary>
        /// Returns email adress representation
        /// </summary>
        public string Address
        {
            get { return _address; }
            set
            {
                if (!_mailChecker.AddressIsValid(value))
                    throw new Exception(string.Format("Email address '{0}' is not valid", value));
                _address = value;
            }
        }

        /// <summary>
        /// Returns email address quoted represenrtation
        /// </summary>
        public string QuotedRepresentation
        {
            get { return string.Format("<{0}>", _address); }
        }

        /// <summary>
        /// Equals mail address with mail address string representation
        /// </summary>
        /// <param name="address">Mail address string representation to equal</param>
        /// <returns>true if two addresses is equal, false otherwise</returns>
        public bool Equals(string address)
        {
            var _addr = new MailAddress(address);
            return Equals(_addr);
        }

        /// <summary>
        /// Equals two mail addresses
        /// </summary>
        /// <param name="address">Mail address to equal</param>
        /// <returns>true if two addresses is equal, false otherwise</returns>
        public bool Equals(MailAddress address)
        {
            return address.Address == Address;
        }

        /// <summary>
        /// Returns email adress representation
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return _address;
        }

    }

}
