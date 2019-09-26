using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TexasRealTimeChess.Models.RealTimeChessModels;

namespace TexasRealTimeChess.Controllers
{
    [Produces("application/json")]
    [Route("api/ChessPieces")]
    public class ChessPiecesController : Controller
    {
        private readonly RealTimeChessDbContext _context;

        public ChessPiecesController(RealTimeChessDbContext context)
        {
            _context = context;
        }

        // GET: api/ChessPieces
        [HttpGet]
        public IEnumerable<ChessPiece> GetChessPiece()
        {
            return _context.ChessPiece;
        }

        // GET: api/ChessPieces/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ChessPiece), 200)]
        public async Task<IActionResult> GetChessPiece([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chessPiece = await _context.ChessPiece.SingleOrDefaultAsync(m => m.ChessPieceId == id);

            if (chessPiece == null)
            {
                return NotFound();
            }

            return Ok(chessPiece);
        }

        // PUT: api/ChessPieces/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 204)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> PutChessPiece([FromRoute] int id, [FromBody] ChessPiece chessPiece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chessPiece.ChessPieceId)
            {
                return BadRequest();
            }

            _context.Entry(chessPiece).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChessPieceExists(id))
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

        // POST: api/ChessPieces
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public async Task<IActionResult> PostChessPiece([FromBody] ChessPiece chessPiece)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChessPiece.Add(chessPiece);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChessPiece", new { id = chessPiece.ChessPieceId }, chessPiece);
        }

        // DELETE: api/ChessPieces/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> DeleteChessPiece([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chessPiece = await _context.ChessPiece.SingleOrDefaultAsync(m => m.ChessPieceId == id);
            if (chessPiece == null)
            {
                return NotFound();
            }

            _context.ChessPiece.Remove(chessPiece);
            await _context.SaveChangesAsync();

            return Ok(chessPiece);
        }

        private bool ChessPieceExists(int id)
        {
            return _context.ChessPiece.Any(e => e.ChessPieceId == id);
        }
    }
}