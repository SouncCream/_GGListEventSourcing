using BankListEventSourcing.ComponentHelper;
using BankListEventSourcing.Helper;
using BankListEventSourcing.Manager;
using BankListEventSourcing.Manager.Extension;
using BankListEventSourcing.Repository.Enums;
using BankListEventSourcing.Repository.Model;
using BankListEventSourcing.Repository.SystemDomainEvent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BankListEventSourcing.Repository.Enums.Constant;
using static BankListEventSourcing.Repository.Enums.Constant.SystemDomainEvent;

namespace BankListEventSourcing
{
    public partial class Form1 : Form
    {
        private EventStoreConnectionManager eventStoreConnectionManager;

        public Form1()
        {
            InitializeComponent();
            InitialDataBindingComponent();
            eventStoreConnectionManager = new EventStoreConnectionManager();
        }

        private void InitialDataBindingComponent()
        {
            SatatusComboBox.Items.Clear();
            SatatusComboBox.Items.Add(new KeyValuePair<string, Constant.StatusEnums>("Unknow", Constant.StatusEnums.Unknow));
            SatatusComboBox.Items.Add(new KeyValuePair<string, Constant.StatusEnums>("Active", Constant.StatusEnums.Active));
            SatatusComboBox.Items.Add(new KeyValuePair<string, Constant.StatusEnums>("Inactive", Constant.StatusEnums.Inactive));
        }

        private void ConnectToEV()
        {
            ConsoleTxt.SetTextNewLine("Start Connecting to EventStore...");
            ConsoleTxt.SetTextNewLine($"Connection to {GlobalHelper.GetEventStoreConnectionString}");
            eventStoreConnectionManager.Connect();
            ConsoleTxt.SetTextNewLine(eventStoreConnectionManager.Status);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void ConnectESBtn_Click(object sender, EventArgs e)
        {
            ConnectToEV();
        }

        public void CreateNewStream(BankEvent bankEvent)
        {
            var item = eventStoreConnectionManager.Connection.AddNewJsonStream(bankEvent);
            if (item != null)
            {
                var newEvent = CompareToNewEvent(item, bankEvent);
                if (newEvent != null)
                {
                    newEvent.EditStreamName = bankEvent.StreamName;
                    eventStoreConnectionManager.Connection.EditJsonStream(newEvent);
                }
            }
            else
            {
                ConsoleTxt.SetTextNewLine($"Add {bankEvent.Id} {bankEvent.Data.Name} Succesed");
            }
        }

        private BankEvent CompareToNewEvent(Bank bank, BankEvent bankEvent)
        {
            BankEvent result = null;
            if (bank.Name != bankEvent.Data.Name)
            {
                bank.Name = bankEvent.Data.Name;
                var newEvent = new BankEvent(BankEventEnum.NameChanged, bank);
                result = newEvent;
            }
            else if (bank.Status != bankEvent.Data.Status)
            {
                bank.Status = bankEvent.Data.Status;
                var newEvent = new BankEvent(BankEventEnum.StatusChanged, bank);
                result = newEvent;
            }
            return result;
        }

        //public void CreateNewStream(BankEvent bankEvent)
        //{
        //    var item = eventStoreConnectionManager.Connection.AddNewJsonStream(bankEvent);
        //    if (item != null)
        //    {
        //        var newEvent = CompareToNewEvent(item, bankEvent);
        //        //if (newEvent != null)
        //        //{
        //        //    newEvent.EditStreamName = bankEvent.StreamName;
        //        //    eventStoreConnectionManager.Connection.EditJsonStream(newEvent);
        //        //}
        //    }
        //    else
        //    {
        //        ConsoleTxt.SetTextNewLine($"Add {bankEvent.Id} {bankEvent.Data.Name} Succesed");
        //    }
        //}

        //private BankEvent CompareToNewEvent(Bank bank, BankEvent bankEvent)
        //{
        //    BankEvent result = null;
        //    if (bank.Name != bankEvent.Data.Name)
        //    {
        //        bank.Name = bankEvent.Data.Name;
        //        var newEvent = new BankEvent(BankEventEnum.NameChanged, bank);
        //        newEvent.EditStreamName = bankEvent.StreamName;
        //        eventStoreConnectionManager.Connection.EditJsonStream(newEvent);
        //        result = newEvent;
        //    }
        //    else if (bank.Status != bankEvent.Data.Status)
        //    {
        //        bank.Status = bankEvent.Data.Status;
        //        var newEvent = new BankEvent(BankEventEnum.StatusChanged, bank);
        //        newEvent.EditStreamName = bankEvent.StreamName;
        //        eventStoreConnectionManager.Connection.EditJsonStream(newEvent);
        //        result = newEvent;
        //    }
        //    return result;
        //}

        private Bank PrepareBankModel()
        {
            var model = new Bank()
            {
                Country = CountyTxt.Text,
                Name = nameTxt.Text,
                Status = ((KeyValuePair<string, Constant.StatusEnums>)SatatusComboBox.SelectedItem).Value
            };
            return model;
        }
        private void AddNewModel()
        {
            var model = PrepareBankModel();
            var bankEvent = new BankEvent(BankEventEnum.BankCreated, model);
            if (!string.IsNullOrEmpty(textId.Text.Trim()))
            {
                bankEvent.Id = Guid.Parse(textId.Text);
            }
            CreateNewStream(bankEvent);
        }

        private bool ValidateModel()
        {
            return true;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (ValidateModel())
            {
                AddNewModel();
            }
        }
    }
}
