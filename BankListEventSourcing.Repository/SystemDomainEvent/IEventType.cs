using BankListEventSourcing.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListEventSourcing.Interface
{
    public interface IEventType<T> where T : class
    {
        Guid Id { get; set; }

        string EventType { get; }

        string StreamName { get; }

        string EditStreamName { get; }

        T Data { get; }
    }
}
