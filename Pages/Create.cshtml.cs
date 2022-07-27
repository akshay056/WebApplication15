using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication15.Data;
using WebApplication15.Pages.Models;

namespace WebApplication15.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication15.Data.WebApplication15Context _context;

        public CreateModel(WebApplication15.Data.WebApplication15Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public employee employee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.employee == null || employee == null)
            {
                return Page();
            }

            _context.employee.Add(employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
