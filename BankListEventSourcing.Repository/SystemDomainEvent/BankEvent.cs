using BankListEventSourcing.Interface;
using BankListEventSourcing.Repository.Enums;
using BankListEventSourcing.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListEventSourcing.Repository.SystemDomainEvent
{
    public class BankEvent : IEventType<Bank>
    {
        private readonly string _modelName = "Bank";

        private Constant.SystemDomainEvent.BankEventEnum _eventType;
        public BankEvent(Constant.SystemDomainEvent.BankEventEnum eventType, Bank data, Guid? id = null)
        {
            _eventType = eventType;
            Data = data;
            Id = id.HasValue ? id.Value : Guid.NewGuid();
        }

        public string EventType { get { return _eventType.ToString(); } }

        public string StreamName
        {
            get { return $"{_modelName}:{Id}"; }
        }

        public string EditStreamName { get; set; }

        public Guid Id { get; set; }

        public Bank Data { get; }

    }
}
