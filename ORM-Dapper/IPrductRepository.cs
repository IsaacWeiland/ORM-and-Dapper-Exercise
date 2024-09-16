namespace ORM_Dapper;

public interface IPrductRepository
{
    IEnumerable<Products> GetAllProducts();
    void CreateProduct(string name, double price, int categoryID);
}