using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BackEnd.Data;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {

        private readonly DataContext _context;

        public StoreController(DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<Store>>> GetStores()
        {
            return Ok(await _context.Stores.ToListAsync());                                                              
        }



        [HttpPost]
        public async Task<ActionResult<List<Store>>> CreateStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();

            return Ok(await _context.Stores.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<List<Store>>> UpdateStore(Store store)
        {
            var dbStore = await _context.Stores.FindAsync(store.Id);
            if (dbStore == null)
            {
                return BadRequest("Store not found");
            }

            dbStore.Name = store.Name;
            dbStore.Address = store.Address;
            dbStore.Belongs_to = store.Belongs_to;
            dbStore.Group_id = store.Group_id;

            await _context.SaveChangesAsync();

            return Ok(await _context.Stores.ToListAsync());
        }



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