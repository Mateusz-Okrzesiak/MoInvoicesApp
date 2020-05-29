using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Core;
using MoInvoices.Enum;
using MoInvoices.Models;
using MoInvoices.Pages;
using MoInvoices.Transfer;

namespace MoInvoices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }


        #region Metody REST

        // GET api/<InvoiceController>/5
        [HttpGet("{invoiceID}")]
        public InvoiceDTO Get(int invoiceID)
        {
            return this._invoiceService.GetInvoice(invoiceID);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] InvoiceDTO invoice)
        {
            this._invoiceService.AddNewInvoice(invoice);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO userdto)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion

        // GET api/answer/all
        [HttpGet("AllUserInvoices/{userid}")]
        public IEnumerable<InvoiceListDTO> AllUserInvoices(int userID)
        {
            return this._invoiceService.GetAllUserInvoices(userID);
        }


    }
}
