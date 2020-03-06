using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrototypeTableController : ControllerBase
    {
        private readonly PrototypeDBContext _context;

        public PrototypeTableController(PrototypeDBContext context)
        {
            _context = context;
        }

        // GET: api/PrototypeTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrototypeTable>>> GetPrototypeTable()
        {
            return await _context.PrototypeTable.ToListAsync();
        }

        // GET: api/PrototypeTable/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrototypeTable>> GetPrototypeTable(int id)
        {
            var prototypeTable = await _context.PrototypeTable.FindAsync(id);

            if (prototypeTable == null)
            {
                return NotFound();
            }

            return prototypeTable;
        }

        // PUT: api/PrototypeTable/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrototypeTable(int id, PrototypeTable prototypeTable)
        {
            if (id != prototypeTable.PrototypePk)
            {
                return BadRequest();
            }

            _context.Entry(prototypeTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrototypeTableExists(id))
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

        // POST: api/PrototypeTable
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PrototypeTable>> PostPrototypeTable(PrototypeTable prototypeTable)
        {
            _context.PrototypeTable.Add(prototypeTable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrototypeTableExists(prototypeTable.PrototypePk))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPrototypeTable", new { id = prototypeTable.PrototypePk }, prototypeTable);
        }

        // DELETE: api/PrototypeTable/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrototypeTable>> DeletePrototypeTable(int id)
        {
            var prototypeTable = await _context.PrototypeTable.FindAsync(id);
            if (prototypeTable == null)
            {
                return NotFound();
            }

            _context.PrototypeTable.Remove(prototypeTable);
            await _context.SaveChangesAsync();

            return prototypeTable;
        }

        private bool PrototypeTableExists(int id)
        {
            return _context.PrototypeTable.Any(e => e.PrototypePk == id);
        }
    }
}
