using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankListEventSourcing.Helper
{
    public static class TextTemplateHelper
    {
        public static string GetStreamName(object obj)
        {
            var result = $"{obj.ToString()} Model";
            return result;
        }

    }

}
