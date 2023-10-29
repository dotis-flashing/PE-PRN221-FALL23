using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Producer
{
    public class DetailsModel : PageModel
    {
        private readonly IProducerService _producerService;

        public DetailsModel(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public Domain.Entity.Producer Producer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producer = await _producerService.GetProducerById(id);
            if (producer == null)
            {
                return NotFound();
            }
            else
            {
                Producer = producer;
            }
            return Page();
        }
    }
}
