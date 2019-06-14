using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankListEventSourcing.ComponentHelper
{
    public static class TextBoxHelper
    {
        public static void SetTextNewLine(this TextBoxBase textbox, string text)
        {
            textbox.Text += $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - {text}{Environment.NewLine}";
        }
    }
}
