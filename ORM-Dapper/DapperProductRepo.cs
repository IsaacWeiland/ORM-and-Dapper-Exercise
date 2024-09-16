using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepo : IPrductRepository
{
    private readonly IDbConnection _conn;

    public DapperProductRepo(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Products> GetAllProducts()
    {
        return _conn.Query<Products>("SELECT * FROM products;");
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        _conn.Query<Products>("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @CategoryID)",
            new { name = name, price = price, categoryID = categoryID });
    }
}