using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Entregas;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntregasController : ControllerBase
    {
        private readonly EntregaService _service;

        public EntregasController(EntregaService service)
        {
            _service = service;
        }

       // GET: api/Entregas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Entregas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntregaDto>> GetGetById(string id)
        {
            var ent = await _service.GetByIdAsync(new EntregaId(new Guid(id)));

            if (ent == null)
            {
                return NotFound();
            }

            return ent;
        }


        // GET: api/Entregas/5/6
        [HttpGet("entregasByArmazem/{id}")]
        public async Task<ActionResult<IEnumerable<EntregaDto>>> GetEntregasByArmazem(string id)
        {
            var ent = await _service.GetByArmazemId(new ArmazemId(new Guid(id)));

            if (ent == null)
            {
                return NotFound();
            }

            return ent;
        }

        // POST: api/Entregas
        [HttpPost]
        public async Task<ActionResult<EntregaDto>> Create(CreatingEntregaDto dto)
        {
            var ent = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = ent.Id }, ent);
        }

        
        // PUT: api/Entregas/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EntregaDto>> Update(Guid id, EntregaDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var ent = await _service.UpdateAsync(dto);
                
                if (ent == null)
                {
                    return NotFound();
                }
                return Ok(ent);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Entregas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EntregaDto>> SoftDelete(Guid id)
        {
            var ent = await _service.InactivateAsync(new EntregaId(id));

            if (ent == null)
            {
                return NotFound();
            }

            return Ok(ent);
        }
        
        // DELETE: api/Entregas/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<EntregaDto>> HardDelete(Guid id)
        {
            try
            {
                var ent = await _service.DeleteAsync(new EntregaId(id));

                if (ent == null)
                {
                    return NotFound();
                }

                return Ok(ent);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}