using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly DataContext _context;

        public GroupController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Group>>> GetGroups()
        {
            return Ok(await _context.Groups.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Group>>> CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

            return Ok(await _context.Groups.ToListAsync());
        }



        // [HttpPut]
        // public async Task<ActionResult<List<AreaManager>>> UpdateAreaManager(AreaManager areaManager)
        // {
        //     var dbAreaManager = await _context.AreaManagers.FindAsync(areaManager.Id);
        //     if (dbAreaManager == null)
        //     {
        //         return BadRequest("Area-manager not found");
        //     }

        //     dbAreaManager.Name = areaManager.Name;
        //     dbAreaManager.Email = areaManager.Email;

        //     await _context.SaveChangesAsync();

        //     return Ok(await _context.AreaManagers.ToListAsync());
        // }



        // [HttpDelete("{id}")]
        // public async Task<ActionResult<List<AreaManager>>> DeleteAreaManager(int id)
        // {
        //     var dbAreaManager = await _context.AreaManagers.FindAsync(id);
        //     if (dbAreaManager == null)
        //     {
        //         return BadRequest("SuperHero not found");
        //     }

        //     _context.AreaManagers.Remove(dbAreaManager);
        //     await _context.SaveChangesAsync();

        //     return Ok(await _context.AreaManagers.ToListAsync());
        // }
    }
}