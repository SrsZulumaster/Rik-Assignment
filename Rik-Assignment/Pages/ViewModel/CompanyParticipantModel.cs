using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rik_Assignment.Pages.ViewModel
{
    public class CompanyParticipantModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(7)]
        [MinLength(7)]
        public string CompanyID { get; set; }
        [Required]
        public int ParticipantAmount { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [MaxLength(5000)]
        public string? Description { get; set; }

        // Sets the EventRefId to Foreing key
        public int? EventRefID { get; set; }
        [ForeignKey("EventRefID")]
        public EventModel? EventModel { get; set; }
    }
}
