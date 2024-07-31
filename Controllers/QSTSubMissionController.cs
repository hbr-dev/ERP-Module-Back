using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QSTSubMissionController : ControllerBase
    {

        private readonly DataContext _context;

        public QSTSubMissionController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<QSTSubMission>>> GetQSTsSubMissions()
        {
            return Ok(await _context.QSTSubMissions.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<QSTSubMission>>> CreateQSTSubMission(QSTSubMission qstSubMission)
        {
            _context.QSTSubMissions.Add(qstSubMission);
            await _context.SaveChangesAsync();

            return Ok(await _context.QSTSubMissions.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<QSTSubMission>>> UpdateQSTSubMisssion(QSTSubMission qstSubMission)
        {
            var dbQSTSubMiss = await _context.QSTSubMissions.FindAsync(qstSubMission.Id);
            if (dbQSTSubMiss == null)
            {
                return BadRequest("QST-Submission not found");
            }

            dbQSTSubMiss.Submission_id = qstSubMission.Submission_id;
            dbQSTSubMiss.Question_id = qstSubMission.Question_id;
            dbQSTSubMiss.Answer = qstSubMission.Answer;

            await _context.SaveChangesAsync();

            return Ok(await _context.QSTSubMissions.ToListAsync());
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