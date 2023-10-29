using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entity;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.CarToon
{
    public class IndexModel : PageModel
    {
        private readonly ICartonService _cartonService;

        public IndexModel(ICartonService cartonService)
        {
            _cartonService = cartonService;
        }

        [BindProperty(SupportsGet = true)]
        public int SearchQuery { get; set; }
        public IList<CartoonFilmInformation> CartoonFilmInformation { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CartoonFilmInformation = await _cartonService.Search(SearchQuery);
        }
    }
}
