
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.DTO;
using MoInvoices.Web.Utility;

namespace MoInvoices.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IPDFService _IPDFGenerator;
        public PDFController(IPDFService pdfGenerator)
        {
            this._IPDFGenerator = pdfGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePdf([FromBody] InvoiceDTO invoiceDTO)
        {
            var file = await this._IPDFGenerator.Create(invoiceDTO);
   
            return File(file, "application/pdf");
        }
    }
}
