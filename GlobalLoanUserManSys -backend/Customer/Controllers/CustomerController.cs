using Customer.Entity;
using Customer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService c;
        public CustomerController()
        {
            this.c = new CustomerService();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            customer cus = c.GetbyId(id);
            return StatusCode(200, cus);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            List<customer> customers = c.GetAll();
            return StatusCode(200, customers);

        }
        [HttpPost("add")]
        public IActionResult Add(customer cus)
        {
            c.Add(cus);
            return StatusCode(200, cus);
        }
        [HttpPut("edit")]
        public IActionResult Edit(customer cus)
        {
            c.Edit(cus);
            return StatusCode(200, cus);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            c.Delete(id);
            return StatusCode(200, $"Customer id :  {id} is Deleted");
        }



    }
}
