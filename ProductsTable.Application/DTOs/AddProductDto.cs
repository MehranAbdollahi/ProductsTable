namespace ProductsTable.Application.DTOs;

public class AddProductDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Count { get; set; }
    public long Price { get; set; }
}