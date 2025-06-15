using ETicaretApi.Application.Abstraction;
using ETicaretApi.Application.Repositories;
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
        public async Task GetAllProducts()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id=Guid.NewGuid() ,Name="Product 2",Price=200}
    });
            var count = await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(Guid id)
        {
            Product pro = await _productReadRepository.GetByIdAsync(id);
            return Ok(pro);
        }
    }
}
