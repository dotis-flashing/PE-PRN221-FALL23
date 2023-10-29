using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Infrastructure;

namespace PhamDangXuanDuySE161418PRN221PE.Pages.Producer
{
    public class EditModel : PageModel
    {
        private readonly IProducerService _producerService;

        public EditModel(IProducerService producerService)
        {
            _producerService = producerService;
        }

        [BindProperty]
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
            Producer = producer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                await _producerService.Update(Producer.ProducerId, Producer);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }

    }
}
