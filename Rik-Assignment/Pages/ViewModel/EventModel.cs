using System.ComponentModel.DataAnnotations;

namespace Rik_Assignment.Pages.ViewModel
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        
        public string? EventDescription { get; set; }
        [Required]
        public string EventLocation { get; set; }
        [Required, DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime EventDate { get; set; }

        // ICollection Makes this a One To Many Database Relationship
        // in order to deal with Deleting it is neccessary to reference these during Deletion
        // With this line:
        // var eventmodel = await _context.EventModel.Where(c => c.Id == id).Include(c => c.Company).Include(c => c.Participant).SingleOrDefaultAsync();
        // This makes the Deletion Cascade and delete the participants of the Event
        public ICollection<ParticipantModel>? Participant { get; set; }
        public ICollection<CompanyParticipantModel>? Company { get; set; }

    }
}
