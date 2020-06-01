using MoInvoices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoInvoices.Data.Migrations
{
    public class Configuration
    {

        protected static void Seed(MoInvoices.Pages.MoInvoiceContext context)
        {
            if (!context.User.Any())
            {
                var users = new List<User>
            {
                new User { Login = "Admin" },
                new User { Login = "user2" },
            };
                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
