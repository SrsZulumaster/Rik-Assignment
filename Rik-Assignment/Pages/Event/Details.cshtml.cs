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
    public class DetailsModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public DetailsModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        // Sets up the EventModel, list of Participants and list of Companies taking part
      public EventModel EventModel { get; set; }
        public IList<ParticipantModel> ParticipantModel { get; set; }
        public IList<CompanyParticipantModel> CompanyParticipantModel { get; set; }


        // When Page loads checks if any of the Models are null
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null || _context.EventModel == null || _context.ParticipantModel == null || _context.CompanyParticipantModel == null)
            {
                return NotFound();
            }
            // Loads the Event model and displays it and all the participants
            var eventmodel = await _context.EventModel.FirstOrDefaultAsync(m => m.Id == id);
            if (eventmodel == null)
            {
                return NotFound();
            }
            else 
            {
                ParticipantModel = await _context.ParticipantModel.ToListAsync();
                CompanyParticipantModel = await _context.CompanyParticipantModel.ToListAsync();
                EventModel = eventmodel;
            }
            return Page();
        }
    }
}
