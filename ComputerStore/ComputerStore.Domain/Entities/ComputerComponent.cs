using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ComputerStore.Domain.Entities
{
   public class ComputerComponent
    {
        [HiddenInput(DisplayValue = false)]
        public int ComputerComponentId { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage = "Please enter a name of the product")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name="Description")]
        [Required(ErrorMessage = "Please enter a description of the product")]
        public string Description { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please enter a category of the product")]
        public string Category { get; set; }
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Please enter a brand of the product")]
        public string Brand { get; set; }
        [Display(Name = "Price (zl)")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please , enter a positive value")]
        public decimal Price { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
