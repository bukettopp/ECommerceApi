using Microsoft.EntityFrameworkCore;
using ETicaretApi.Application.Abstraction;
using ETicaretApi.Persistence.Concretes;
using ETicaretApi.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionSting));
          //  services.AddSingleton<IProductService, ProductService>();
        }
    }
}
