using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Calories
{
    public interface IMealRepository
    {
        IEnumerable<Meal> GetAllMeals();
        Meal GetMealById(int id);
        int AddMeal(Meal meal);
        void UpdateMeal(Meal meal);
        void DeleteMeal(int id);
    }

    public class MealRepository
    {
        private readonly CountCaloriesContext _dbContext;

        public MealRepository(CountCaloriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Meal> GetAllMeals()
        {
            return _dbContext.Meals.ToList();
        }

        public Meal GetMealById(int id)
        {
            return _dbContext.Meals.FirstOrDefault(m => m.Id == id);
        }

        public int AddMeal(Meal meal)
        {
            _dbContext.Meals.Add(meal);
            _dbContext.SaveChanges();
            return meal.Id;
        }

        public void UpdateMeal(Meal meal)
        {
            _dbContext.Entry(meal).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteMeal(int id)
        {
            var meal = GetMealById(id);
            _dbContext.Meals.Remove(meal);
            _dbContext.SaveChanges();
        }
    }

}
