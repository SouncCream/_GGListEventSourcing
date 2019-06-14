using BankListEventSourcing.Interface;
using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListEventSourcing.Manager.Extension
{
    public static class EventStoreDataAccessManager
    {

        //public static void AddNewJsonStream(this EventStoreConnectionManager connectionManager, string eventType, object model)
        //{
        //    var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
        //    var myEvent = new EventData(Guid.NewGuid(), eventType, true, Encoding.UTF8.GetBytes(json), null);
        //    connectionManager.Connection.AppendToStreamAsync("arm", -1, myEvent).Wait();
        //}

        public static T AddNewJsonStream<T>(this IEventStoreConnection connection, IEventType<T> eventType) where T : class
        {
            if (!StreamExits(connection, eventType.StreamName))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(eventType.Data);
                var myEvent = new EventData(Guid.NewGuid(), eventType.EventType, true, Encoding.UTF8.GetBytes(json), null);
                connection.AppendToStreamAsync(eventType.StreamName, -1, myEvent).Wait();
                return null;
                //return eventType.Data;
            }
            else
            {
                //TODO Implement Edit
                var item = GetLastEvent<T>(connection, eventType.StreamName);
                return item;
            }
        }

        public static void EditJsonStream<T>(this IEventStoreConnection connection, IEventType<T> eventType) where T : class
        {
            var eventsStream = connection.ReadStreamEventsBackwardAsync(eventType.EditStreamName, 0, 1, true).Result;
            var lastEventNr = eventsStream.LastEventNumber;
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(eventType.Data);
            var myEvent = new EventData(Guid.NewGuid(), eventType.EventType, true, Encoding.UTF8.GetBytes(json), null);
            connection.AppendToStreamAsync(eventType.EditStreamName, lastEventNr, myEvent).Wait();
        }

        public static bool StreamExits(this IEventStoreConnection connection, string streamName)
        {
            var lastEventsStream = connection.ReadStreamEventsBackwardAsync(streamName, 0, 1, false).Result;
            SliceReadStatus status = lastEventsStream.Status;
            return status == 0;
        }

        public static string GetLastEvent(this IEventStoreConnection connection, string streamName)
        {
            if (StreamExits(connection, streamName))
            {
                var eventsStream = connection.ReadStreamEventsBackwardAsync(streamName, 0, 1, true).Result;
                var lastEventNr = eventsStream.LastEventNumber;
                eventsStream = connection.ReadStreamEventsBackwardAsync(streamName, lastEventNr, 1, true).Result;
                var lastEvent = eventsStream.Events[0].Event;
                var json = Encoding.UTF8.GetString(lastEvent.Data);
                return json;
            }
            else
            {
                return null;
            }
        }

        public static T GetLastEvent<T>(this IEventStoreConnection connection, string streamName)
        {
            var jsonData = GetLastEvent(connection, streamName);
            if (!string.IsNullOrEmpty(jsonData))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonData);
            }
            return default(T);
        }

        public static List<string> GetData(this IEventStoreConnection connection)
        {
            try
            {
                List<string> result = new List<string>();
                var readEvents = connection.ReadStreamEventsForwardAsync("$streams", 0, 100, true).Result;
                var lastEvent = readEvents.NextEventNumber;
                readEvents = connection.ReadStreamEventsForwardAsync("$streams", 0, (int)lastEvent + 1, true).Result;
                foreach (var e in readEvents.Events)
                {
                    if (e.Event != null)
                    {
                        if (e.Event.EventStreamId.StartsWith("acc-"))
                        {
                            result.Add(e.Event.EventStreamId);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
