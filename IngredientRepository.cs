using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Calories
{
    /// <summary>
    /// Interfejs repozytoria składników.
    /// </summary>
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAllIngredients();
        Ingredient GetIngredientById(int id);
        int AddIngredient(Ingredient Ingredient);
        void UpdateIngredient(Ingredient Ingredient);
        void DeleteIngredient(int id);
    }

    /// <summary>
    /// Klasa do operacji CRUD-owych na składnikach.
    /// </summary>
    public class IngredientRepository
    {
        private readonly CountCaloriesContext _dbContext;
        public IngredientRepository(CountCaloriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _dbContext.Ingredients.ToList();
        }

        public Ingredient GetIngredientById(int id)
        {
            return _dbContext.Ingredients.FirstOrDefault(m => m.Id == id);
        }

        public int AddIngredient(Ingredient Ingredient)
        {
            _dbContext.Ingredients.Add(Ingredient);
            _dbContext.SaveChanges();
            return Ingredient.Id;
        }

        public void UpdateIngredient(Ingredient Ingredient)
        {
            _dbContext.Entry(Ingredient).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteIngredient(int id)
        {
            var Ingredient = GetIngredientById(id);
            _dbContext.Ingredients.Remove(Ingredient);
            _dbContext.SaveChanges();
        }
    }
}

