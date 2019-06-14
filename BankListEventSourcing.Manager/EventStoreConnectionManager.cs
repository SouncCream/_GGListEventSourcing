using BankListEventSourcing.Helper;
using BankListEventSourcing.Repository.Enums;
using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BankListEventSourcing.Manager
{
    public class EventStoreConnectionManager
    {
        private static readonly string connectionString = GlobalHelper.GetEventStoreConnectionString;
        private ConnectionSettings settings;
        private IEventStoreConnection connection = EventStoreConnection.Create(connectionString, "PostingConnection");
        private volatile Constant.EventSourcing.ConnectionStatus connectionStatus = Constant.EventSourcing.ConnectionStatus.Closed;

        public EventStoreConnectionManager()
        {
            settings = ConnectionSettings.Create();
            connectionStatus = Constant.EventSourcing.ConnectionStatus.Closed;
        }

        /// <summary>
        /// Gets the status of the connection
        /// </summary>
        public string Status { get => connectionStatus.ToString(); }

        public IEventStoreConnection Connection { get => connection; }

        public void Connect()
        {
            // check is code is reconnecting or is open
            if (connectionStatus == Constant.EventSourcing.ConnectionStatus.Connected || connectionStatus == Constant.EventSourcing.ConnectionStatus.Reconnecting)
            {
                return;
            }
            else
            {
                connectionStatus = Constant.EventSourcing.ConnectionStatus.Closed;

                if (connection != null)
                {
                    connection.Closed -= ConnectionClosedEvent;
                    connection.Connected -= ConnectedEvent;
                    connection.Disconnected -= DisConnectedEvent;
                    connection.Reconnecting -= ReConnectingEvent;
                    connection.ErrorOccurred -= ConnectionErrorEvent;
                    connection.Dispose();
                    connection = null;
                }

                connection = EventStoreConnection.Create(connectionString);
                // Register events.
                connection.Closed += ConnectionClosedEvent;
                connection.Connected += ConnectedEvent;
                connection.Disconnected += DisConnectedEvent;
                connection.Reconnecting += ReConnectingEvent;
                connection.ErrorOccurred += ConnectionErrorEvent;


            }

            try
            {
                connection.ConnectAsync().Wait();
                Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                connectionStatus = Constant.EventSourcing.ConnectionStatus.Closed;
                System.Diagnostics.Debug.WriteLine("Connection is disposed. Re-init Connection" + ex.Message);
            }
        }

        private void ConnectionClosedEvent(object sender, EventArgs a)
        {
            connectionStatus = Constant.EventSourcing.ConnectionStatus.Closed;
            System.Diagnostics.Debug.WriteLine("Closed");
        }

        private void ConnectedEvent(object sender, EventArgs a)
        {
            connectionStatus = Constant.EventSourcing.ConnectionStatus.Connected;
            System.Diagnostics.Debug.WriteLine("Connected");
        }

        private void DisConnectedEvent(object sender, EventArgs a)
        {
            connectionStatus = Constant.EventSourcing.ConnectionStatus.Disconnected;
            System.Diagnostics.Debug.WriteLine("Disconnected");
        }

        private void ReConnectingEvent(object sender, EventArgs a)
        {
            connectionStatus = Constant.EventSourcing.ConnectionStatus.Reconnecting;
            System.Diagnostics.Debug.WriteLine("Reconnecting");

        }

        private void ConnectionErrorEvent(object sender, EventArgs a)
        {
            connectionStatus = Constant.EventSourcing.ConnectionStatus.Error;
            System.Diagnostics.Debug.WriteLine("Error");
        }
    }
}
