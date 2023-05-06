using System.ComponentModel.DataAnnotations.Schema;

namespace Count_Calories
{
    /// <summary>
    /// Klasa przechowująca model składnika.
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }

        [ForeignKey("Meal")]
        public int MealId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int IngredientWeight { get; set; }

        public virtual Meal Meal { get; set; }

        public virtual Product Product { get; set; }

    }
}