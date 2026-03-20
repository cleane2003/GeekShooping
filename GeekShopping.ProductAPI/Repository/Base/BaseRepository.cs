using AutoMapper;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.BaseAPI.Repository
{
    public class BaseRepository<T, TEntity> : IBaseRepository<T> 
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

        public async Task<T> Create(T entities)
        {
            var entity = _mapper.Map<TEntity>(entities);
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<T>(entity);
        }

        public async Task<T> Update(T entities)
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
