﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class Contractor
    {
        [Key]        
        public int ContractorID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NIP { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public int ContractorTypeID { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
