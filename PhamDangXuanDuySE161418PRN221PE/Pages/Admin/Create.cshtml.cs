using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entity;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly Domain.Entity.CartoonFilm2023DBContext _context;

        public CreateModel(Domain.Entity.CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MemberAccount MemberAccount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.MemberAccounts == null || MemberAccount == null)
            {
                return Page();
            }

            _context.MemberAccounts.Add(MemberAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
