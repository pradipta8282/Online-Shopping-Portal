using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using casestudy.Model;

namespace casestudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly busycartContext _context;

        public CustomerInfoController(busycartContext context)
        {
            _context = context;
        }

        // GET: api/CustomerInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customerinfo>>> GetCustomerinfos()
        {
            return await _context.Customerinfos.ToListAsync();
        }

        // GET: api/CustomerInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customerinfo>> GetCustomerinfo(string id)
        {
            var customerinfo = await _context.Customerinfos.FindAsync(id);

            if (customerinfo == null)
            {
                return NotFound();
            }

            return customerinfo;
        }

        // PUT: api/CustomerInfo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerinfo(string id, Customerinfo customerinfo)
        {
            if (id != customerinfo.Custid)
            {
                return BadRequest();
            }

            _context.Entry(customerinfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerinfoExists(id))
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

        // POST: api/CustomerInfo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customerinfo>> PostCustomerinfo(Customerinfo customerinfo)
        {
            _context.Customerinfos.Add(customerinfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerinfoExists(customerinfo.Custid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerinfo", new { id = customerinfo.Custid }, customerinfo);
        }

        // DELETE: api/CustomerInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerinfo(string id)
        {
            var customerinfo = await _context.Customerinfos.FindAsync(id);
            if (customerinfo == null)
            {
                return NotFound();
            }

            _context.Customerinfos.Remove(customerinfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerinfoExists(string id)
        {
            return _context.Customerinfos.Any(e => e.Custid == id);
        }
    }
}
