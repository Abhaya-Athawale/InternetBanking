using Customer.Entity;
using Customer.Services;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("GetById/{id}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            customer cus = c.GetbyId(id);
            return StatusCode(200, cus);
        }


        [HttpGet("GetAll")]
        [Authorize]
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
        [HttpPost("Register")]
        public IActionResult Register(customer Cus)
        {
            customer c1 = c.Register(Cus);
         if (c1==null)
                return StatusCode(403, "Error in Registration");
            return StatusCode(200, c1);
        }
        [HttpPut("edit")]
        [Authorize]
        public IActionResult Edit(customer cus)
        {
            c.Edit(cus);
            return StatusCode(200, cus);
        }
        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            c.Delete(id);
            return StatusCode(200, $"Customer id :  {id} is Deleted");
        }



    }
}
