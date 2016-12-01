using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        French,
        Japanese,
        American
    }
    public class Resturant
    {
        public int Id { get; set; }

        [Display(Name ="Resturant Name")]
        [Required, MaxLength(30)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
