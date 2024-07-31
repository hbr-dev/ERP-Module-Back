using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffectationController : ControllerBase
    {

        private readonly DataContext _context;

        public AffectationController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Affectation>>> GetAffectations()
        {
            return Ok(await _context.Affectations.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Visit>>> CreateAffectation(Affectation aff)
        {
            _context.Affectations.Add(aff);
            await _context.SaveChangesAsync();

            return Ok(await _context.Affectations.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<Affectation>>> UpdateAffectation(Affectation aff)
        {
            var dbAff = await _context.Affectations.FindAsync(aff.Id);
            if (dbAff == null)
            {
                return BadRequest("Affectation not found");
            }

            dbAff.Mission_id = aff.Mission_id;
            dbAff.Store_id = aff.Store_id;

            await _context.SaveChangesAsync();

            return Ok(await _context.Affectations.ToListAsync());
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Affectation>>> DeleteAffectation(int id)
        {
            var dbAff = await _context.Affectations.FindAsync(id);
            if (dbAff == null)
            {
                return BadRequest("Afectation not found");
            }

            _context.Affectations.Remove(dbAff);
            await _context.SaveChangesAsync();

            return Ok(await _context.Affectations.ToListAsync());
        }
    }
}