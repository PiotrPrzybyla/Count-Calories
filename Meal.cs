using System.Collections.Generic;

namespace Count_Calories
{
    /// <summary>
    /// Klasa przechowująca model posiłku.
    /// </summary>
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }

    }
}