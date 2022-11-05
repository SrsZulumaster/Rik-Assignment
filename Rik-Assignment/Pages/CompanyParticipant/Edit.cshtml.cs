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

namespace Rik_Assignment.Pages.CompanyParticipant
{
    public class EditModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public EditModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CompanyParticipantModel CompanyParticipantModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CompanyParticipantModel == null)
            {
                return NotFound();
            }

            var companyparticipantmodel =  await _context.CompanyParticipantModel.FirstOrDefaultAsync(m => m.Id == id);
            if (companyparticipantmodel == null)
            {
                return NotFound();
            }
            CompanyParticipantModel = companyparticipantmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CompanyParticipantModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyParticipantModelExists(CompanyParticipantModel.Id))
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

        private bool CompanyParticipantModelExists(int id)
        {
          return _context.CompanyParticipantModel.Any(e => e.Id == id);
        }
    }
}
