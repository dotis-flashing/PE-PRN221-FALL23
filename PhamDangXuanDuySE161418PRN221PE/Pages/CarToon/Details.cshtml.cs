using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entity;
using Infrastructure;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.CarToon
{
    public class DetailsModel : PageModel
    {
        private readonly ICartonService _cartonService;

        public DetailsModel(ICartonService cartonService)
        {
            _cartonService = cartonService;
        }

        public CartoonFilmInformation CartoonFilmInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var cartoonfilminformation = await _cartonService.GetByid(id);
                if (cartoonfilminformation == null)
                {
                    return NotFound();
                }
                else
                {
                    CartoonFilmInformation = cartoonfilminformation;
                }
                return Page();
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }
    }
}
