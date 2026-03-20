using GeekShopping.CouponAPI.Data.ValueObjects;
using GeekShopping.CouponAPI.Model;

namespace GeekShopping.CouponAPI.Repository.Interfaces
{
    public interface ICouponRepository : IBaseRepository<CouponVO, Coupon>
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
