using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubRegionController : ControllerBase
    {

        private readonly DataContext _context;

        public SubRegionController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<SubRegion>>> GetSubRegions()
        {
            return Ok(await _context.SubRegions.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<SubRegion>>> CreateSubRegion(SubRegion subRegion)
        {
            _context.SubRegions.Add(subRegion);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubRegions.ToListAsync());
        }
    }
}