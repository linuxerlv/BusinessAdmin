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
    public class TradeListsController : ControllerBase
    {
        private readonly TradeListContext _context;

        public TradeListsController(TradeListContext context)
        {
            _context = context;
        }

        // GET: api/TradeLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeList>>> GetTradeList()
        {
          if (_context.TradeList == null)
          {
              return NotFound();
          }
            return await _context.TradeList.ToListAsync();
        }

        // GET: api/TradeLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeList>> GetTradeList(int id)
        {
          if (_context.TradeList == null)
          {
              return NotFound();
          }
            var tradeList = await _context.TradeList.FindAsync(id);

            if (tradeList == null)
            {
                return NotFound();
            }

            return tradeList;
        }

        // PUT: api/TradeLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeList(int id, TradeList tradeList)
        {
            if (id != tradeList.Id)
            {
                return BadRequest();
            }

            _context.Entry(tradeList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeListExists(id))
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

        // POST: api/TradeLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeList>> PostTradeList(TradeList tradeList)
        {
          if (_context.TradeList == null)
          {
              return Problem("Entity set 'TradeListContext.TradeList'  is null.");
          }
            _context.TradeList.Add(tradeList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeList", new { id = tradeList.Id }, tradeList);
        }

        // DELETE: api/TradeLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeList(int id)
        {
            if (_context.TradeList == null)
            {
                return NotFound();
            }
            var tradeList = await _context.TradeList.FindAsync(id);
            if (tradeList == null)
            {
                return NotFound();
            }

            _context.TradeList.Remove(tradeList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeListExists(int id)
        {
            return (_context.TradeList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
