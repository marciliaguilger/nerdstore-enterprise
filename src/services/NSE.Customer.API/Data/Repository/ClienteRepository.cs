using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NSE.Core.Data;
using NSE.Customer.API.Models;

namespace NSE.Customer.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void AddCustomer(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }

        public Task<Cliente> GetByCpf(string cpf)
        {
            return _context.Cliente.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }
    }
}
