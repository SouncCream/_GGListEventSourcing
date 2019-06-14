using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListEventSourcing.Repository.Enums
{
    public struct Constant
    {
        public enum StatusEnums
        {
            Unknow = 0,
            Inactive = 1,
            Active = 2
        }

        public struct SystemDomainEvent
        {
            public enum BankEventEnum
            {
                BankCreated = 0,
                NameChanged = 1,
                StatusChanged = 2,
            }
        }

        public struct EventSourcing
        {
            public enum ConnectionStatus
            {
                Closed = 0,
                Connected = 1,
                Reconnecting = 2,
                Disconnected = 3,
                Error = 99
            }
        }



    }
}
