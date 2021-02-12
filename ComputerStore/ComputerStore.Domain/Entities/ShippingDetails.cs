
using System.ComponentModel.DataAnnotations;

namespace ComputerStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Specify your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insert the first delivery address")]
        [Display(Name="First Adress")]
        public string Line1 { get; set; }
        [Display(Name="Second adress")]
        public string Line2 { get; set; }
        [Display(Name="Third adress")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Specify the city")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Specify the country")]
        [Display(Name = "Couttry")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
