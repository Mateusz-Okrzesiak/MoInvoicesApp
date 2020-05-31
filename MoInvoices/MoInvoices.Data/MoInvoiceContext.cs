using Microsoft.EntityFrameworkCore;
using MoInvoices.Data.Models;
using MoInvoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoInvoices.Pages
{
    public class MoInvoiceContext : DbContext
    {
        public MoInvoiceContext(DbContextOptions<MoInvoiceContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<Contractor> Contractor { get; set; }
        public DbSet<InvoiceRowService> InvoiceRowService { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ContractorType> ContractorType { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
    }
}
