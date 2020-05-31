using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoInvoices.Core.Customer;
using MoInvoices.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        // GET: api/<Customer>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

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
