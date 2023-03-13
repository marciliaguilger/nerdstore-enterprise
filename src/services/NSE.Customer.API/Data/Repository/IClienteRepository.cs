using NSE.Core.Data;
using NSE.Customer.API.Models;

namespace NSE.Customer.API.Data.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void AddCustomer(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetByCpf(string cpf);
    }
}
