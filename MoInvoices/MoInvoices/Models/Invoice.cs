using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public string DocumentType { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime SellData { get; set; }
        public DateTime IssueDate { get; set; }
        public string CityOfIssue { get; set; }
        public InvoiceRowService[] Service { get; set; }
        public Contractor Purchaser { get; set; }
        public Contractor Vendor { get; set; }
        public bool IsPayed { get; set; }
        public decimal SumGrossValue { get; set; }
        public decimal SumNetValue { get; set; }
    }
}
