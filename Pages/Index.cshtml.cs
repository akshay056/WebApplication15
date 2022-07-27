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
    public class IndexModel : PageModel
    {
        private readonly WebApplication15.Data.WebApplication15Context _context;

        public IndexModel(WebApplication15.Data.WebApplication15Context context)
        {
            _context = context;
        }

        public IList<employee> employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.employee != null)
            {
                employee = await _context.employee.ToListAsync();
            }
        }
    }
}
