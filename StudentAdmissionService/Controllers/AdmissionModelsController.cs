using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAdmissionService.Data;
using StudentAdmissionService.Models;

namespace StudentAdmissionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionModelsController : ControllerBase
    {
        private readonly StudentAdmissionServiceContext _context;

        public AdmissionModelsController(StudentAdmissionServiceContext context)
        {
            _context = context;
        }

        // GET: api/AdmissionModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdmissionModel>>> GetAdmissionModel()
        {
            return await _context.AdmissionModel.ToListAsync();
        }

        // GET: api/AdmissionModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdmissionModel>> GetAdmissionModel(int id)
        {
            var admissionModel = await _context.AdmissionModel.FindAsync(id);

            if (admissionModel == null)
            {
                return NotFound();
            }

            return admissionModel;
        }

        // PUT: api/AdmissionModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmissionModel(int id, AdmissionModel admissionModel)
        {
            if (id != admissionModel.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(admissionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdmissionModelExists(id))
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

        // POST: api/AdmissionModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdmissionModel>> PostAdmissionModel(AdmissionModel admissionModel)
        {
            _context.AdmissionModel.Add(admissionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmissionModel", new { id = admissionModel.StudentID }, admissionModel);
        }

        // DELETE: api/AdmissionModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmissionModel(int id)
        {
            var admissionModel = await _context.AdmissionModel.FindAsync(id);
            if (admissionModel == null)
            {
                return NotFound();
            }

            _context.AdmissionModel.Remove(admissionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdmissionModelExists(int id)
        {
            return _context.AdmissionModel.Any(e => e.StudentID == id);
        }
    }
}
