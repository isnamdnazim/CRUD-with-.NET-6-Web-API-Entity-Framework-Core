using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heros = new List<SuperHero> {
                 new SuperHero {
                     Id = 1,
                     Name="Nazim Uddin",
                     FirstName="Nazim",
                     LastName="Uddin",
                     Place="Dhaka"
                 },
                  new SuperHero {
                     Id = 2,
                     Name="Emon Shah",
                     FirstName="Emon",
                     LastName="Shah",
                     Place="Kurigram"
                 }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heros.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero Not Found."); 
            }
                
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
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
