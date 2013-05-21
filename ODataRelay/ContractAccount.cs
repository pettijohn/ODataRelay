using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataRelay
{
    public class ContractAccount
    {
        public string ContractAccountNumber { get; set; }
        public DateTime MoveInDate { get; set; }
        public DateTime MoveOutDate { get; set; }

        private Contract[] _contracts;

        public Contract[] Contracts
        {
            get { return _contracts; }
            set { _contracts = value; }
        }

    }
}