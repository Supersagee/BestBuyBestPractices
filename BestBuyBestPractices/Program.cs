using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);

            var repo = new DapperProductRepository(conn);

            repo.UpdateProduct(1, "Dell XPS 15");

            var products = repo.GetAllProducts();

            foreach (var product in products)
            {
                if (product.ProductID < 10)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }
    }
}
