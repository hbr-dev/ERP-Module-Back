using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {

        private readonly DataContext _context;

        public VisitController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Visit>>> GetVisits()
        {
            return Ok(await _context.Visits.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Visit>>> CreateVisit(Visit visit)
        {
            _context.Visits.Add(visit);
            await _context.SaveChangesAsync();

            return Ok(await _context.Visits.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<Visit>>> UpdateVisit(Visit visit)
        {
            var dbVisit = await _context.Visits.FindAsync(visit.Id);
            if (dbVisit == null)
            {
                return BadRequest("Affectation not found");
            }

            dbVisit.Id = visit.Id;
            dbVisit.Visit_date = visit.Visit_date;
            dbVisit.Store_id = visit.Store_id;
            dbVisit.Status = visit.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.Visits.ToListAsync());
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Visit>>> DeleteVisit(int id)
        {
            var dbVisit = await _context.Visits.FindAsync(id);
            if (dbVisit == null)
            {
                return BadRequest("Visit not found");
            }

            _context.Visits.Remove(dbVisit);
            await _context.SaveChangesAsync();

            return Ok(await _context.Visits.ToListAsync());
        }
    }
}