using ProductsTable.Domain;

namespace ProductsTable.Infrastructure.Static.Products;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }
    public List<Product> GetList()
    {
        return _context.Products.ToList();
    }

    public Product GetById(long id)
    {
        return _context.Products.FirstOrDefault(f => f.Id == id) ?? default!;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void Update(Product product)
    {
        var oldProduct = GetById(product.Id);
        _context.Products.Remove(oldProduct);
        Add(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

}