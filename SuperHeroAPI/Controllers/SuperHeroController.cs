using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heros = new List<SuperHero> {
                  new SuperHero {
                     Id = 2,
                     Name="Emon Shah",
                     FirstName="Emon",
                     LastName="Shah",
                     Place="Kurigram"
                 }
            };
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.superHeroes.FindAsync(id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found."); 
            }
                
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.superHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.superHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heros.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found.");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            return Ok(heros);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found.");
            }
            heros.Remove(hero);
            return Ok(heros);
        }
    }
}
