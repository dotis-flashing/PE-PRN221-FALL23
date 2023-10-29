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
    public class IndexModel : PageModel
    {
        private readonly Domain.Entity.CartoonFilm2023DBContext _context;

        public IndexModel(Domain.Entity.CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        public IList<MemberAccount> MemberAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MemberAccounts != null)
            {
                MemberAccount = await _context.MemberAccounts.ToListAsync();
            }
        }
    }
}
