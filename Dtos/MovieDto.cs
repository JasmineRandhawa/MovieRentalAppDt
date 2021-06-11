using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MovieRentalApp.Dtos
{
    public class MovieDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        [Required(ErrorMessage = "Genre field is required")]
        public int? GenreId { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 100)]
        public short? NumberOfStock { get; set; }

    }
}