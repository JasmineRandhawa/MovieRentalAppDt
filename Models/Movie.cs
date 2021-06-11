using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage = "Genre field is required")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Range(1,100)]
        [Display(Name = "Number Of Stock")]
        public short NumberOfStock { get; set; }

        public static readonly int Unknown = 0;
    }
}
