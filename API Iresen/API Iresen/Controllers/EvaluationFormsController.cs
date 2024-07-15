using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen.Data;
using API_Iresen.Models;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationFormsController : ControllerBase
    {
        private readonly DataContext _context;

        public EvaluationFormsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EvaluationForms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EvaluationForm>>> GetEvaluationForms()
        {
            return await _context.EvaluationForms
                .Include(ef => ef.Steps)
                    .ThenInclude(s => s.Fields)
                .ToListAsync();
        }

        // GET: api/EvaluationForms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EvaluationForm>> GetEvaluationForm(int id)
        {
            var evaluationForm = await _context.EvaluationForms
                .Include(ef => ef.Steps)
                    .ThenInclude(s => s.Fields)
                .FirstOrDefaultAsync(ef => ef.Id == id);

            if (evaluationForm == null)
            {
                return NotFound();
            }

            return evaluationForm;
        }

        // PUT: api/EvaluationForms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluationForm(int id, EvaluationForm evaluationForm)
        {
            if (id != evaluationForm.Id)
            {
                return BadRequest();
            }

            _context.Entry(evaluationForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationFormExists(id))
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

        // POST: api/EvaluationForms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EvaluationForm>> PostEvaluationForm(EvaluationForm evaluationForm)
        {
            _context.EvaluationForms.Add(evaluationForm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluationForm", new { id = evaluationForm.Id }, evaluationForm);
        }

        // DELETE: api/EvaluationForms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluationForm(int id)
        {
            var evaluationForm = await _context.EvaluationForms.FindAsync(id);
            if (evaluationForm == null)
            {
                return NotFound();
            }

            _context.EvaluationForms.Remove(evaluationForm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluationFormExists(int id)
        {
            return _context.EvaluationForms.Any(e => e.Id == id);
        }
    }
}
