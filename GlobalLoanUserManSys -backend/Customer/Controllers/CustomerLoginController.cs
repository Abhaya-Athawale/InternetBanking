using Customer.Entity;
using Customer.Interfaces;
using Customer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Customer.Controllers
{

    [Route("api/customerLogin")]
    [ApiController]
    public class CustomerLoginController : ControllerBase
    {
        private readonly CustomerLoginService c;
        private readonly IConfiguration configuration;

        public CustomerLoginController(IConfiguration configuration)
        {
            
            this.c = new CustomerLoginService(configuration);

        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            customerLogin cus = c.GetbyId(id);
            return StatusCode(200, cus);
        }
        [HttpPost("login")]

        public IActionResult login(int id,string pass)
        {
            customerLogin cus = c.login(id, pass);
            if (cus==null)
                return StatusCode(403, "User Not Found");
            return  StatusCode(200, c.GenerateToken(cus));
        }

        [HttpGet("GetAll")]
        [Authorize]
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
        [Authorize]
        public IActionResult Edit(customerLogin cus)
        {
            c.Edit(cus);
            return StatusCode(200, cus);
        }
        [HttpDelete("delete/{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            c.Delete(id);
            return StatusCode(200, $"Customer id (login) :  {id} is Deleted");
        }



    }
}
