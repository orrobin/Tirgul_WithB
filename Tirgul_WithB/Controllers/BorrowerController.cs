using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tirgul_WithB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        public ICustomerRepo<Borrower> BorrowerRepo { get; }

        public BorrowerController(ICustomerRepo<Borrower> borrowerRepo)
        {
            BorrowerRepo = borrowerRepo;
        }
        // GET: api/<BorrowerController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await BorrowerRepo.Get());
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("isExist")]
        public async Task<ActionResult> GetIsExist()
        {
            try
            {
                return Ok(await BorrowerRepo.IsExist("Name","Ron"));
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // GET api/<BorrowerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                Borrower b = await BorrowerRepo.Get(id);
                if (b == null) return NotFound();
                return Ok(b);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        // POST api/<BorrowerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Borrower borrower)
        {
            try
            {
                borrower.Id = 0;
                await BorrowerRepo.Create(borrower);
                return Ok();
            }
            catch (System.Exception )
            {
                return BadRequest();
            }
        }

        // PUT api/<BorrowerController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Borrower value)
        {
            try
            {
               await BorrowerRepo.Update(value);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
           
        }

        // DELETE api/<BorrowerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
               await BorrowerRepo.Delete(id);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
           
        }
    }
}
