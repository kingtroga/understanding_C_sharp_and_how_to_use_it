﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        { 
                new SuperHero {
                    Id = 1,
                    Name = "Spiderman",
                    FirstName="Peter",
                    LastName= "Parker",
                    Place = "New York City"
                },
                new SuperHero {
                    Id = 2,
                    Name = "Ironman",
                    FirstName="Tony",
                    LastName= "Stark",
                    Place = "Long Island"
                }

            };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            int index = id - 1;
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) return BadRequest("Hero not Found.");
            return Ok(hero);
        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null) return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(heroes);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            int index = id - 1;
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) return BadRequest("Hero not Found.");

            heroes.Remove(hero);
            return Ok(heroes);
        }

    }
}
