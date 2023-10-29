using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.CarToon
{
    public class EditModel : PageModel
    {
        private readonly Domain.Entity.CartoonFilm2023DBContext _context;

        public EditModel(Domain.Entity.CartoonFilm2023DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CartoonFilmInformations == null)
            {
                return NotFound();
            }

            var cartoonfilminformation =  await _context.CartoonFilmInformations.FirstOrDefaultAsync(m => m.CartoonFilmId == id);
            if (cartoonfilminformation == null)
            {
                return NotFound();
            }
            CartoonFilmInformation = cartoonfilminformation;
           ViewData["ProducerId"] = new SelectList(_context.Producers, "ProducerId", "ProducerId");
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

            _context.Attach(CartoonFilmInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartoonFilmInformationExists(CartoonFilmInformation.CartoonFilmId))
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

        private bool CartoonFilmInformationExists(int id)
        {
          return (_context.CartoonFilmInformations?.Any(e => e.CartoonFilmId == id)).GetValueOrDefault();
        }
    }
}
