using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFoodOnline.Models
{
    public class FoodOrder
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

        [Display(Name = "UserId")]
        public int UserId { get; set; }
    }
}
