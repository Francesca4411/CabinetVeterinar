using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CabinetVeterinarWeb.Data;
using CabinetVeterinarWeb.Models;

namespace CabinetVeterinarWeb.Pages.Pets
{
    public class CreateModel : PageModel
    {
        private readonly CabinetVeterinarWeb.Data.ApplicationDbContext _context;

        public CreateModel(CabinetVeterinarWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["OwnerId"] = new SelectList(_context.Owners, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Pet Pet { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pets.Add(Pet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
