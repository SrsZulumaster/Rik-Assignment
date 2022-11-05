using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.Participant
{
    public class DeleteModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public DeleteModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ParticipantModel ParticipantModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ParticipantModel == null)
            {
                return NotFound();
            }

            var participantmodel = await _context.ParticipantModel.FirstOrDefaultAsync(m => m.Id == id);

            if (participantmodel == null)
            {
                return NotFound();
            }
            else 
            {
                ParticipantModel = participantmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ParticipantModel == null)
            {
                return NotFound();
            }
            var participantmodel = await _context.ParticipantModel.FindAsync(id);

            if (participantmodel != null)
            {
                ParticipantModel = participantmodel;
                _context.ParticipantModel.Remove(ParticipantModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
