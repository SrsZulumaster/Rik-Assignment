using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.Event
{
    public class CreateModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public CreateModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        // Captures the information from the page and binds it to EventModel
        [BindProperty]
        public EventModel EventModel { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            // Checks if Values captured from the page are Correct according to ViewModel.EventModel
            // Does not check validity of nullable values
          if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EventModel.Add(EventModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
