using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.CompanyParticipant
{
    public class DeleteModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public DeleteModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CompanyParticipantModel CompanyParticipantModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CompanyParticipantModel == null)
            {
                return NotFound();
            }

            var companyparticipantmodel = await _context.CompanyParticipantModel.FirstOrDefaultAsync(m => m.Id == id);

            if (companyparticipantmodel == null)
            {
                return NotFound();
            }
            else 
            {
                CompanyParticipantModel = companyparticipantmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CompanyParticipantModel == null)
            {
                return NotFound();
            }
            var companyparticipantmodel = await _context.CompanyParticipantModel.FindAsync(id);

            if (companyparticipantmodel != null)
            {
                CompanyParticipantModel = companyparticipantmodel;
                _context.CompanyParticipantModel.Remove(CompanyParticipantModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Index");
        }
    }
}
