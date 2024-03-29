﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Calories
{
    /// <summary>
    /// Klasa przechowująca model UI posiłku (nazwa lekko myląca, prechowuje również model składnika).
    /// </summary>
    internal class MealUI
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public int Protein { get; set; }
        public int ID { get; set; }

    }
}
