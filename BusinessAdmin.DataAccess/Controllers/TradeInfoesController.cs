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
    public class TradeInfoesController : ControllerBase
    {
        private readonly TradeInfoContext _context;

        public TradeInfoesController(TradeInfoContext context)
        {
            _context = context;
        }

        // GET: api/TradeInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeInfo>>> GetTradeInfo()
        {
          if (_context.TradeInfo == null)
          {
              return NotFound();
          }
            return await _context.TradeInfo.ToListAsync();
        }

        // GET: api/TradeInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeInfo>> GetTradeInfo(int id)
        {
          if (_context.TradeInfo == null)
          {
              return NotFound();
          }
            var tradeInfo = await _context.TradeInfo.FindAsync(id);

            if (tradeInfo == null)
            {
                return NotFound();
            }

            return tradeInfo;
        }

        // PUT: api/TradeInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeInfo(int id, TradeInfo tradeInfo)
        {
            if (id != tradeInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(tradeInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeInfoExists(id))
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

        // POST: api/TradeInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeInfo>> PostTradeInfo(TradeInfo tradeInfo)
        {
          if (_context.TradeInfo == null)
          {
              return Problem("Entity set 'TradeInfoContext.TradeInfo'  is null.");
          }
            _context.TradeInfo.Add(tradeInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeInfo", new { id = tradeInfo.Id }, tradeInfo);
        }

        // DELETE: api/TradeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeInfo(int id)
        {
            if (_context.TradeInfo == null)
            {
                return NotFound();
            }
            var tradeInfo = await _context.TradeInfo.FindAsync(id);
            if (tradeInfo == null)
            {
                return NotFound();
            }

            _context.TradeInfo.Remove(tradeInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeInfoExists(int id)
        {
            return (_context.TradeInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
