using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Data;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Pages.Payment
{
    public class DeleteModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public DeleteModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        [BindProperty]
      public PaymentModel PaymentModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PaymentModel == null)
            {
                return NotFound();
            }

            var paymentmodel = await _context.PaymentModel.FirstOrDefaultAsync(m => m.Id == id);

            if (paymentmodel == null)
            {
                return NotFound();
            }
            else 
            {
                PaymentModel = paymentmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PaymentModel == null)
            {
                return NotFound();
            }
            var paymentmodel = await _context.PaymentModel.FindAsync(id);

            if (paymentmodel != null)
            {
                PaymentModel = paymentmodel;
                _context.PaymentModel.Remove(PaymentModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
