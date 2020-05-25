using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Pages;
using MoInvoices.Transfer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoInvoices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceListController : ControllerBase
    {
        private readonly MoInvoiceContext _context;
        private readonly IMapper _mapper;
        public InvoiceListController(MoInvoiceContext context, IMapper mapper)
        {
            _context = context;

        }
        [HttpGet("{userID}")]
        public IEnumerable<InvoiceListDTO> Get(int userID)
        {
            IEnumerable<InvoiceListDTO> invoiceList = _context.Invoice.Where(u => u.UserId == userID)
                                                      .Select(x => new InvoiceListDTO
                                                      {
                                                          InvoiceID = x.InvoiceID,
                                                          DocumentType = x.DocumentType,
                                                          InvoiceNumber = x.InvoiceNumber,
                                                          GrossValue = x.SumGrossValue,
                                                          IssueDate = x.IssueDate,
                                                          PurchaserName = x.Contractor.Name
                                                      });

            return invoiceList;
        }

        // POST api/<InvoiceListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InvoiceListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
