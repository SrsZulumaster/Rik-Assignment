using System.ComponentModel.DataAnnotations;

namespace Rik_Assignment.Pages.ViewModel
{
    public class ParticipantModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        public string PersonalID { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [MaxLength(1500)]
        public string? Description { get; set; }
        public EventModel? EventID { get; set; }
    }
}
