using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoInvoices.Data.Models
{
    public class PaymentStatus
    {
        [Key]
        public int PaymentStatusID { get; set; }
        [Required]
        public string PaymentStatusName { get; set; }
    }
}