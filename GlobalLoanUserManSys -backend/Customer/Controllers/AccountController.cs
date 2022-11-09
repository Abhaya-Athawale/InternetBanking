using Microsoft.AspNetCore.Mvc;
using Customer.Entity;
using Customer.Services;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService ac;

        public AccountController()
        {
            ac = new AccountService();
        }

        // GET: api/<AccountController>
        [HttpGet,Route("GetAccounts")]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, ac.GetAllAccnts());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<AccountController>/5
        [HttpGet,Route("GetAccntById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return StatusCode(200, ac.GetAccntbyId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<AccountController>
        [HttpPost,Route("AddAccount")]
        public IActionResult Post([FromBody] Account value)
        {
            try
            {
                ac.AddAccnt(value);
                return StatusCode(200, value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<AccountController>/5
        [HttpPut,Route("editAccount/{id}")]
        public IActionResult Put(int id, [FromBody] Account value)
        {
            try
            {
                ac.EditAccnt(id, value);
                return StatusCode(200, value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<AccountController>/5
        [HttpDelete,Route("DeleteAccount/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ac.DeleteAccnt(id);
                return StatusCode(200, NoContent());
                //comment added for new commit
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
