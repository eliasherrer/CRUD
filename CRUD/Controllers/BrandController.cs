using CRUD.DTOs;
using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private StoreContext _context;

        public BrandController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IEnumerable<BrandDto>> Get() =>
            await _context.Brands.Select(B => new BrandDto
            {
                BrandId = B.BrandId,
                BrandName = B.BrandName,
                BrandCountry = B.BrandCountry,
                PreId = B.PreId,
            }).ToListAsync();

        [HttpGet("{id}")]

        public async Task<ActionResult<BrandDto>> GetById(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            var brandDto = new BrandDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                BrandCountry = brand.BrandCountry,
                PreId = brand.PreId,
            };

            return Ok(brandDto);
        }

        [HttpPost]

        public async Task <ActionResult<BrandDto>> Add(BrandInsertDto brandInsertDto)
        {
            var brand = new Brands()
            {
                BrandName = brandInsertDto.BrandName,
                BrandCountry = brandInsertDto.BrandCountry,
                PreId = brandInsertDto.PreId,

            };
           
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            var brandn = new BrandDto
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
                BrandCountry = brand.BrandCountry,
                PreId = brand.PreId,
            };

            return Ok();

        }

        [HttpPut("{id}")]

        public async Task<ActionResult<BrandDto>> Update(int id, BrandUpdateDto brandUpdateDto)
        {
            var update = await _context.Brands.FindAsync(id);

            if (update == null)
            {
                return NotFound();
            }

            update.BrandName = brandUpdateDto.BrandName;
            update.BrandCountry = brandUpdateDto.BrandCountry;
            await _context.SaveChangesAsync();

            var brand = new BrandDto
            {
                BrandId = update.BrandId,
                BrandName = update.BrandName,
                BrandCountry = update.BrandCountry,
            };

            return Ok();
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var dbrand = await _context.Brands.FindAsync(id);
            if (dbrand == null)
            {
                return NotFound();
            }

            _context.Brands.Remove(dbrand);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }

            
}

