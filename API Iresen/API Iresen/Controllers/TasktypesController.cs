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
    public class TasktypesController : ControllerBase
    {
        private readonly DataContext _context;

        public TasktypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tasktypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasktype>>> GetTasktypes()
        {
            return await _context.Tasktypes.ToListAsync();
        }

        // GET: api/Tasktypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasktype>> GetTasktype(int id)
        {
            var tasktype = await _context.Tasktypes.FindAsync(id);

            if (tasktype == null)
            {
                return NotFound();
            }

            return tasktype;
        }

        // PUT: api/Tasktypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasktype(int id, Tasktype tasktype)
        {
            if (id != tasktype.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasktype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasktypeExists(id))
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

        // POST: api/Tasktypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tasktype>> PostTasktype(Tasktype tasktype)
        {
            _context.Tasktypes.Add(tasktype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasktype", new { id = tasktype.Id }, tasktype);
        }

        // DELETE: api/Tasktypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasktype(int id)
        {
            var tasktype = await _context.Tasktypes.FindAsync(id);
            if (tasktype == null)
            {
                return NotFound();
            }

            _context.Tasktypes.Remove(tasktype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TasktypeExists(int id)
        {
            return _context.Tasktypes.Any(e => e.Id == id);
        }
    }
}
