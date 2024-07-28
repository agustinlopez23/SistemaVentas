﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVenta.DAL.DBContext;
using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.Repositorios;
using SistemaVenta.Utility;
namespace SistemaVenta.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependendencias(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbventaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbSql"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}