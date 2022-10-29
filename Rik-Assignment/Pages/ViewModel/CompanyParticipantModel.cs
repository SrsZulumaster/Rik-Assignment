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
        [MaxLength(1500)]
        public string? Description { get; set; }
        public EventModel? EventID { get; set; }
    }
}
