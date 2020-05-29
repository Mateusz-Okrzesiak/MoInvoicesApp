using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public string DocumentType { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime SellData { get; set; }
        public DateTime IssueDate { get; set; }
        public string CityOfIssue { get; set; }
        public InvoiceRowServiceDTO [] Service { get; set; }
        public ContractorDTO Purchaser { get; set; }
        public ContractorDTO Vendor { get; set; }
        public bool IsPayed { get; set; }
        public decimal SumGrossValue { get; set; }
        public decimal SumNetValue { get; set; }
        public int UserId { get; set; }
    }
}
