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
    public class FormFieldsController : ControllerBase
    {
        private readonly DataContext _context;

        public FormFieldsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FormFields
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormField>>> GetFormFields()
        {
            return await _context.FormFields.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FormField>> GetFormField(int id)
        {
            var formField = await _context.FormFields.FindAsync(id);

            if (formField == null)
            {
                return NotFound();
            }

            return formField;
        }

        // PUT: api/FormFields/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormField(int id, FormField formField)
        {
            if (id != formField.Id)
            {
                return BadRequest();
            }

            _context.Entry(formField).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormFieldExists(id))
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

        // POST: api/FormFields
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormField>> PostFormField(FormField formField)
        {
            _context.FormFields.Add(formField);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormField", new { id = formField.Id }, formField);
        }

        // DELETE: api/FormFields/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormField(int id)
        {
            var formField = await _context.FormFields.FindAsync(id);
            if (formField == null)
            {
                return NotFound();
            }

            _context.FormFields.Remove(formField);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormFieldExists(int id)
        {
            return _context.FormFields.Any(e => e.Id == id);
        }
    }
}
