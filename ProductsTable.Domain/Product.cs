
namespace ProductsTable.Domain;

public class Product
{
    public Product(long id, string title, string description, int count, long price)
    {
        Id = id;
        Title = title;
        Description = description;
        Count = count;
        Price = price;
    }
    
    public Product( string title, string description, int count, long price)
    {
        Title = title;
        Description = description;
        Count = count;
        Price = price;
    }

    public long Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Count { get; private set; }
    public long Price { get; private set; }

    public void Edit(string title, string description, int count, long price)
    {
        Title = title;
        Description = description;
        Count = count;
        Price = price;
    }
}