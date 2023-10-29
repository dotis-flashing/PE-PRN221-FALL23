using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entity;
using Infrastructure;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.CarToon
{
    public class CreateModel : PageModel
    {
        private readonly ICartonService _cartonService;

        public CreateModel(ICartonService cartonService)
        {
            _cartonService = cartonService;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["ProducerId"] = new SelectList(await _cartonService.GetList(), "ProducerId", "ProducerId");
            return Page();
        }

        [BindProperty]
        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (!ModelState.IsValid || CartoonFilmInformation == null)
                {
                    return Page();
                }
                else
                {
                    CartoonFilmInformation = await _cartonService.Add(CartoonFilmInformation);
                    return RedirectToPage("./Index");
                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["ProducerId"] = new SelectList(await _cartonService.GetList(), "ProducerId", "ProducerId");
                return Page();
            }
        }
    }
}
