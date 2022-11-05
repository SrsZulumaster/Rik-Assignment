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

namespace Rik_Assignment.Pages.Participant
{
    public class EditModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public EditModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParticipantModel ParticipantModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ParticipantModel == null)
            {
                return NotFound();
            }

            var participantmodel =  await _context.ParticipantModel.FirstOrDefaultAsync(m => m.Id == id);
            if (participantmodel == null)
            {
                return NotFound();
            }
            ParticipantModel = participantmodel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ParticipantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantModelExists(ParticipantModel.Id))
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

        private bool ParticipantModelExists(int id)
        {
          return _context.ParticipantModel.Any(e => e.Id == id);
        }
    }
}
