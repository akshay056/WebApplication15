using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication15.Data;
using WebApplication15.Pages.Models;

namespace WebApplication15.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication15.Data.WebApplication15Context _context;

        public DetailsModel(WebApplication15.Data.WebApplication15Context context)
        {
            _context = context;
        }

      public employee employee { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.employee == null)
            {
                return NotFound();
            }

            var employee = await _context.employee.FirstOrDefaultAsync(m => m.id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                employee = employee;
            }
            return Page();
        }
    }
}
