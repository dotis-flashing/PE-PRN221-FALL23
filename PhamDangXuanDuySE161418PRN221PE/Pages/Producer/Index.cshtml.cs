
using Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Producer;

public class IndexModel : PageModel
{
    private readonly IProducerService _producerService;

    public IndexModel(IProducerService producerService)
    {
        _producerService = producerService;
    }

    public IList<Domain.Entity.Producer> Producer { get; set; } = default!;

    public async Task OnGetAsync()
    {
        try
        {
            Producer = await _producerService.GetProducer();
        }
        catch (Exception ex)
        {
            ViewData["Message"] = ex.Message.ToString();
            Page();
        }
    }
}
