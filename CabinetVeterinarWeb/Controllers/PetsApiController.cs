using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabinetVeterinarWeb.Data;
using CabinetVeterinarWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CabinetVeterinarWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PetsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            var pets = await _context.Pets.ToListAsync();
            return Ok(pets);
        }
    }
}
