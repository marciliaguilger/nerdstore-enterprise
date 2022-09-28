using NSE.Core.Data;

namespace NSE.Catalog.API.Models
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();  
        Task<Produto> ObterPorId(Guid Id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
