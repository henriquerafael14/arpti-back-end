using Arpti.Domain.Entidades;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Arpti.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                ConfigureMappingsApi(config);
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void ConfigureMappingsApi(IMapperConfigurationExpression config)
        {
        }
    }
}
