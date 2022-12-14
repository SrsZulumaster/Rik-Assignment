using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.Event
{
    public class EditModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public EditModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventModel EventModel { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventModel == null )
            {
                return NotFound();
            }

            var eventmodel =  await _context.EventModel.FirstOrDefaultAsync(m => m.Id == id);
            if (eventmodel == null)
            {
                return NotFound();
            }
            if (eventmodel.EventDate < DateTime.Now)
            {
                return RedirectToPage("/Index");
            }
            EventModel = eventmodel;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // Attaches the updated State to EventModel
            _context.Attach(EventModel).State = EntityState.Modified;

            // Checks if there is an Event with this ID and saves the changes to the Database
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventModelExists(EventModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Index");
        }
        // retruns True if there is any eventModel with given id
        private bool EventModelExists(int id)
        {
          return _context.EventModel.Any(e => e.Id == id);
        }
    }
}
