using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entity;
using Infrastructure;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Producer
{
    public class CreateModel : PageModel
    {
        private readonly IProducerService _producerService;

        public CreateModel(IProducerService producerService)
        {
            _producerService = producerService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Domain.Entity.Producer Producer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Producer = await _producerService.Add(Producer);
               return RedirectToPage("/Producer/Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }
    }
}
