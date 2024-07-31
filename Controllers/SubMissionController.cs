using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMissionController : ControllerBase
    {

        private readonly DataContext _context;

        public SubMissionController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<SubMission>>> GetSubMissions()
        {
            return Ok(await _context.SubMissions.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<SubMission>>> CreateSubMission(SubMission subMission)
        {
            _context.SubMissions.Add(subMission);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubMissions.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<SubMission>>> UpdateSubMission(SubMission subMission)
        {
            var dbSubMission = await _context.SubMissions.FindAsync(subMission.Id);
            if (dbSubMission == null)
            {
                return BadRequest("Sub-misison not found");
            }
            
            dbSubMission.Name = subMission.Name;
            dbSubMission.Status = subMission.Status;
            dbSubMission.Mission_id = subMission.Mission_id;

            await _context.SaveChangesAsync();

            return Ok(await _context.SubMissions.ToListAsync());
        }



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