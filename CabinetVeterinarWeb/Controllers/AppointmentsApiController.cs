using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabinetVeterinarWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace CabinetVeterinarWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.Appointments
                .AsNoTracking()
                .Select(a => new
                {
                    a.Id,
                    a.StartAt,
                    a.Notes,
                    a.PetId,
                    PetName = a.Pet != null ? a.Pet.Name : null,
                    a.VetId,
                    VetName = a.Vet != null ? a.Vet.FullName : null,
                    a.ServiceId,
                    ServiceName = a.Service != null ? a.Service.Name : null
                })
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet("by-pet/{petId:int}")]
        public async Task<IActionResult> ByPet(int petId)
        {
            var items = await _context.Appointments
                .AsNoTracking()
                .Where(a => a.PetId == petId)
                .Select(a => new
                {
                    a.Id,
                    a.StartAt,
                    a.Notes,
                    a.PetId,
                    PetName = a.Pet != null ? a.Pet.Name : null,
                    a.VetId,
                    VetName = a.Vet != null ? a.Vet.FullName : null,
                    a.ServiceId,
                    ServiceName = a.Service != null ? a.Service.Name : null
                })
                .ToListAsync();

            return Ok(items);
        }
    }
}
