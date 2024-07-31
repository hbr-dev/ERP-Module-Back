using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Backend.Models;
using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        private readonly DataContext _context;

        public QuestionController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Quest>>> GetQuestions()
        {
            return Ok(await _context.Questions.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Quest>>> CreateQuestion(Quest question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return Ok(await _context.Questions.ToListAsync());
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