using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RotuladoresDomain.Services;
using RotuladoresDTO;

namespace EjemploAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RotuladoresController : ControllerBase
    {
        private readonly IRotuladorService _rotuladorService;

        public RotuladoresController(IRotuladorService rotuladorService)
        {
            _rotuladorService = rotuladorService;
        }

        // GET: api/Rotuladores
        [HttpGet]
        public ActionResult<IEnumerable<RotuladorDTO>> Read()
        {
           return _rotuladorService.Get();
        }

        // GET: api/Rotuladores/5
        [HttpGet("{id:length(24)}", Name = "ReadRotulador")]
        public ActionResult<RotuladorDTO> Read(string id)
        {
            var rotulador = _rotuladorService.Get(id);

            if (rotulador == null)
            {
                return NotFound();
            }

            return rotulador;
        }

        // POST: api/Rotuladores
        [HttpPost]
        public ActionResult<RotuladorDTO> Create(RotuladorDTO rotulador)
        {
            RotuladorDTO rotuladorDTO = _rotuladorService.Create(rotulador);

            return CreatedAtRoute("ReadRotulador", new { id = rotuladorDTO.Id.ToString() }, rotuladorDTO);
        }

        // PUT: api/Rotuladores/5
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, RotuladorDTO rotuladorIn)
        {
            var rotulador = _rotuladorService.Get(id);

            if (rotulador == null)
            {
                return NotFound();
            }

            _rotuladorService.Update(id, rotuladorIn);

            return NoContent();
        }

        // DELETE: api/Rotuladores/5
        [HttpDelete("{id:length(24)}")]
        public ActionResult<RotuladorDTO> DeleteRotulador(string id)
        {
            var rotulador = _rotuladorService.Get(id);

            if (rotulador == null)
            {
                return NotFound();
            }

            _rotuladorService.Remove(rotulador);

            return NoContent();
        }
    }
}
