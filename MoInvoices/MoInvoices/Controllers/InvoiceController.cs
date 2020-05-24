using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Models;
using MoInvoices.Pages;

namespace MoInvoices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly MoInvoiceContext _context;
        public InvoiceController(MoInvoiceContext context)
        {
            _context = context;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] Invoice invoice)
        {
            _context.Invoice.Add(invoice);
            _context.Contractor.Add(invoice.Contractor);
            _context.Contractor.Add(invoice.Vendor);
            
            foreach (var row in invoice.InvoiceRowServices)
                _context.InvoiceRowService.Add(row);

        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
