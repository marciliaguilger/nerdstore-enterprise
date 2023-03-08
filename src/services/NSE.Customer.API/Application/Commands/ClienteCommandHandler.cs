using FluentValidation.Results;
using MediatR;
using NSE.Core.Messages;
using NSE.Customer.API.Models;

namespace NSE.Customer.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            //validações de negócio
            //persistir no banco

            //validar se o cliente existe no banco
            if (true)
            {
                AddError("Cliente já cadastrado");
                return ValidationResult;
            }
            return message.ValidationResult;
        }
    }
}
