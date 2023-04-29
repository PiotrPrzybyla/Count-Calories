using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Calories
{
    public interface IUserMealRepository
    {
        IEnumerable<UserMeal> GetAllUserMeals();
        UserMeal GetUserMealById(int id);
        int AddUserMeal(UserMeal UserMeal);
        void UpdateUserMeal(UserMeal UserMeal);
        void DeleteUserMeal(int id);
    }

    public class UserMealRepository
    {
        private readonly CountCaloriesContext _dbContext;

        public UserMealRepository(CountCaloriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<UserMeal> GetAllUserMeals()
        {
            return _dbContext.UserMeals.ToList();
        }

        public UserMeal GetUserMealById(int id)
        {
            return _dbContext.UserMeals.FirstOrDefault(m => m.Id == id);
        }

        public int AddUserMeal(UserMeal UserMeal)
        {
            _dbContext.UserMeals.Add(UserMeal);
            _dbContext.SaveChanges();
            return UserMeal.Id;
        }

        public void UpdateUserMeal(UserMeal UserMeal)
        {
            _dbContext.Entry(UserMeal).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteUserMeal(int id)
        {
            var UserMeal = GetUserMealById(id);
            _dbContext.UserMeals.Remove(UserMeal);
            _dbContext.SaveChanges();
        }
    }
}
