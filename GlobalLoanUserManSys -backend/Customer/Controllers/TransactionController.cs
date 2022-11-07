using Microsoft.AspNetCore.Mvc;
using Customer.Entity;
using Customer.Services;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TransactionService tr;

        public TransactionController()
        {
            tr = new TransactionService();
        }

        // GET: api/<TransactionController>
        [HttpGet,Route("GetTransactions")]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200, tr.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TransactionController>/5
        [HttpGet,Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return StatusCode(200, tr.GetbyId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<TransactionController>
        [HttpPost,Route("AddTranaction")]
        public IActionResult Post([FromBody] Transaction value)
        {
            try
            {
                tr.Add(value);
                return StatusCode(200, value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<TransactionController>/5
        [HttpPut,Route("EditTransaction/{id}")]
        public IActionResult Put(int id, [FromBody] Transaction value)
        {
            try
            {
                tr.Edit(id, value);
                return StatusCode(200, value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete,Route("DeleteAccount/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                tr.Delete(id);
                return StatusCode(200, NoContent());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
