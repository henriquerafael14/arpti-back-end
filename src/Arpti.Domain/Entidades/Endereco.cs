namespace Arpti.Domain.Entidades
{
    public class Endereco : EntidadeBase
    {
        public Endereco(string numero, string cep, string bairro, string cidade, string estado)
        {
            Numero = numero;
            CEP = cep;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        } 

        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}