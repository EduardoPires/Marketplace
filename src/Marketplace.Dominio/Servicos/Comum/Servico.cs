using System.Linq.Expressions;
using Marketplace.Dominio.Interfaces.Repositorio.Comum;
using Marketplace.Dominio.Interfaces.Servicos.Comum;

namespace Marketplace.Dominio.Servicos.Comum
{
    public class Servico<TEntity> : IServico<TEntity> where TEntity : class
    {
        private readonly IRepositorio<TEntity> _repositorio;

        public Servico(IRepositorio<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Adicionar(TEntity entity)
        {
            await _repositorio.Adicionar(entity);
        }

        public async Task Atualizar(TEntity entity)
        {
            await _repositorio.Atualizar(entity);
        }

        public async Task<IEnumerable<TEntity>> Buscar<TOrderKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrderKey>>? orderBy = null)
        {
            return await _repositorio.Buscar(predicate, orderBy);
        }

        public async Task Excluir(TEntity entity)
        {
            await _repositorio.Excluir(entity);
        }

        public async Task<TEntity?> ObterPorId(Guid id)
        {
            return await _repositorio.ObterPorId(id);
        }

        public async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await _repositorio.ObterTodos();
        }
    }
}
