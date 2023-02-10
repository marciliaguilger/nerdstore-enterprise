using NSE.Core.DomainObjects;

namespace NSE.Customer.API.Models
{
    public class Cliente : Entity, IAggregateRoot
    {

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Excluido { get; private set; }
        public Endereco Endereco { get; private set; }
        public Guid ClienteId { get; private set; }


        public Cliente(string nome, string email, string cpf, bool excluido, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Excluido = false;
        }
        //EF Core
        protected Cliente() {}
    }
}
