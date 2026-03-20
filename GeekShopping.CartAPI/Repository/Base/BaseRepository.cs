using AutoMapper;
using GeekShopping.CartAPI.Model.Context;
using GeekShopping.CartAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GeekShopping.CartAPI.Repository
{
    public class BaseRepository<T, TEntity> : IBaseRepository<T, TEntity>
        where T : class
        where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;

        public BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<T> Create(TEntity entities)
        {
            var entity = _mapper.Map<TEntity>(entities);
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public async Task<T> Update(TEntity entities)
        {
            var entity = _mapper.Map<TEntity>(entities);
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var entity = await _context.Set<TEntity>().FindAsync(id);

                if (entity == null) return false;

                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método para buscar entidade com includes complexos (trabalha diretamente com TEntity)
        /// </summary>
        public async Task<TEntity> GetFirstOrDefaultEntityAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            // Aplicar includes personalizados se fornecidos
            if (includeFunc != null)
                query = includeFunc(query);

            return await query.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Busca com includes complexos, retornando o VO
        /// </summary>
        public async Task<T> GetFirstOrDefaultWithIncludesAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
            // Nota: Este método trabalha com TEntity e depois mapeia
            // Para usar, passe uma expressão que funcione com TEntity
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeFunc != null)
            {
                // Aplicar includes - nota: assume que T e TEntity têm mesma estrutura
                var typedQuery = query as IQueryable<T>;
                if (typedQuery != null)
                {
                    typedQuery = includeFunc(typedQuery);
                    query = typedQuery as IQueryable<TEntity>;
                }
            }

            // Converter predicado para TEntity
            var parameter = Expression.Parameter(typeof(TEntity), "e");
            var body = Expression.Invoke(predicate, Expression.Convert(parameter, typeof(T)));
            var entityPredicate = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            var entity = await query.FirstOrDefaultAsync(entityPredicate);
            return _mapper.Map<T>(entity);
        }

        /// <summary>
        /// Busca múltiplas entidades com includes complexos
        /// </summary>
        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(
            Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (includeFunc != null)
            {
                var typedQuery = query as IQueryable<T>;
                if (typedQuery != null)
                {
                    typedQuery = includeFunc(typedQuery);
                    query = typedQuery as IQueryable<TEntity>;
                }
            }

            if (predicate != null)
            {
                var parameter = Expression.Parameter(typeof(TEntity), "e");
                var body = Expression.Invoke(predicate, Expression.Convert(parameter, typeof(T)));
                var entityPredicate = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
                query = query.Where(entityPredicate);
            }

            var entities = await query.ToListAsync();
            return _mapper.Map<List<T>>(entities);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            List<TEntity> entities = await _context.Set<TEntity>().ToListAsync();
            return _mapper.Map<List<T>>(entities);
        }

        public async Task<T> FindById(long id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return _mapper.Map<T>(entity);
        }
    }
}
