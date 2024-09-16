using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connString = config.GetConnectionString("DefaultConnection");
            IDbConnection conn = new MySqlConnection(connString);
            // Creates an instance of the DDR \/
            var departmentRepo = new DapperDepartmentRepository(conn);
            departmentRepo.InsertDepartment("New Really Cool Department");
            var departments = departmentRepo.GetAllDepartments();
            foreach (var department in departments)
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine("\n");
            }

            var prodRepo = new DapperProductRepo(conn);
            prodRepo.CreateProduct("Big Stan's Fishing Fun", 100.00, 8);
            var products = prodRepo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine("\n");
            }
        }
    }
}
