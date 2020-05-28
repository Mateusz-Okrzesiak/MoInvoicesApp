using Microsoft.EntityFrameworkCore;
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
    }
}
