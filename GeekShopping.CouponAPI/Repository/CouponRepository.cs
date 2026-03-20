using AutoMapper;
using GeekShopping.BaseAPI.Repository;
using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Model;
using GeekShopping.CouponAPI.Model.Context;
using GeekShopping.CouponAPI.Repository.Interfaces;

namespace GeekShopping.CouponAPI.Repository
{
    public class CouponRepository : BaseRepository<CouponVO, Coupon>, ICouponRepository
    {
        private readonly IBaseRepository<CouponVO, Coupon> _baseRepository;
        public CouponRepository(AppDbContext context, IMapper mapper, IBaseRepository<CouponVO, Coupon> baseRepository)
            : base(context, mapper)
        {
            _baseRepository = baseRepository;
        }

        public async Task<CouponVO> GetCouponByCouponCode(string couponCode)
        {
            var coupon = await _baseRepository.GetFirstOrDefaultEntityAsync(c => c.CouponCode == couponCode);

            return _mapper.Map<CouponVO>(coupon);
        }
    }
}
