using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectPartB.Models
{
    public partial class CarDescription
    {
        public CarDescription()
        {
            CarAvailabilities = new HashSet<CarAvailability>();
           
        }

        public int CarDescriptionId { get; set; }
        public int? CarTypeId { get; set; }
        [Required(ErrorMessage = "The description is required.")]
        [StringLength(500, ErrorMessage = "The description cannot be longer than 500 characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "The brand is required.")]
        public string? Brand { get; set; }
        [Required(ErrorMessage = "The model is required.")]
        public string? Model { get; set; }
        [Required(ErrorMessage = "The color is required.")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "The rate per day is required.")]
        [Range(0, 10000, ErrorMessage = "The rate per day must be between 0 and 10000.")]
        public decimal RatePerDay { get; set; }
        public bool? Available { get; set; }
        [Required(ErrorMessage = "Please upload an image.")]
        public string? Image { get; set; }
        [Required(ErrorMessage = "Please select the car type.")]
        public string CarTypeName { get; set; }
        public virtual CarType? CarType { get; set; }
        public virtual ICollection<CarAvailability> CarAvailabilities { get; set; }
        
    }
}
