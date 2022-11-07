using Customer.Entity;
using Customer.Interfaces;
using Customer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{

    [Route("api/customerLogin")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly CustomerLoginService c;
        public CustomerLoginController()
        {
            this.c = new CustomerLoginService();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            customerLogin cus = c.GetbyId(id);
            return StatusCode(200, cus);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<customerLogin> customers = c.GetAll();
            return StatusCode(200, customers);

        }
        [HttpPost("add")]
        public IActionResult Add(customerLogin cus)
        {
            customerLogin res = c.Add(cus);
            if (res != null)
                return StatusCode(200, res);
            else
                return StatusCode(200, "Customer ID Not found!");
        }
        [HttpPut("edit")]
        public IActionResult Edit(customerLogin cus)
        {
            c.Edit(cus);
            return StatusCode(200, cus);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            c.Delete(id);
            return StatusCode(200, $"Customer id (login) :  {id} is Deleted");
        }



    }
}
