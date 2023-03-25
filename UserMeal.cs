using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Count_Calories
{
    public class UserMeal
    {
        public enum MealTypeENUM
        {
            Breakfast = 1,
            SecondBreakfast = 2,
            Lunch = 3,
            Dinner = 4,
            Supper = 5
        }

        public int Id { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        public DateTime Date { get; set; }

        public MealTypeENUM MealType { get; set; }

        public virtual Meal Meal { get; set; }




    }
}