using Arpti.Domain.Interface;

namespace Arpti.Application.AppService.Interface
{
    public interface IAppService<TEntity> where TEntity : class, IEntidadeBase
    {
    }
}
