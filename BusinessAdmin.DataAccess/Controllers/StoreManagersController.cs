using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessAdmin.DataAccess.Data;
using BusinessAdmin.DataAccess.Models;

namespace BusinessAdmin.DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreManagersController : ControllerBase
    {
        private readonly StoreManagerContext _context;

        public StoreManagersController(StoreManagerContext context)
        {
            _context = context;
        }

        // GET: api/StoreManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreManager>>> GetStoreManager()
        {
          if (_context.StoreManager == null)
          {
              return NotFound();
          }
            return await _context.StoreManager.ToListAsync();
        }

        // GET: api/StoreManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreManager>> GetStoreManager(int id)
        {
          if (_context.StoreManager == null)
          {
              return NotFound();
          }
            var storeManager = await _context.StoreManager.FindAsync(id);

            if (storeManager == null)
            {
                return NotFound();
            }

            return storeManager;
        }

        // PUT: api/StoreManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreManager(int id, StoreManager storeManager)
        {
            if (id != storeManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(storeManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreManagerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StoreManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoreManager>> PostStoreManager(StoreManager storeManager)
        {
          if (_context.StoreManager == null)
          {
              return Problem("Entity set 'StoreManagerContext.StoreManager'  is null.");
          }
            _context.StoreManager.Add(storeManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoreManager", new { id = storeManager.Id }, storeManager);
        }

        // DELETE: api/StoreManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoreManager(int id)
        {
            if (_context.StoreManager == null)
            {
                return NotFound();
            }
            var storeManager = await _context.StoreManager.FindAsync(id);
            if (storeManager == null)
            {
                return NotFound();
            }

            _context.StoreManager.Remove(storeManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoreManagerExists(int id)
        {
            return (_context.StoreManager?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
