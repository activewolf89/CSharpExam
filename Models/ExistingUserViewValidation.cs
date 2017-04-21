using System.ComponentModel.DataAnnotations;
 
namespace ProfessionalNetwork.Models
{
    public class ExistingUserViewValidation
    {
 
        [Required]
        [EmailAddress]
        public string Existing_Email { get; set; }
 
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Existing_Password { get; set; }
    }
}
