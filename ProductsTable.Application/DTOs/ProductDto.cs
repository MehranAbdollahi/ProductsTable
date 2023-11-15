namespace ProductsTable.Application.DTOs;

public class ProductDto
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Count { get; set; }
    public long Price { get; set; }
}