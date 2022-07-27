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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication15.Data.WebApplication15Context _context;

        public DeleteModel(WebApplication15.Data.WebApplication15Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.employee == null)
            {
                return NotFound();
            }
            var employee = await _context.employee.FindAsync(id);

            if (employee != null)
            {
                employee = employee;
                _context.employee.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
