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
    public class ManagerReqListsController : ControllerBase
    {
        private readonly ManagerReqListContext _context;

        public ManagerReqListsController(ManagerReqListContext context)
        {
            _context = context;
        }

        // GET: api/ManagerReqLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagerReqList>>> GetManagerReqList()
        {
          if (_context.ManagerReqList == null)
          {
              return NotFound();
          }
            return await _context.ManagerReqList.ToListAsync();
        }

        // GET: api/ManagerReqLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagerReqList>> GetManagerReqList(int id)
        {
          if (_context.ManagerReqList == null)
          {
              return NotFound();
          }
            var managerReqList = await _context.ManagerReqList.FindAsync(id);

            if (managerReqList == null)
            {
                return NotFound();
            }

            return managerReqList;
        }

        // PUT: api/ManagerReqLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagerReqList(int id, ManagerReqList managerReqList)
        {
            if (id != managerReqList.Id)
            {
                return BadRequest();
            }

            _context.Entry(managerReqList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagerReqListExists(id))
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

        // POST: api/ManagerReqLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagerReqList>> PostManagerReqList(ManagerReqList managerReqList)
        {
          if (_context.ManagerReqList == null)
          {
              return Problem("Entity set 'ManagerReqListContext.ManagerReqList'  is null.");
          }
            _context.ManagerReqList.Add(managerReqList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManagerReqList", new { id = managerReqList.Id }, managerReqList);
        }

        // DELETE: api/ManagerReqLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagerReqList(int id)
        {
            if (_context.ManagerReqList == null)
            {
                return NotFound();
            }
            var managerReqList = await _context.ManagerReqList.FindAsync(id);
            if (managerReqList == null)
            {
                return NotFound();
            }

            _context.ManagerReqList.Remove(managerReqList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagerReqListExists(int id)
        {
            return (_context.ManagerReqList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
