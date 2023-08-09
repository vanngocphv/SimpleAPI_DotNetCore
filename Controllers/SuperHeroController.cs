using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApi_DotNetCoreWebApi.Data;

namespace SimpleApi_DotNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private ApplicationDataDbContext _dbContext;


        //dependency injected
        public SuperHeroController(ApplicationDataDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //any method, any function always has a [Http + Method], if not, that function will be just a normal logic/handle function
        [HttpGet]
        //public async Task<IActionResult> Get()
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            //return a async list
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }

        //get single item with id
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {

            var hero = await _dbContext.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Not Found");
            return Ok(hero);
        }

        //create
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero superHero)
        {
            _dbContext.SuperHeroes.Add(superHero);
            //always have save after change
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }

        //update
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            //check find hero
            var hero = await _dbContext.SuperHeroes.FindAsync(request.Id);
            if (hero == null)
                return BadRequest("Not Found");
            //if found
            //hero = request;
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            _dbContext.SuperHeroes.Update(hero);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }

        //delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            //check find hero
            var hero = await _dbContext.SuperHeroes.FindAsync(id);
            if (hero == null)
                return BadRequest("Not Found");

            _dbContext.SuperHeroes.Remove(hero);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.SuperHeroes.ToListAsync());
        }
    }
}
