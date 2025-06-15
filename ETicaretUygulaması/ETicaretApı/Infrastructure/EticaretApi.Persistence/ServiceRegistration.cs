using Microsoft.EntityFrameworkCore;
using ETicaretApi.Application.Abstraction;

using ETicaretApi.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Persistence.Repositories;

namespace ETicaretApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionSting),ServiceLifetime.Singleton);
            services.AddSingleton<ICustomerReadRepository,CustomerReadRepository>();
            services.AddSingleton<IOrderReadRepository,OrderReadRepository>();
            services.AddSingleton<IProductReadRepository,ProductReadRepository>();
            services.AddSingleton<ICustomerWriteRepository,CustomerWriteRepository>();
            services.AddSingleton<IOrderWriteRepository,OrderWriteRepository>();
            services.AddSingleton<IProductWriteRepository,ProductWriteRepository>();
            
        
        }
    }
}
