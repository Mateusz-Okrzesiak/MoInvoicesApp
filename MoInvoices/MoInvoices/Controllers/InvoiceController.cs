using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly MoInvoiceContext _context;
        private readonly IMapper _mapper;
        public InvoiceController(MoInvoiceContext context, IMapper mapper)
        {
            _context = context;
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value1";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] InvoiceDTO invoice)
        {
            try
            {
                //var newsInvoice = _mapper.Map<Invoice>(invoice);
                Invoice newInvoice = new Invoice()
                {
                    DocumentType = invoice.DocumentType,
                    InvoiceNumber = invoice.InvoiceNumber,
                    SellData = invoice.SellData,
                    IssueDate = invoice.IssueDate,
                    CityOfIssue = invoice.CityOfIssue,
                    IsPayed = invoice.IsPayed,
                    SumGrossValue = invoice.SumGrossValue,
                    SumNetValue = invoice.SumNetValue,
                    UserId = invoice.UserId,
                };
                _context.Invoice.Add(newInvoice);
                _context.SaveChanges();

                foreach (var row in invoice.Service)
                { 
                    _context.InvoiceRowService.Add(new InvoiceRowService()
                    {
                        InvoiceID = newInvoice.InvoiceID,
                        GrossValue = row.GrossValue,
                        JM = row.JM,
                        NetPrice = row.NetPrice,
                        NetWorth = row.NetWorth,
                        Quantity = row.Quantity,
                        ServiceName = row.ServiceName,
                        VatAmount = row.VatAmount,
                        VatRate = row.VatRate
                    });
                }

                Contractor Purchaser = new Contractor()
                {
                    InvoiceID = newInvoice.InvoiceID,
                    City = invoice.Purchaser.City,
                    Name = invoice.Purchaser.Name,
                    NIP = invoice.Purchaser.NIP,
                    PostalCode = invoice.Purchaser.PostalCode,
                    Street = invoice.Purchaser.Street,
                    ContractorTypeID = (int)Enum.ContractorType.Purchaser
                };

                Contractor Vendor = new Contractor()
                {
                    InvoiceID = newInvoice.InvoiceID,
                    City = invoice.Vendor.City,
                    Name = invoice.Vendor.Name,
                    NIP = invoice.Vendor.NIP,
                    PostalCode = invoice.Vendor.PostalCode,
                    Street = invoice.Vendor.Street,
                    ContractorTypeID = (int)Enum.ContractorType.Vendor
                };
  
                _context.Contractor.Add(Purchaser);
                _context.Contractor.Add(Vendor);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
            }
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO userdto)
        {

            User mappedresult = _mapper.Map<User>(userdto);
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
