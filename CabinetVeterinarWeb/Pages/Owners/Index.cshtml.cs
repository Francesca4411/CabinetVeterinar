using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinarWeb.Data;
using CabinetVeterinarWeb.Models;

namespace CabinetVeterinarWeb.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly CabinetVeterinarWeb.Data.ApplicationDbContext _context;

        public IndexModel(CabinetVeterinarWeb.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Owner = await _context.Owners.ToListAsync();
        }
    }
}
