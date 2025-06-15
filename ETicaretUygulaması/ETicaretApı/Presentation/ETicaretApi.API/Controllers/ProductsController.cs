using ETicaretApi.Application.Abstraction;
using ETicaretApi.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async void GetAllProducts()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){ Id=Guid.NewGuid() ,Name="Product 1",Price=100}
    });
            var count = await _productWriteRepository.SaveAsync();
        }
    }
}
