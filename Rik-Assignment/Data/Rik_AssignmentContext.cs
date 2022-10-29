using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rik_Assignment.Pages.ViewModel;

namespace Rik_Assignment.Data
{
    public class Rik_AssignmentContext : DbContext
    {
        public Rik_AssignmentContext (DbContextOptions<Rik_AssignmentContext> options)
            : base(options)
        {
        }

        public DbSet<Rik_Assignment.Pages.ViewModel.EventModel> EventModel { get; set; } = default!;

        public DbSet<Rik_Assignment.Pages.ViewModel.ParticipantModel> ParticipantModel { get; set; }

        public DbSet<Rik_Assignment.Pages.ViewModel.CompanyParticipantModel> CompanyParticipantModel { get; set; }
    }
}
