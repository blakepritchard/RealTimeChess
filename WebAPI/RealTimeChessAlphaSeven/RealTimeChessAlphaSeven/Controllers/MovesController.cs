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
        [ProducesResponseType(typeof(Move), 200)]
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
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 204)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
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
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
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


        // POST: api/Moves
        [HttpPost("BeginMove")]
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public async Task<IActionResult> BeginMove([FromQuery] int PieceId,  [FromQuery] int DestinationX, [FromQuery] int DestinationY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Move move = new Move(PieceId, DestinationX, DestinationY, ChessMatch.ChessPieceVelocity);
            _context.Moves.Add(move);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMove", new { id = move.MoveId }, move);
        }


        // DELETE: api/Moves/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), 200)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        [ProducesResponseType(typeof(IActionResult), 404)]
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


        /*
         * 
         *         // POST: api/ChessMatches
        [HttpPost("{ChessMatchId}/MovePiece/{PieceId}")]
        [ProducesResponseType(typeof(IActionResult), 201)]
        [ProducesResponseType(typeof(IActionResult), 400)]
        public async Task<IActionResult> MovePiece([FromRoute] int ChessMatchId, [FromRoute] int PieceId, [FromQuery] int DestinationX, [FromQuery] int DestinationY )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            ChessMatch chessMatch = await _context.Matches.SingleOrDefaultAsync(m => m.ChessMatchId == ChessMatchId);
            ChessPiece pieceMoved = await _context.ChessPiece.SingleOrDefaultAsync(p => p.ChessPieceId == PieceId);
            if (null == chessMatch || null == pieceMoved)
            {
                return NotFound();
            }


            //pieceMoved.BeginMove(DestinationX, DestinationY);
            await _context.SaveChangesAsync();
            // Timer timerMovePiece = new Timer();

            return Ok(chessMatch);
        }
         * 
         */
    }
}