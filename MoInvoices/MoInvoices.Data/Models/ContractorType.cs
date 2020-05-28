using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class ContractorType
    {
        [Key]
        public int ContractorTypeID { get; set; }
        [Required]
        public int ContractorTypeName { get; set; }
    }
}
