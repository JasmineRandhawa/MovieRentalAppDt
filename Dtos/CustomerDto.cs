
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MovieRentalApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipTypeDto MembershipType{ get; set; }

        [Required(ErrorMessage ="Membership Type field is required")]
        public int  MembershipTypeId { get; set; }

        [BirthDateValidation]
        public System.DateTime? BirthDate { get; set; }
    }
}