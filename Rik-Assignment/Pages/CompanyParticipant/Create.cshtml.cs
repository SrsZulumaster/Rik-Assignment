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
    public class CreateModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public CreateModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }
        public IList<PaymentModel> PaymentModel { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.PaymentModel != null)
            {
                PaymentModel = await _context.PaymentModel.ToListAsync();
            }
        }
        [BindProperty]
        public CompanyParticipantModel CompanyParticipantModel { get; set; }
        public EventModel EventModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            CompanyParticipantModel.EventRefID = id;
            _context.CompanyParticipantModel.Add(CompanyParticipantModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
