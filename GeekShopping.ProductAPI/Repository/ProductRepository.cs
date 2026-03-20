using AutoMapper;
using GeekShopping.BaseAPI.Repository;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repository.Interfaces;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : BaseRepository<ProductVO, Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
