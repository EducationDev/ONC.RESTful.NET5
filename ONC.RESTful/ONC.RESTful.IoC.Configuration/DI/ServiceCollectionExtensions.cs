using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ONC.RESTful.Services;
using ONC.RESTful.Services.Contracts;
using System.Reflection;
using ONC.RESTful.API.Common.Attributes;

namespace ONC.RESTful.IoC.Configuration.DI
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services != null)
            {
                services.AddTransient<IFrenteObraService, FrenteObraService>();
                services.AddScoped<CustomExceptionFilter>();
            }
        }

        public static void ConfigureMappings(this IServiceCollection services)
        {
            if (services != null)
            {
                //Automap settings
                services.AddAutoMapper(Assembly.GetExecutingAssembly());
            }
        }
    }
}
