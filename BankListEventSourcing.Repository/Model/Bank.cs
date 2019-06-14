using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankListEventSourcing.Repository.Enums.Constant;

namespace BankListEventSourcing.Repository.Model
{
    public class Bank
    {
        public string Name { get; set; }

        /// <summary>
        /// ISO3
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 0: Unknow
        /// 1: Inactive
        /// 2: Active
        /// </summary>
        public StatusEnums Status { get; set; }

    }
}
