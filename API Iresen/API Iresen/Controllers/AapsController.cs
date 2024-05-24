using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen;
using API_Iresen.Data;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AapsController : ControllerBase
    {
        private readonly DataContext _context;

        public AapsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Aaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aap>>> GetAaps()
        {
            return await _context.Aaps.ToListAsync();
        }

        // GET: api/Aaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aap>> GetAap(int id)
        {
            var aap = await _context.Aaps.FindAsync(id);

            if (aap == null)
            {
                return NotFound();
            }

            return aap;
        }

        // PUT: api/Aaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAap(int id, Aap aap)
        {
            if (id != aap.Id)
            {
                return BadRequest();
            }

            _context.Entry(aap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AapExists(id))
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

        // POST: api/Aaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aap>> PostAap(Aap aap)
        {
            _context.Aaps.Add(aap);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAap", new { id = aap.Id }, aap);
        }

        // DELETE: api/Aaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAap(int id)
        {
            var aap = await _context.Aaps.FindAsync(id);
            if (aap == null)
            {
                return NotFound();
            }

            _context.Aaps.Remove(aap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AapExists(int id)
        {
            return _context.Aaps.Any(e => e.Id == id);
        }
    }
}
