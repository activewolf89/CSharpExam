using System.ComponentModel.DataAnnotations;

namespace ProfessionalNetwork.Models
{
    public class UserViewValidation 
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters")]
        [MinLength(2)]
        public string Name {get;set;}
        
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirmation must match")]
        public string ConfirmationPassword{get;set;}
        
        [Required]
        public string Description{get;set;}





        
    }
}