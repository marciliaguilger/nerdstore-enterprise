using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Customer.API.Data.Repository;
using NSE.Customer.API.Models;

namespace NSE.Customer.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            var clienteExiste = _clienteRepository.GetByCpf(cliente.Cpf.Numero);

            if (clienteExiste != null)
            {
                AddError("Cliente já cadastrado");
                return ValidationResult;
            }

            _clienteRepository.AddCustomer(cliente);

            return await PersistData(_clienteRepository.UnitOfWork);
        }
    }
}
