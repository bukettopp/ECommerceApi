using ETicaretApi.Application.Abstraction;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Application.ViewModels.Products;
using ETicaretApi.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ETicaretApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
      
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
           
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
  
            return Ok(_productReadRepository.GetAll(false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_CreateProduct productModel)
        {
            await _productWriteRepository.AddAsync(new Product()
            {
                Name = productModel.Name,
                CreateDate = DateTime.Now,
                Price = productModel.Price,
                Stock = productModel.Stock,
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
