using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieRentalApp.Models;

namespace MovieRentalApp.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Genre field is required")]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        public System.DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 100)]
        [Display(Name = "Number Of Stock")]
        public short? NumberOfStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberOfStock = movie.NumberOfStock;
            GenreId = movie.GenreId;
        }
    }
}