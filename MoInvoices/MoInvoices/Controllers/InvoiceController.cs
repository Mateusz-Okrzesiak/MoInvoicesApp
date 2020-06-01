
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Core;
using MoInvoices.Data.Models;
using MoInvoices.DTO;

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
        [HttpPut]
        public void Put([FromBody] InvoiceDTO invoice)
        {
            this._invoiceService.UpdateInvoice(invoice);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._invoiceService.DeleteInvoice(id);
        }

        #endregion

        // GET AllUserInvoices/{userid}
        [HttpGet("AllUserInvoices/{userid}")]
        public IEnumerable<InvoiceListDTO> AllUserInvoices(int userID)
        {
            return this._invoiceService.GetAllUserInvoices(userID);
        }

        [HttpGet("DocumentTypes")]
        public IEnumerable<DocumentType> DocumentTypes()
        {
            return this._invoiceService.GetDocumentTypes();
        }

        [HttpGet("PaymentTypes")]
        public IEnumerable<PaymentType> PaymentTypes()
        {
            return this._invoiceService.GetPaymentTypes();
        }

        [HttpGet("PaymentStatuses")]
        public IEnumerable<PaymentStatus> PaymentStatuses()
        {
            return this._invoiceService.GetPaymentStatuses();
        }


    }
}
