using NSE.Core.DomainObjects;

namespace NSE.Customer.API.Models
{
    public class Endereco : Entity
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        
        // EF Relation
        public Cliente Cliente { get; protected set; }
        public Endereco(string logradouro, string numero, string bairro, string cep, string cidade, string estado, string complemento)
        {
            Logradouro = logradouro;
            Complemento = complemento;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
