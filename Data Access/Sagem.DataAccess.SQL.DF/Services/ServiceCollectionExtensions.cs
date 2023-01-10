using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sagem.DataAccess.SQL.DF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagem.DataAccess.SQL.DF.Services
{
    static public class ServiceCollectionExtensions
    {
        static public IServiceCollection 
            AddDatabaseService(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<BusinessDBContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            return services;
        }
        
    }
}
