using Microsoft.AspNetCore.Mvc;
using EF.Data;
using EF.Dtos;
using EF.Models;
using AutoMapper;


namespace EF.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    IProductRepository _productRepository;
    IMapper _mapper;
    
    public ProductController(IConfiguration config, IProductRepository productRepository) {
        _productRepository = productRepository;

        _mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.CreateMap<ProductDto, Product>();
        }));

    }

    [HttpGet("")]
    public IEnumerable<Product> getAllProduct() {
       IEnumerable<Product> products = _productRepository.GetProducts();
       return products;
    }

    [HttpPost("")]
    public IActionResult AddProduct(ProductDto product) {
        Product productDB = _mapper.Map<Product>(product);
        _productRepository.AddEntity<Product>(productDB);
        if(_productRepository.SaveChanges()){
            return Ok();
        }
        throw new Exception("Failed to add product");
    }

    [HttpPut("{productID}")]
    public IActionResult EditProduct(int productID, ProductDto product){
        Product? productDB = _productRepository.GetSingleProduct(productID);

        if(productDB != null) {
            productDB.Name = product.Name;

            if(_productRepository.SaveChanges()){
                return Ok();
            }
            throw new Exception("Failed to update product");
        }
        else {
            throw new Exception("Product ID invalid");
        }

    }


}
