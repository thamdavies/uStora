using Microsoft.AspNet.Identity.EntityFramework;
using uStora.Model.Models;
using System.Data.Entity;

namespace uStora.Data
{
    public class uStoraDbContext : IdentityDbContext<ApplicationUser>
    {
        public uStoraDbContext()
            : base("uStoraConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Error> Errors { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }

        public static uStoraDbContext Create()
        {
            return new uStoraDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);
        }
    }
}