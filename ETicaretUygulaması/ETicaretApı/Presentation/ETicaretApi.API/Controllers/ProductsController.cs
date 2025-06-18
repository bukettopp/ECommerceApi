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
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            var customerId= Guid.NewGuid();
await _customerWriteRepository.AddAsync(new Customer()
{
    Name="buket",
    Id=customerId,  

});


            await _orderWriteRepository.AddAsync(new Order()
            {
                Description = "bla bla",
                Address = "9197/2 sokak",
                CustomerId=customerId,

            });
   
            await _orderWriteRepository.SaveAsync();
        }

       
    }
}
