using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.DTO
{
    public class InvoiceListDTO
    {
        public int InvoiceID { get; set; }
        public string  DocumentType { get; set; }
        public string InvoiceNumber { get; set; }
        public string PurchaserName { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal GrossValue { get; set; }
    }
}
