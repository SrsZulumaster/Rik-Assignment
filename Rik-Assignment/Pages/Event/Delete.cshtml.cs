using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.Event
{
    public class DeleteModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public DeleteModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EventModel EventModel { get; set; }
        public CompanyParticipantModel CompanyParticipantModel { get; set; }
        public ParticipantModel ParticipantModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EventModel == null)
            {
                return NotFound();
            }
            var eventmodel = await _context.EventModel.Where(c => c.Id == id).Include(c => c.Company).Include(c => c.Participant).SingleOrDefaultAsync();
            

            if (eventmodel == null)
            {
                return NotFound();
            }
            else 
            {
                EventModel = eventmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EventModel == null)
            {
                return NotFound();
            }

            var eventmodel = await _context.EventModel.Where(c => c.Id == id).Include(c => c.Company).Include(c => c.Participant).SingleOrDefaultAsync();
            if (eventmodel != null)
            {
                EventModel = eventmodel;
                _context.EventModel.Remove(EventModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
