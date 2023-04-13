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
    public class OrderFormsController : ControllerBase
    {
        private readonly OrderFormContext _context;

        public OrderFormsController(OrderFormContext context)
        {
            _context = context;
        }

        // GET: api/OrderForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderForm>>> GetOrderForm()
        {
          if (_context.OrderForm == null)
          {
              return NotFound();
          }
            return await _context.OrderForm.ToListAsync();
        }

        // GET: api/OrderForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderForm>> GetOrderForm(uint id)
        {
          if (_context.OrderForm == null)
          {
              return NotFound();
          }
            var orderForm = await _context.OrderForm.FindAsync(id);

            if (orderForm == null)
            {
                return NotFound();
            }

            return orderForm;
        }

        // PUT: api/OrderForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderForm(uint id, OrderForm orderForm)
        {
            if (id != orderForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(orderForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderFormExists(id))
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

        // POST: api/OrderForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderForm>> PostOrderForm(OrderForm orderForm)
        {
          if (_context.OrderForm == null)
          {
              return Problem("Entity set 'OrderFormContext.OrderForm'  is null.");
          }
            _context.OrderForm.Add(orderForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderForm", new { id = orderForm.Id }, orderForm);
        }

        // DELETE: api/OrderForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderForm(uint id)
        {
            if (_context.OrderForm == null)
            {
                return NotFound();
            }
            var orderForm = await _context.OrderForm.FindAsync(id);
            if (orderForm == null)
            {
                return NotFound();
            }

            _context.OrderForm.Remove(orderForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderFormExists(uint id)
        {
            return (_context.OrderForm?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
