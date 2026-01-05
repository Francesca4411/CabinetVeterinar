using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinarWeb.Data;
using CabinetVeterinarWeb.Models;

namespace CabinetVeterinarWeb.Pages.Vets
{
    public class DetailsModel : PageModel
    {
        private readonly CabinetVeterinarWeb.Data.ApplicationDbContext _context;

        public DetailsModel(CabinetVeterinarWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Vet Vet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vet = await _context.Vets.FirstOrDefaultAsync(m => m.Id == id);

            if (vet is not null)
            {
                Vet = vet;

                return Page();
            }

            return NotFound();
        }
    }
}
