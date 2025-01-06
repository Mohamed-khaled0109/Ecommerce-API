using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_API.Model
{
    public class Context : IdentityDbContext<ApplcationUser>
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> optios) : base(optios)
        {

        }



        public DbSet<ApplcationUser> Users { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<OrderDeetails> orderdeetails { get; set; }
        public DbSet<Productes> productes { get; set; }
        public DbSet<Shipping> shipping { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<ProductWithPormotions> productWithPormotions { get; set; }
        public DbSet<Promotions> promotions { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<ProductReview> productReviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data source=.;Initial catalog=ECommerceApii;Integrated security=true");
            // optionsBuilder.UseSqlServer($"Server=.;Database=Graduation;Trusted_Connection=true;TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // العلاقة One-to-Many بين Productes و OrderDeetails
            modelBuilder.Entity<OrderDeetails>()
                .HasOne(od => od.products)
                .WithMany(p => p.orderDeetails)
                .HasForeignKey(od => od.prouductid)
                .OnDelete(DeleteBehavior.Restrict); // تعطيل الحذف التتابعي

            // العلاقة بين Productes و ShoppingCart
            modelBuilder.Entity<Productes>()
                .HasOne(p => p.shoppingcart)
                .WithMany() // إذا كانت العلاقة One-to-Many
                .HasForeignKey(p => p.idShopingCar)
                .OnDelete(DeleteBehavior.Restrict); // تعطيل الحذف التتابعي

            modelBuilder.Entity<ShoppingCart>()
          .HasOne(s => s.order)
           .WithOne(o => o.shoppingcart)
          .HasForeignKey<Orders>(o => o.idshoppingcart)
          .OnDelete(DeleteBehavior.Restrict); // تعطيل الحذف التتابعي


            base.OnModelCreating(modelBuilder);
        }






    }
}
