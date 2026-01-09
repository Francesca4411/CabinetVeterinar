using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CabinetVeterinarWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace CabinetVeterinarWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _context.Reviews
                .AsNoTracking()
                .Select(r => new
                {
                    r.Id,
                    r.Rating,
                    Text = r.Text,
                    r.AppointmentId,
                    PetId = r.Appointment != null ? r.Appointment.PetId : (int?)null,
                    PetName = r.Appointment != null && r.Appointment.Pet != null ? r.Appointment.Pet.Name : null,
                    StartAt = r.Appointment != null ? r.Appointment.StartAt : (DateTime?)null
                })
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet("by-pet/{petId:int}")]
        public async Task<IActionResult> ByPet(int petId)
        {
            var items = await _context.Reviews
                .AsNoTracking()
                .Where(r => r.Appointment != null && r.Appointment.PetId == petId)
                .Select(r => new
                {
                    r.Id,
                    r.Rating,
                    Text = r.Text,
                    r.AppointmentId,
                    PetId = r.Appointment!.PetId,
                    PetName = r.Appointment!.Pet != null ? r.Appointment!.Pet.Name : null,
                    StartAt = r.Appointment!.StartAt
                })
                .ToListAsync();

            return Ok(items);
        }
    }
}
