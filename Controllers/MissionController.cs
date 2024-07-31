using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionController : ControllerBase
    {

        private readonly DataContext _context;

        public MissionController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Mission>>> GetMissions()
        {
            return Ok(await _context.Missions.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Mission>>> CreateMission(Mission mission)
        {
            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();

            return Ok(await _context.Missions.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<Mission>>> UpdateMission(Mission mission)
        {
            var dbMission = await _context.Missions.FindAsync(mission.Id);
            if (dbMission == null)
            {
                return BadRequest("Mission not found");
            }

            dbMission.Name = mission.Name;
            dbMission.Descriprtion = mission.Descriprtion;
            dbMission.Start_date = mission.Start_date;
            dbMission.End_date = mission.End_date;
            dbMission.Subject_id = mission.Subject_id;
            dbMission.Status = mission.Status;

            await _context.SaveChangesAsync();

            return Ok(await _context.Missions.ToListAsync());
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