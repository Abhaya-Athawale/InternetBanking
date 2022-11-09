using Microsoft.AspNetCore.Mvc;
using Customer.Entity;
using Customer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
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
        [HttpPost, Route("Applyloan")]
        [Authorize]
        public IActionResult Applyloan( int Cusid, string branch, int amount)
        {
            try
            {
               int res = ac.ApplyLoan(Cusid, branch, amount);
                if (res == 0)
                    return StatusCode(404, "Account Does Not Exist");
                else if (res == 1)
                    return StatusCode(404, "Branch Does Not Exist");
                else if (res == 2)
                    return StatusCode(200, "Loan Applied");
                else if(res == 3)
                    return StatusCode(200, "Amount should be Between 0 and 100000");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
        // GET api/<AccountController>/5
        [HttpGet,Route("GetAccntById/{id}")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                ac.DeleteAccnt(id);
                return StatusCode(200, NoContent());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
