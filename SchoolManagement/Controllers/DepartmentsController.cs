using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly FgfgContext _context;

        public DepartmentsController(FgfgContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDepartment>>> GetTblDepartments()
        {
            if (_context.TblDepartments == null)
            {
                return NotFound();
            }
            return await _context.TblDepartments.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDepartment>> GetTblDepartment(long id)
        {
            if (_context.TblDepartments == null)
            {
                return NotFound();
            }
            var tblDepartment = await _context.TblDepartments.FindAsync(id);

            if (tblDepartment == null)
            {
                return NotFound();
            }

            return tblDepartment;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDepartment(long id, TblDepartment tblDepartment)
        {
            if (id != tblDepartment.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(tblDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDepartment>> PostTblDepartment(TblDepartment tblDepartment)
        {
            if (_context.TblDepartments == null)
            {
                return Problem("Entity set 'FgfgContext.TblDepartments'  is null.");
            }
            _context.TblDepartments.Add(tblDepartment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDepartment", new { id = tblDepartment.DepartmentId }, tblDepartment);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDepartment(long id)
        {
            if (_context.TblDepartments == null)
            {
                return NotFound();
            }
            var tblDepartment = await _context.TblDepartments.FindAsync(id);
            if (tblDepartment == null)
            {
                return NotFound();
            }

            _context.TblDepartments.Remove(tblDepartment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDepartmentExists(long id)
        {
            return (_context.TblDepartments?.Any(e => e.DepartmentId == id)).GetValueOrDefault();
        }
    }
}
