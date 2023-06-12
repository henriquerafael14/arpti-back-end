using Arpti.Application.AppService.Interface;
using Arpti.Domain.Interface;
using Arpti.Domain.Interface.Service;
using AutoMapper;

namespace Arpti.Application.AppService
{
    public class AppService<TEntity> : IAppService<TEntity> where TEntity : class, IEntidadeBase
    {
        private readonly IMapper _mapper;
        private readonly IService<TEntity> _service;

        public AppService(
            IMapper mapper,
            IService<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }
    }
}
