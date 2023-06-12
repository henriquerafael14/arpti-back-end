using Arpti.Domain.Interface;

namespace Arpti.Domain.Entidades
{
    public class EntidadeBase : IEntidadeBase
    {
        public EntidadeBase()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }
    }
}
