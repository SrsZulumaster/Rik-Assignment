using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Rik_Assignment.Data;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System;
using Rik_Assignment.Pages.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Rik_Assignment.Tests;

public class EventTests
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


        Assert.IsAssignableFrom<System.Func<IActionResult>>(result);
    }

    [Fact]
    public void Edit_Model_On_post_if_valid_model()
    {
        var pageModel = new EditModel(_context);

       
        var result = pageModel.OnPostAsync();


        Assert.IsAssignableFrom<Task<IActionResult>>(result);
    }
    [Fact]
    public void Édit_Model_On_Get_if_valid_model()
    {
        var pageModel = new CreateModel(_context);


        var result = pageModel.OnGet;


        Assert.IsAssignableFrom<Task<IActionResult>>(result);
    }

    [Fact]
    public void Details_Model_On_Get_if_valid_model()
    {
        var pageModel = new DetailsModel(_context);

        
        var result = pageModel.OnGetAsync;


        Assert.IsAssignableFrom<Task<IActionResult>>(result);
    }
}