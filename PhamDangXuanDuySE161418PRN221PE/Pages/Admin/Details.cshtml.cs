using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly Domain.Entity.CartoonFilm2023DBContext _context;

        public DetailsModel(Domain.Entity.CartoonFilm2023DBContext context)
        {
            _context = context;
        }

      public MemberAccount MemberAccount { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MemberAccounts == null)
            {
                return NotFound();
            }

            var memberaccount = await _context.MemberAccounts.FirstOrDefaultAsync(m => m.MemberId == id);
            if (memberaccount == null)
            {
                return NotFound();
            }
            else 
            {
                MemberAccount = memberaccount;
            }
            return Page();
        }
    }
}
