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
    public class IndexModel : PageModel
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        public IndexModel(Rik_Assignment.Data.Rik_AssignmentContext context)
        {
            _context = context;
        }

        public IList<PaymentModel> PaymentModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PaymentModel != null)
            {
                PaymentModel = await _context.PaymentModel.ToListAsync();
            }
        }
    }
}
