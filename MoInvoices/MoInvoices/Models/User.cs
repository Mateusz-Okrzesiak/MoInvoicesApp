using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Login { get; set; }

        public User()
        {
            this.Invoices = new HashSet<Invoice>();
        }   
        public virtual ICollection<Invoice> Invoices { get; private set; }
    }
}
