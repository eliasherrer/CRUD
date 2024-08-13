using CRUD.DTOs;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreController : ControllerBase
    {
        private StoreContext _context;

        public PreController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<IEnumerable<PreDto>> Get() =>
            await _context.PreWorkouts.Select(P => new PreDto
            {
                PreId = P.PreId,
                Description = P.Description,
                flavor = P.flavor,
            }).ToListAsync();

        [HttpGet("{id}")]

        public async Task<ActionResult<PreDto>> GetById(int id)
        {
            var pre = await _context.PreWorkouts.FindAsync(id);

            if (pre == null)
            {
                return NotFound();
            }

            var preDto = new PreDto
            {
                PreId = pre.PreId,
                Description = pre.Description,
                flavor = pre.flavor,
            };

            return Ok(preDto);
        }

        [HttpPost]

        public async Task<ActionResult<PreDto>> Add(PreInsertDto preInsertDto)
        {
            var pre = new PreWorkouts()
            {
                Description = preInsertDto.Description,
                flavor = preInsertDto.flavor,
            };

            await _context.PreWorkouts.AddAsync(pre);
            await _context.SaveChangesAsync();

            var preDto = new PreDto
            {
                PreId = pre.PreId,
                Description = pre.Description,
                flavor = pre.flavor,
            };

            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<PreDto>> Update(int id, PreUpdateDto preUpdateDto)
        {
            var pre = await _context.PreWorkouts.FindAsync(id);

            if (pre == null)
            {
                return NotFound();
            }

            pre.Description = preUpdateDto.Description;
            pre.flavor = preUpdateDto.flavor;
            await _context.SaveChangesAsync();

            var preDto = new PreDto
            {
                PreId = pre.PreId,
                Description = pre.Description,
                flavor = pre.flavor,
            };

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var delete = await _context.PreWorkouts.FindAsync(id);

            if (delete == null)
            {
                return NoContent();
            }

            _context.PreWorkouts.Remove(delete);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
