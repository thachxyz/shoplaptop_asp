using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend
{

    public partial class Example07Context : DbContext
    {
        public Example07Context()
        {

        }
        public Example07Context(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Category> GetCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<PostComment> PostComments { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        public virtual DbSet<Deal> Deals {get;set;}
        public virtual DbSet<ProductReview> ProductReviews { get; set; }

        public virtual DbSet<PasswordRest> PasswordRests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_banners_id");
                entity.ToTable("Banners");
            });
            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_deals_id");
                entity.ToTable("Deal");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_messages_id");
                entity.ToTable("Messages");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_coupons_id");
                entity.ToTable("Coupons");
            });
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_notifications_id");
                entity.ToTable("Notifications");
            });
            modelBuilder.Entity<Setting>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_settings_id");
                entity.ToTable("Settings");
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_categories_id");
                entity.ToTable("Categories");
                entity.HasOne(d => d.AddedByNavigation).WithMany(p => p.Categories)
                    .HasForeignKey(d => d.AddedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("categories$categories_added_by_foreign");

                entity.HasOne(d=>d.Parent).WithMany(p=>p.InverseParent)
                    .HasForeignKey(d=>d.ParentId)
                    .HasConstraintName("categories$categories_parent_by_foreign");

            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Products_id");
                entity.ToTable("Products");

                entity.HasOne(d=>d.Brand).WithMany(p=>p.Products)
                    .HasForeignKey(d=>d.BrandId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("products$products_brand_id_foregin");
                entity.HasOne(d=>d.Cat).WithMany(p=>p.Products)
                    .HasForeignKey(d=>d.CatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("products$products_cat_id_foregin");
            });
            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_post_categories_id");
                entity.ToTable("PostCategories");

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_users_id");
                entity.ToTable("Users");
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_brands_id");
                entity.ToTable("Brands");
            });
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_carts_id");
                entity.ToTable("Carts");

                entity.HasOne(d=>d.Order).WithMany(p=>p.Carts)
                    .HasForeignKey(d=>d.OrderId)
                    .HasConstraintName("carts$carts_order_id_foregin");
                entity.HasOne(d=>d.Product).WithMany(p=>p.Carts)
                    .HasForeignKey(d=>d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carts$carts_product_id_foregin");
                entity.HasOne(d=>d.User).WithMany(p=>p.Carts)
                    .HasForeignKey(d=>d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("carts$carts_user_id_foregin");
            });
           modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_orders_id");
                entity.ToTable("Orders");
                entity.HasOne(d=>d.Shipping).WithMany(p=>p.Orders)
                    .HasForeignKey(d=>d.ShippingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders$orders_shipping_id_foregin");
                entity.HasOne(d=>d.User).WithMany(p=>p.Orders)
                    .HasForeignKey(d=>d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("orders$orders_user_id_foregin");               
            });
            modelBuilder.Entity<PasswordRest>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_password_reset_id");
                entity.ToTable("PasswordResets");            
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_posts_id");
                entity.ToTable("Posts");
                entity.HasOne(e=>e.AddeByNavigation).WithMany(p=>p.Posts)
                    .HasForeignKey(d=>d.AddedBy)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("posts$posts_addeby_by_foregin");

                entity.HasOne(d=>d.PostCat).WithMany(p=>p.Posts)
                    .HasForeignKey(d=>d.PostCatId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("posts$posts_cat_id_foregin");

                entity.HasOne(d=>d.Posttag).WithMany(p=>p.Posts)
                    .HasForeignKey(d=>d.PostTagId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("posts$posts_post_tag_id_foregin");
            });
            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_post_comments_id");
                entity.ToTable("PostComments");
                entity.HasOne(e=>e.Post).WithMany(p=>p.PostComments)
                    .HasForeignKey(d=>d.PostId)
                    .HasConstraintName("post_comments$post_comments_post_id_foregin");

                entity.HasOne(d=>d.User).WithMany(p=>p.PostConmments)
                    .HasForeignKey(d=>d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("post_comments$post_comments_user_id_foregin");            
            }); 
            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_post_tags_id");
                entity.ToTable("PostTags");            
            });
            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_product_reviews_id");
                entity.ToTable("ProductReviews");  

                entity.HasOne(d=>d.Product).WithMany(p=>p.ProductReviews)
                    .HasForeignKey(d=>d.ProductId)
                    .HasConstraintName("product_reviews$product_reviews_product_id_foregin");
                entity.HasOne(d=>d.User).WithMany(p=>p.ProductReviews)
                    .HasForeignKey(d=>d.UserId)
                    .HasConstraintName("product_reviews$product_reviews_user_id_foregin");            
            });
            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_shippings_id");
                entity.ToTable("Shippings");
            });
            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_wishlists_id");
                entity.ToTable("WishLists");

                entity.HasOne(d=>d.Cart).WithMany(p=>p.WishLists)
                    .HasForeignKey(d=>d.CartId)
                    .HasConstraintName("wishlists$wishlist_cart_id_foregin");
                entity.HasOne(d=>d.Product).WithMany(p=>p.WishLists)
                    .HasForeignKey(d=>d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("wishlists$wishlist_product_id_foregin");
                entity.HasOne(d=>d.User).WithMany(p=>p.WishLists)
                    .HasForeignKey(d=>d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("wishlists$wishlist_user_id_foregin");


            });









            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);












        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Product>().HasKey(s => s.idProduct);
        //     modelBuilder.Entity<Category>().HasKey(s => s.idCategory);
        //     modelBuilder.Entity<Category>()
        //         .HasMany<Product>(s => s.Products)
        //         .WithOne(a => a.Category)
        //         .HasForeignKey(a => a.idCategory)
        //         .OnDelete(DeleteBehavior.Restrict);
        // }


    }


}