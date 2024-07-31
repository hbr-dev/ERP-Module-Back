using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Backend.Models;
using BackEnd.Data;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {

        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Subject>>> GetSubjects()
        {
            return Ok(await _context.Subjects.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Subject>>> CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.Subjects.ToListAsync());
        }



        // [HttpPut]
        // public async Task<ActionResult<List<SuperHero>>> UpdateSuperHero(SuperHero superHero)
        // {
        //     var dbSuperHero = await _context.SuperHeroes.FindAsync(superHero.ID);
        //     if (dbSuperHero == null)
        //     {
        //         return BadRequest("SuperHero not found");
        //     }

        //     dbSuperHero.FirstName = superHero.FirstName;
        //     dbSuperHero.LastName = superHero.LastName;
        //     dbSuperHero.Name = superHero.Name;
        //     dbSuperHero.Place = superHero.Place;

        //     await _context.SaveChangesAsync();

        //     return Ok(await _context.SuperHeroes.ToListAsync());
        // }



        // [HttpDelete("{id}")]
        // public async Task<ActionResult<List<SuperHero>>> DeleteSuperHero(int id)
        // {
        //     var dbSuperHero = await _context.SuperHeroes.FindAsync(id);
        //     if (dbSuperHero == null)
        //     {
        //         return BadRequest("SuperHero not found");
        //     }

        //     _context.SuperHeroes.Remove(dbSuperHero);
        //     await _context.SaveChangesAsync();

        //     return Ok(await _context.SuperHeroes.ToListAsync());
        // }
    }
}