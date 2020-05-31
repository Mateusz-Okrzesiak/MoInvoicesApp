using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoInvoices.Data.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeID { get; set; }
        [Required]
        public string PaymentTypeName { get; set; }
    }
}
