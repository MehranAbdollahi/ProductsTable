using Microsoft.AspNetCore.Mvc;
using System;
using ProductsTable.Application;
using ProductsTable.Application.DTOs;
using ProductsTable.Domain;

namespace ProductsTable.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("/Product/ProductsList")]
        public JsonResult ProductsList()
        {
            try
            {
                List<ProductDto> persons = _productService.GetProducts();

                return new JsonResult(new { Result = "OK", Records = persons });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Result = "ERROR", Message = ex.Message });
            }
        }
        [HttpPost("/Product/CreateProduct")]
        public JsonResult CreateProduct(AddProductDto product)
        {
            try
            {
                Product addedProduct = _productService.AddProduct(product);

                return new JsonResult(new { Result = "OK", Records = addedProduct });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { Result = "ERROR", Message = ex.Message });
            }
        }
    }
}