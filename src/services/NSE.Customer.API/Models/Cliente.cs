using NSE.Core.DomainObjects;

namespace NSE.Customer.API.Models
{
    public class Cliente : Entity, IAggregateRoot
    {

        public string Nome { get; private set; } = default!;
        public Email Email { get; private set; } = default!;
        public Cpf Cpf { get; private set; } = default!;
        public bool Excluido { get; private set; } = default!;
        public Endereco Endereco { get; private set; } = default!;


        public Cliente(Guid id, string nome, string email, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Excluido = false;
        }
        //EF Core
        protected Cliente() {} 

        public void TrocarEmail(string email)
        {
            Email = new Email(email);
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }
    }
}
