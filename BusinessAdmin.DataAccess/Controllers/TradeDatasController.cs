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
    public class TradeDatasController : ControllerBase
    {
        private readonly TraDataContext _context;

        public TradeDatasController(TraDataContext context)
        {
            _context = context;
        }

        // GET: api/TradeDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TradeData>>> GetTradeData()
        {
          if (_context.TradeData == null)
          {
              return NotFound();
          }
            return await _context.TradeData.ToListAsync();
        }

        // GET: api/TradeDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TradeData>> GetTradeData(int id)
        {
          if (_context.TradeData == null)
          {
              return NotFound();
          }
            var tradeData = await _context.TradeData.FindAsync(id);

            if (tradeData == null)
            {
                return NotFound();
            }

            return tradeData;
        }

        // PUT: api/TradeDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTradeData(int id, TradeData tradeData)
        {
            if (id != tradeData.Id)
            {
                return BadRequest();
            }

            _context.Entry(tradeData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TradeDataExists(id))
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

        // POST: api/TradeDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TradeData>> PostTradeData(TradeData tradeData)
        {
          if (_context.TradeData == null)
          {
              return Problem("Entity set 'TraDataContext.TradeData'  is null.");
          }
            _context.TradeData.Add(tradeData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTradeData", new { id = tradeData.Id }, tradeData);
        }

        // DELETE: api/TradeDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTradeData(int id)
        {
            if (_context.TradeData == null)
            {
                return NotFound();
            }
            var tradeData = await _context.TradeData.FindAsync(id);
            if (tradeData == null)
            {
                return NotFound();
            }

            _context.TradeData.Remove(tradeData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TradeDataExists(int id)
        {
            return (_context.TradeData?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
