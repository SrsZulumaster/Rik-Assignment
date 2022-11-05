using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rik_Assignment.Pages.ViewModel
{
    public class ParticipantModel
    {
        //Sets the Database Model on Migration
        //Gets referenced OnPost when cheking ModelState
        // public string? Description--- Sets the Description as a Optional field
        // public string PersonalID  --- Sets the field as a mandatory field 
        // [Required] Keyword --Makes it a Not Null in the Database

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

        // Sets the EventRefId to Foreing key
        public int? EventRefID { get; set; }
        [ForeignKey("EventRefID")]
        public EventModel? EventModel { get; set; }
    }
}
