using System.Linq.Expressions;

namespace GeekShopping.CartAPI.Repository.Interfaces
{
    public interface IBaseRepository<T, TEntity>
        where T : class
        where TEntity : class
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(long id);
        Task<T> Create(TEntity entity);
        Task<T> Update(TEntity entity);
        Task<bool> Delete(long id);

        /// <summary>
        /// Busca uma entidade diretamente (retorna TEntity, não T) com includes complexos
        /// Use quando precisar trabalhar com propriedades de navegação da Entity
        /// </summary>
        Task<TEntity> GetFirstOrDefaultEntityAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null);

        /// <summary>
        /// Busca uma entidade com configuração customizada de includes (suporta ThenInclude)
        /// </summary>
        Task<T> GetFirstOrDefaultWithIncludesAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IQueryable<T>> includeFunc = null);

        /// <summary>
        /// Busca múltiplas entidades com configuração customizada de includes
        /// </summary>
        Task<IEnumerable<T>> GetAllWithIncludesAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IQueryable<T>> includeFunc = null);
    }
}
