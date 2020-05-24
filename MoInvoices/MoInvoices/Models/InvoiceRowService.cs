using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class InvoiceRowService
    {
        [Key]
        public int InvoiceRowServiceID { get; set; }
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public string JM { get; set; }
        [Required]
        public int Quantiy { get; set; } 
        [Required]
        public decimal NetPrice { get; set; }
        [Required]
        public decimal NetWorth { get; set; }
        [Required]
        public string VatRate { get; set; }
        [Required]
        public decimal VatAmount { get; set; }
        [Required]
        public decimal GrossValue { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        public virtual Invoice Invoice { get; set; }

    }
}
