using System.ComponentModel.DataAnnotations;

namespace Rik_Assignment.Pages.ViewModel
{
    public class PaymentModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PaymentName { get; set; }
    }
}
