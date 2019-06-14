using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListEventSourcing.Helper
{
    public class GlobalHelper
    {
        public static string GetEventStoreConnectionString => GetConnection("EventStore");

        public static readonly Func<string, string> GetConnection = (string name) =>
        {
            var connection = ConfigurationManager.ConnectionStrings[name];
            return connection.ConnectionString;
        };

    }
}
