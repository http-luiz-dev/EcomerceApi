using Ecommerce.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecomerce.Persistence.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void ResolvePersistenceDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            string conStr = configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseNpgsql(conStr));
        }
    }
}
