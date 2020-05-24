using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class InvoiceRowService
    {
        public string ServiceName { get; set; }
        public string JM { get; set; }
        public int Quantiy { get; set; }
        public decimal NetPrice { get; set; }
        public decimal NetWorth { get; set; }
        public string VatRate { get; set; }
        public decimal VatAmount { get; set; }
        public decimal GrossValue { get; set; }
       
    }
}
