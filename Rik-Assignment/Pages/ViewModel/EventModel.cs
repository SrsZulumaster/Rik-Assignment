using System.ComponentModel.DataAnnotations;

namespace Rik_Assignment.Pages.ViewModel
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string EventDescription { get; set; }
        [Required]
        public string EventLocation { get; set; }
        [Required]
        public DateTime EventDate { get; set; }

        public ICollection<ParticipantModel>? Participant { get; set; }
        public ICollection<CompanyParticipantModel>? Company { get; set; }

    }
}
