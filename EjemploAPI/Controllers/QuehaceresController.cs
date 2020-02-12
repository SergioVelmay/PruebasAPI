using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjemploAPI.Models;

namespace EjemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuehaceresController : ControllerBase
    {
        private readonly ContextoQuehacer _context;

        public QuehaceresController(ContextoQuehacer context)
        {
            _context = context;
        }

        // GET: api/Quehaceres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quehacer>>> GetQuehaceres()
        {
            return await _context.Quehaceres.ToListAsync();
        }

        // GET: api/Quehaceres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quehacer>> GetQuehacer(long id)
        {
            var quehacer = await _context.Quehaceres.FindAsync(id);

            if (quehacer == null)
            {
                return NotFound();
            }

            return quehacer;
        }

        // POST: api/Quehaceres
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Quehacer>> PostQuehacer(Quehacer quehacer)
        {
            _context.Quehaceres.Add(quehacer);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetQuehacer", new { id = quehacer.Id }, quehacer);
            return CreatedAtAction(nameof(GetQuehacer), new { id = quehacer.Id }, quehacer);
        }

        // PUT: api/Quehaceres/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuehacer(long id, Quehacer quehacer)
        {
            if (id != quehacer.Id)
            {
                return BadRequest();
            }

            _context.Entry(quehacer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuehacerExists(id))
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

        // PATCH: api/Quehaceres/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchQuehacer(long id, Quehacer quehacer)
        {
            if (id != quehacer.Id)
            {
                return BadRequest();
            }

            _context.Entry(quehacer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuehacerExists(id))
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

        // DELETE: api/Quehaceres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Quehacer>> DeleteQuehacer(long id)
        {
            var quehacer = await _context.Quehaceres.FindAsync(id);
            if (quehacer == null)
            {
                return NotFound();
            }

            _context.Quehaceres.Remove(quehacer);
            await _context.SaveChangesAsync();

            return quehacer;
        }

        private bool QuehacerExists(long id)
        {
            return _context.Quehaceres.Any(e => e.Id == id);
        }
    }
}

//[
//    {
//        "id": 1,
//        "nombre": "pasear al perro",
//        "completado": true
//    },
//    {
//        "id": 2,
//        "nombre": "sacar la basura",
//        "completado": false
//    },
//    {
//        "id": 3,
//        "nombre": "hacer la compra",
//        "completado": true
//    },
//    {
//        "id": 4,
//        "nombre": "lavar el coche",
//        "completado": false
//    }
//]