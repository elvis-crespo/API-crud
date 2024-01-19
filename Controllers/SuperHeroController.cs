using ApiSuperHero_DotNet8.Context;
using ApiSuperHero_DotNet8.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiSuperHero_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHero()
        {
            var hero = await _context.SuperHeroes.ToListAsync();

            //var hero = new List<SuperHero>
            //{
            //    new()
            //    {
            //        Id = 1,
            //        Name = "Test",
            //        FirstName = "Test",
            //        LastName = "",
            //        Place = "Sydnye"
            //    }
            //};
            return Ok(hero);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null) return NotFound("Hero not found");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updateHero)
        { 
            var dbHero = await _context.SuperHeroes.FindAsync(updateHero.Id);

            if (dbHero is null) return NotFound("Hero not found");

            dbHero.Name = updateHero.Name;
            dbHero.FirstName = updateHero.FirstName;
            dbHero.LastName = updateHero.LastName;
            dbHero.Place = updateHero.Place;

            await _context.SaveChangesAsync();  

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);

            if (dbHero is null) return NotFound("Hero not found");

            _context.SuperHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
