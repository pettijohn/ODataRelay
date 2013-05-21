using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataRelay
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public Guid UserID { get; set; }

        private ContractAccount[] _contractAccounts;

        public ContractAccount[] ContractAccounts
        {
            get { return _contractAccounts; }
            set { _contractAccounts = value; }
        }

    }
}