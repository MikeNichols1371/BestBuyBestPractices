using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    internal class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }
        public void CreateProduct(string newProductName, double Price, int CategoryID)
        {
            _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name , @price, @categoryID);", new { name = newProductName, price = Price, categoryId = CategoryID });
        }
        public void UpdateProduct(string productName, double Price, int CategoryID)
        {
            _connection.Execute("UPDATE products SET name = 'Mikes Updated Product', price = 15.99, categoryID = 10 WHERE name = 'Mikes New Product'", new { name = productName, price = Price, categoryID = CategoryID});
        }
        public void DeleteProduct(string productName)
        {
            _connection.Execute("Delete From products Where name = 'Mikes New Product'");
        }
    }
}                         
