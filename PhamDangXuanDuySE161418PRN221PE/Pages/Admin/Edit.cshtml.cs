using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly Domain.Entity.CartoonFilm2023DBContext _context;

        public EditModel(Domain.Entity.CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberAccount MemberAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MemberAccounts == null)
            {
                return NotFound();
            }

            var memberaccount =  await _context.MemberAccounts.FirstOrDefaultAsync(m => m.MemberId == id);
            if (memberaccount == null)
            {
                return NotFound();
            }
            MemberAccount = memberaccount;
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

            _context.Attach(MemberAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberAccountExists(MemberAccount.MemberId))
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

        private bool MemberAccountExists(int id)
        {
          return (_context.MemberAccounts?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
