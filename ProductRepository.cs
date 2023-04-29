using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Calories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        int AddProduct(Product Product);
        void UpdateProduct(Product Product);
        void DeleteProduct(int id);
    }
    public class ProductRepository
    {
        private readonly CountCaloriesContext _dbContext;
        public ProductRepository(CountCaloriesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(m => m.Id == id);
        }

        public int AddProduct(Product Product)
        {
            _dbContext.Products.Add(Product);
            _dbContext.SaveChanges();
            return Product.Id;
        }

        public void UpdateProduct(Product Product)
        {
            _dbContext.Entry(Product).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var Product = GetProductById(id);
            _dbContext.Products.Remove(Product);
            _dbContext.SaveChanges();
        }
    }
}

