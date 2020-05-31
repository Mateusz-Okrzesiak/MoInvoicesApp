using System;
using System.Collections.Generic;
using System.Text;

namespace MoInvoices.Data.DTO
{
    public class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string NIP { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int UserID { get; set; }
    }
}
