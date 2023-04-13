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
    public class ManagerListsController : ControllerBase
    {
        private readonly ManagerListContext _context;

        public ManagerListsController(ManagerListContext context)
        {
            _context = context;
        }

        // GET: api/ManagerLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerList>>> GetManagerList()
        {
          if (_context.ManagerList == null)
          {
              return NotFound();
          }
            return await _context.ManagerList.ToListAsync();
        }

        // GET: api/ManagerLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerList>> GetManagerList(int id)
        {
          if (_context.ManagerList == null)
          {
              return NotFound();
          }
            var managerList = await _context.ManagerList.FindAsync(id);

            if (managerList == null)
            {
                return NotFound();
            }

            return managerList;
        }

        // PUT: api/ManagerLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagerList(int id, ManagerList managerList)
        {
            if (id != managerList.id)
            {
                return BadRequest();
            }

            _context.Entry(managerList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerListExists(id))
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

        // POST: api/ManagerLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagerList>> PostManagerList(ManagerList managerList)
        {
          if (_context.ManagerList == null)
          {
              return Problem("Entity set 'ManagerListContext.ManagerList'  is null.");
          }
            _context.ManagerList.Add(managerList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagerList", new { id = managerList.id }, managerList);
        }

        // DELETE: api/ManagerLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagerList(int id)
        {
            if (_context.ManagerList == null)
            {
                return NotFound();
            }
            var managerList = await _context.ManagerList.FindAsync(id);
            if (managerList == null)
            {
                return NotFound();
            }

            _context.ManagerList.Remove(managerList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagerListExists(int id)
        {
            return (_context.ManagerList?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
