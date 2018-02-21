using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealTimeChessAlphaSeven.Models.RealTimeChessModels;

namespace RealTimeChessAlphaSeven.Controllers
{
    [Produces("application/json")]
    [Route("api/Moves")]
    public class MovesController : Controller
    {
        private readonly RealTimeChessDbContext _context;

        public MovesController(RealTimeChessDbContext context)
        {
            _context = context;
        }

        // GET: api/Moves
        [HttpGet]
        public IEnumerable<Move> GetMoves()
        {
            return _context.Moves;
        }

        // GET: api/Moves/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMove([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var move = await _context.Moves.SingleOrDefaultAsync(m => m.MoveId == id);

            if (move == null)
            {
                return NotFound();
            }

            return Ok(move);
        }

        // PUT: api/Moves/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMove([FromRoute] int id, [FromBody] Move move)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != move.MoveId)
            {
                return BadRequest();
            }

            _context.Entry(move).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoveExists(id))
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

        // POST: api/Moves
        [HttpPost]
        public async Task<IActionResult> PostMove([FromBody] Move move)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Moves.Add(move);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = move.MoveId }, move);
        }

        // DELETE: api/Moves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMove([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var move = await _context.Moves.SingleOrDefaultAsync(m => m.MoveId == id);
            if (move == null)
            {
                return NotFound();
            }

            _context.Moves.Remove(move);
            await _context.SaveChangesAsync();

            return Ok(move);
        }

        private bool MoveExists(int id)
        {
            return _context.Moves.Any(e => e.MoveId == id);
        }
    }
}