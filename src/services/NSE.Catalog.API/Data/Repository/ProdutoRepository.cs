using Microsoft.EntityFrameworkCore;
using NSE.Catalog.API.Models;
using NSE.Core.Data;

namespace NSE.Catalog.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;
        public IUnitOfWork UnitOfWork => _context;
        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }

        public async Task<Produto> ObterPorId(Guid Id)
        {
            return await _context.Produtos.FindAsync(Id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }
        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
