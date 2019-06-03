using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore.Models;

namespace ASPNETCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly ProblemContext _context;


        public ProblemController(ProblemContext context)
        {
            _context = context;

            if (_context.ProblemItems.Count() == 0)
            {

                _context.ProblemItems.Add(new ProblemItem { Name = "Проблема" });
                _context.SaveChanges();
            }
        }


        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProblemItem>>> GetProblemItems()
        {
            return await _context.ProblemItems.ToListAsync();
        }


        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProblemItem>> GetProblemItem(long id)
        {
            var problemItem = await _context.ProblemItems.FindAsync(id);

            if (problemItem == null)
            {
                return NotFound();
            }

            return problemItem;
        }




        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<ProblemItem>> PostProblemItem(ProblemItem item)
        {
            _context.ProblemItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProblemItem), new { id = item.Id }, item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProblemItem(long id, ProblemItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProblemItem(long id)
        {
            var problemItem = await _context.ProblemItems.FindAsync(id);

            if (problemItem == null)
            {
                return NotFound();
            }

            _context.ProblemItems.Remove(problemItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}