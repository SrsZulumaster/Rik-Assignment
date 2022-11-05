using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.Participant
{
    public class CreateModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;


        public CreateModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ParticipantModel ParticipantModel { get; set; }

        public EventModel   EventModel { get; set; }

        [BindProperty(SupportsGet =true)]
        public int id { get; set; }
        public void OnGet()
        {

        }


        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            ParticipantModel.EventRefID = id;
            _context.ParticipantModel.Add(ParticipantModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
