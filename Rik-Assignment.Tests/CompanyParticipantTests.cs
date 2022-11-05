using Microsoft.AspNetCore.Mvc;
using Rik_Assignment.Pages.CompanyParticipant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rik_Assignment.Tests
{
    public class CompanyParticipantTests
    {
        private readonly Rik_Assignment.Data.Rik_AssignmentContext _context;

        [Fact]
        public void Create_Model_On_post_if_valid_model()
        {
            var pageModel = new CreateModel(_context);


            var result = pageModel.OnPostAsync();


            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }
        [Fact]
        public void Create_Model_On_Get_if_valid_model()
        {
            var pageModel = new CreateModel(_context);


            var result = pageModel.OnGet;


            Assert.IsAssignableFrom<Func<IActionResult>>(result);
        }

        [Fact]
        public void Edit_Model_On_post_if_valid_model()
        {
            var pageModel = new EditModel(_context);


            var result = pageModel.OnPostAsync();


            Assert.IsAssignableFrom<Task<IActionResult>>(result);
        }
        [Fact]
        public void Edit_Model_On_Get_if_valid_model()
        {
            var pageModel = new CreateModel(_context);


            var result = pageModel.OnGet;


            Assert.IsAssignableFrom<Func<IActionResult>>(result);
        }

        [Fact]
        public void Details_Model_On_Get_if_valid_model()
        {
            var pageModel = new DetailsModel(_context);


            var result = pageModel.OnGetAsync;


            Assert.IsAssignableFrom<Func<int?, Task<IActionResult>>>(result);
        }
    }
}
