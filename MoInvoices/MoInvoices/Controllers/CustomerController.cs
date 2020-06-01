using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Core.Customer;
using MoInvoices.Data.DTO;

namespace MoInvoices.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        #region REST

        // GET api/<Customer>/5
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            return this._customerService.GetCustomer(id);
        }

        // POST api/<Customer>
        [HttpPost]
        public void Post([FromBody] CustomerDTO customerDTO)
        {
            this._customerService.AddCustomer(customerDTO);
        }
            
        [HttpPut]
        public void Put([FromBody] CustomerDTO customerDTO)
        {
            this._customerService.UpdateCustomer(customerDTO);
        }

        // DELETE api/<Customer>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             this._customerService.DeleteCustomer(id);
        }

        #endregion

        [HttpGet("AllUserCustomers/{userid}")]
        public IEnumerable<CustomerListDTO> AllUserCustomers(int userID)
        {
            return this._customerService.GetAllUserCustomers(userID);
        }
    }
}
