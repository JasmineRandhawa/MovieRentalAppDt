using System.ComponentModel.DataAnnotations;

namespace MovieRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage ="Membership Type field is required")]
        [Display(Name = "Membership Type")]
        public int  MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [BirthDateValidation]
        public System.DateTime? BirthDate { get; set; }

        public static readonly int Unknown = 0;

        public static readonly int PayAsYouGo = 1;

    }
}