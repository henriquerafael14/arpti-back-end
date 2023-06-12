using Arpti.Domain.Interface;
using Arpti.Infra.CrossCutting.Enumeradores;
using Microsoft.AspNetCore.Identity;

namespace Arpti.Domain.Entidades
{
    public class Usuario : IdentityUser<Guid>, IEntidadeBase
    {
        public Usuario(string nome, string sobrenome, string cpfCnpj, string email, string senha, DateTime dataNascimento, Endereco endereco, TipoUsuario tipoUsuario)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            CPFCNPJ = cpfCnpj; 
            Email = email;
            Senha = senha;
            DataNascimento = dataNascimento;
            Endereco = endereco;
            UserName = $"{nome} {sobrenome}";
            TipoUsuario = tipoUsuario;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPFCNPJ { get; set; }
        public string Senha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public virtual Guid? EnderecoId { get; set; }
        public virtual Endereco Endereco { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
