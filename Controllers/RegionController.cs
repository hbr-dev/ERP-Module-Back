using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {

        private readonly DataContext _context;

        public RegionController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Region>>> GetRegions()
        {
            return Ok(await _context.Regions.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Region>>> CreateRegion(Region region)
        {
            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return Ok(await _context.Regions.ToListAsync());
        }
        
    }
}