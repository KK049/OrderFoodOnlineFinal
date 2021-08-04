using System.ComponentModel.DataAnnotations;

namespace OrderFoodOnline.Models
{
    public class Foods
    {
        public int Id { get; set; }

        [Display(Name = "Food Name")]
        public string FoodName { get; set; }

        [Display(Name = "FoodType")]
        public string FoodType { get; set; }
        
        [Display(Name = "NumberOfDishes")]
        public string NumberOfDishes { get; set; }
        
        [Display(Name = "Rate")]
        public string Rate { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
