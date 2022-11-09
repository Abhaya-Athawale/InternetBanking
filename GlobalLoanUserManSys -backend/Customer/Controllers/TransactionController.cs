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
    [Authorize]

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
        [HttpGet, Route("ViewStatment")]
        public IActionResult ViewStatment(int CusId, string type, DateTime From, DateTime To)
        {
            try
            {
                List <Transaction> ts= tr.ViewStatment(CusId, type, From, To);
                return StatusCode(200, ts);

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
        [HttpPost, Route("TransactionManagement")]
        public IActionResult TransactionManagement(int CusId, string type, int amount)
        {
            try
            {
               int res =  tr.TransactionManagement(CusId, type, amount);
                
               
                   
                if (res == 0)
                    return StatusCode(404, "No account Found");
                if(res == 1)
                    return StatusCode(404, "Only Withdraw and Deposit is accepted");
                if(res ==3)
                    return StatusCode(404, "Balance Not Sufficent To make The Transaction!");
                return StatusCode(200, "Added Transaction");

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
