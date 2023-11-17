using ProductsTable.Application.DTOs;
using ProductsTable.Domain;

namespace ProductsTable.Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Product AddProduct(AddProductDto command)
    {
        Product newProduct = new Product(command.Title, command.Description, command.Count, command.Price);
        _repository.Add(newProduct);
        _repository.Save();
        return newProduct;
    }


    public Product EditProduct(ProductDto command)
    {
        var product = _repository.GetById(command.Id);
        product.Edit(command.Title, command.Description, command.Count, command.Price);

        _repository.Save();
        return product;
    }

    public ProductDto GetProductById(long productId)
    {
        var product = _repository.GetById(productId);
        return new ProductDto()
        {
            Title = product.Title,
            Description = product.Description,
            Count = product.Count,
            Price = product.Price
        };
    }


    public void DeleteProduct(long id)
    {
        var product = _repository.GetById(id);
        _repository.Remove(product);
        _repository.Save();
    }


    public List<ProductDto> GetProducts()
    {
        return _repository.GetList().Select(product => new ProductDto()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Count = product.Count,
            Price = product.Price
        }).ToList();

    }
}