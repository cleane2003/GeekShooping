using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context.Seeds
{
    public static class CouponSeed
    {
        public static void SeedCoupons(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    CouponCode = "CLEANE_2026_10",
                    DiscountAmount = 10,
                },
                new Coupon
                {
                    Id = 2,
                    CouponCode = "CLEANE_2026_15",
                    DiscountAmount = 15,
                }
            );
        }
    }
}
