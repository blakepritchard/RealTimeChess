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
    [Route("api/ChessMatches")]
    public class ChessMatchesController : Controller
    {
        private readonly RealTimeChessDbContext _context;

        public ChessMatchesController(RealTimeChessDbContext context)
        {
            _context = context;
        }

        // GET: api/ChessMatches
        [HttpGet]
        public IEnumerable<ChessMatch> GetMatches()
        {
            return _context.Matches;
        }

        // GET: api/ChessMatches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChessMatch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chessMatch = await _context.Matches.SingleOrDefaultAsync(m => m.ChessMatchId == id);

            if (chessMatch == null)
            {
                return NotFound();
            }

            return Ok(chessMatch);
        }

        // PUT: api/ChessMatches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChessMatch([FromRoute] int id, [FromBody] ChessMatch chessMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chessMatch.ChessMatchId)
            {
                return BadRequest();
            }

            _context.Entry(chessMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChessMatchExists(id))
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

        // POST: api/ChessMatches
        [HttpPost]
        public async Task<IActionResult> PostChessMatch([FromBody] ChessMatch chessMatch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Matches.Add(chessMatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChessMatch", new { id = chessMatch.ChessMatchId }, chessMatch);
        }

        // DELETE: api/ChessMatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChessMatch([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chessMatch = await _context.Matches.SingleOrDefaultAsync(m => m.ChessMatchId == id);
            if (chessMatch == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(chessMatch);
            await _context.SaveChangesAsync();

            return Ok(chessMatch);
        }

        private bool ChessMatchExists(int id)
        {
            return _context.Matches.Any(e => e.ChessMatchId == id);
        }
    }
}