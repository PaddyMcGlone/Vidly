using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Razor;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        public int StockCount { get; set; }
    }
}