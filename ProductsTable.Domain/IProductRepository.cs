
namespace ProductsTable.Domain;

public interface IProductRepository
{
    List<Product> GetList();
    void Add(Product product);
    void Update(Product product);
    void Remove(Product product);
    Product GetById(long id);
    void Save();
}