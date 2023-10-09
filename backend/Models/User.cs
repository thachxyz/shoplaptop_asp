using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public DateTime? EmailVerifieAt { get; set; }
        public string? PassWord { get; set; }
        public string? Photo { get; set; }
        public string Role { get; set; } = null!;
        public string? Provider { get; set; }
        public string? ProviderId { get; set; }
        public string Status { get; set; } = null!;
        public string? RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public virtual ICollection<Cart> Carts { get; } = new List<Cart>();
        public virtual ICollection<Category> Categories { get; } = new List<Category>();
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public virtual ICollection<PostComment> PostConmments { get; } = new List<PostComment>();
        public virtual ICollection<Post> Posts { get; } = new List<Post>();
        public virtual ICollection<ProductReview> ProductReviews { get; } = new List<ProductReview>();
        public virtual ICollection<WishList> WishLists { get; } = new List<WishList>();
    }
}