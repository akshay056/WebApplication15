using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication15.Data;
using WebApplication15.Pages.Models;

namespace WebApplication15.Pages
{
    public class EditModel : PageModel
    {
        private readonly WebApplication15.Data.WebApplication15Context _context;

        public EditModel(WebApplication15.Data.WebApplication15Context context)
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

            var employee =  await _context.employee.FirstOrDefaultAsync(m => m.id == id);
            if (employee == null)
            {
                return NotFound();
            }
            employee = employee;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(employee.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool employeeExists(int id)
        {
          return (_context.employee?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
