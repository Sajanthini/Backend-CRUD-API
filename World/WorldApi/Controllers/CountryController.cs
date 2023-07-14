using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldApi.Data;
using WorldApi.Models;

namespace WorldApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public CountryController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var countries = _dbcontext.Countries.ToList();
            if(countries==null)
            {
                return NoContent();
            }
            return Ok(countries);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Country> GetById(int id) 
        {
            var country = _dbcontext.Countries.Find(id);

            if(country==null)
            {
                return NoContent();
            }
            return Ok(country);
        }

        [HttpPost]

        public ActionResult<Country> Create ([FromBody]Country country)
        {

            _dbcontext.Countries.Add(country);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpPut]

        public ActionResult<Country> Update([FromBody]Country country)
        {
            _dbcontext.Countries.Update(country);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public ActionResult DeleteById(int id)
        { 
            var country = _dbcontext.Countries.Find(id);
            _dbcontext.Countries.Remove(country);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
