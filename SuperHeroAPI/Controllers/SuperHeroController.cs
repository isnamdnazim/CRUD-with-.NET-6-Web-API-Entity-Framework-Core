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
                 }
            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heros);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heros.Add(hero);
            return Ok(heros);
        }
    }
}
