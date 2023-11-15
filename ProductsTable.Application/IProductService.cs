

using ProductsTable.Application.DTOs;
using ProductsTable.Domain;

namespace ProductsTable.Application;

public interface IProductService
{
    Product AddProduct(AddProductDto command);
    Product EditProduct(ProductDto command);
    void DeleteProduct(long id);
    List<ProductDto> GetProducts();
}