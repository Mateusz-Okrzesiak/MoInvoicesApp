using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }
        [Required]
        public string DocumentType { get; set; }
        [Required]
        public string InvoiceNumber { get; set; }
        [Required]
        public DateTime SellData { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [Required]
        public string CityOfIssue { get; set; }
        [Required]
        public bool IsPayed { get; set; }
        [Required]
        public decimal SumGrossValue { get; set; }
        [Required]
        public decimal SumNetValue { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public Invoice()
        {
            this.InvoiceRowServices = new HashSet<InvoiceRowService>();
            this.Contractors = new HashSet<Contractor>();
        }

        public virtual ICollection<InvoiceRowService> InvoiceRowServices { get; private set; }
        public virtual ICollection<Contractor> Contractors { get; private set; }
    }
}
