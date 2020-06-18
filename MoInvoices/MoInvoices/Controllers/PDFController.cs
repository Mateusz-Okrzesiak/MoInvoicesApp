
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Core;
using MoInvoices.DTO;
using MoInvoices.Web.Utility;

namespace MoInvoices.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IPDFService _IPDFGenerator;
        private readonly IInvoiceService _IInvoiceService;
        public PDFController(IPDFService pdfGenerator, IInvoiceService invoiceService)
        {
            this._IPDFGenerator = pdfGenerator;
            this._IInvoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePdf([FromBody] InvoiceDTO invoiceDTO)
        {
            var file = await this._IPDFGenerator.Create(invoiceDTO);
   
            return File(file, "application/pdf");
        }

        [HttpGet("{invoiceID}")]
        public async Task<IActionResult> CreatePdfByID(int invoiceID)
        {
           var invoice = this._IInvoiceService.GetInvoice(invoiceID);
           var file = await this._IPDFGenerator.Create(invoice);

            return File(file, "application/pdf");
        }
    }
}
