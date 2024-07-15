using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Iresen.Models;
using API_Iresen.Data;

namespace API_Iresen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly DataContext _context;

        public EvaluationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Evaluations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations()
        {
            return await _context.Evaluations.ToListAsync();
        }
        // GET: api/Evaluations
        [HttpGet("criteria")]
        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluationsWithCriteria()
        {
            return await _context.Evaluations
                .Include(e => e.Criteria)
                .ToListAsync();
        }
        [HttpGet("criteria/{id}")]
        public async Task<ActionResult<Evaluation>> GetEvaluationWithCriteria(int id)
        {
            var evaluation = await _context.Evaluations
                .Include(e => e.Criteria)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return evaluation;
        }

        // GET: api/Evaluations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluation>> GetEvaluation(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);

            if (evaluation == null)
            {
                return NotFound();
            }

            return evaluation;
        }

        // PUT: api/Evaluations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvaluation(int id, Evaluation evaluation)
        {
            if (id != evaluation.Id)
            {
                return BadRequest();
            }

            _context.Entry(evaluation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvaluationExists(id))
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
        // POST: api/EvaluationNotes
        [HttpPost("evaluationNote")]
        public async Task<ActionResult<EvaluationNote>> PostEvaluationNote(
            [FromBody] EvaluationNote evaluationNote)
        {
            _context.EvaluationNotes.Add(evaluationNote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluationNote", new { id = evaluationNote.Id }, evaluationNote);
        }

        // GET: api/EvaluationNotes/5
        [HttpGet("evaluationNote/{id}")]
        public async Task<ActionResult<EvaluationNote>> GetEvaluationNote(
            int id)
        {
            var evaluationNote = await _context.EvaluationNotes
                .Include(en => en.CriteriaNotes)
                .FirstOrDefaultAsync(en => en.Id == id);

            if (evaluationNote == null)
            {
                return NotFound();
            }

            return evaluationNote;
        }
        [HttpGet("project/{projectId}/criteria")]
        public async Task<ActionResult<IEnumerable<EvaluationCriterion>>> GetEvaluationCriteriaForProject(int projectId)
        {
            var project = await _context.Projects.Include(p => p.Evaluation).ThenInclude(e => e.Criteria).FirstOrDefaultAsync(p => p.Id == projectId);

            if (project == null || project.Evaluation == null)
            {
                return NotFound();
            }

            return project.Evaluation.Criteria.ToList();
        }

        [HttpPut("submissions/{id}")]
        public async Task<IActionResult> UpdateSubmission(int id, Submission submission)
        {
            if (id != submission.Id)
            {
                return BadRequest();
            }

            _context.Entry(submission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubmissionExists(id))
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

        private bool SubmissionExists(int id)
        {
            return _context.Submissions.Any(e => e.Id == id);
        }

        // POST: api/Evaluations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Evaluation>> PostEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvaluation", new { id = evaluation.Id }, evaluation);
        }

        // DELETE: api/Evaluations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluation(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }

            _context.Evaluations.Remove(evaluation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluations.Any(e => e.Id == id);
        }
    }
}
