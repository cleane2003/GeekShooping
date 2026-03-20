using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCouponByCode(string couponCode, string token);
    }
}
