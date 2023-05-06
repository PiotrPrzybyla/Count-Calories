using System.Collections.Generic;

namespace Count_Calories
{
    /// <summary>
    /// Klasa przechowująca model produktu.
    /// </summary>
    public class Product
    {
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Protein { get; set; }
    }
}