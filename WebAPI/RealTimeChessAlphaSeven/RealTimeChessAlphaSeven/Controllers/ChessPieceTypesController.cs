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
    [Route("api/ChessPieceTypes")]
    public class ChessPieceTypesController : Controller
    {
        private readonly RealTimeChessDbContext _context;

        public ChessPieceTypesController(RealTimeChessDbContext context)
        {
            _context = context;
        }

        // GET: api/ChessPieceTypes
        [HttpGet]
        public IEnumerable<ChessPieceType> GetChessPieceType()
        {
            return _context.ChessPieceType;
        }

        // GET: api/ChessPieceTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ChessPieceType), 200)]
        public async Task<IActionResult> GetChessPieceType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chessPieceType = await _context.ChessPieceType.SingleOrDefaultAsync(m => m.ChessPieceTypeId == id);

            if (chessPieceType == null)
            {
                return NotFound();
            }

            return Ok(chessPieceType);
        }

        // PUT: api/ChessPieceTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 204)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> PutChessPieceType([FromRoute] int id, [FromBody] ChessPieceType chessPieceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chessPieceType.ChessPieceTypeId)
            {
                return BadRequest();
            }

            _context.Entry(chessPieceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChessPieceTypeExists(id))
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

        // POST: api/ChessPieceTypes
        [HttpPost]
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public async Task<IActionResult> PostChessPieceType([FromBody] ChessPieceType chessPieceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ChessPieceType.Add(chessPieceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChessPieceType", new { id = chessPieceType.ChessPieceTypeId }, chessPieceType);
        }

        // DELETE: api/ChessPieceTypes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
        public async Task<IActionResult> DeleteChessPieceType([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chessPieceType = await _context.ChessPieceType.SingleOrDefaultAsync(m => m.ChessPieceTypeId == id);
            if (chessPieceType == null)
            {
                return NotFound();
            }

            _context.ChessPieceType.Remove(chessPieceType);
            await _context.SaveChangesAsync();

            return Ok(chessPieceType);
        }

        private bool ChessPieceTypeExists(int id)
        {
            return _context.ChessPieceType.Any(e => e.ChessPieceTypeId == id);
        }
    }
}