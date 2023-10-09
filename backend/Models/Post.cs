using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Post
    {
        public long Id { get; set; }
        public string Title { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string? Description { get; set; }
        public string? Quote { get; set; }
        public string? Photo { get; set; }
        public string? Tags { get; set; }
        public long? PostCatId { get; set; }
        public long? PostTagId { get; set; }
        public long? AddedBy { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual User? AddeByNavigation { get; set; }
        public virtual PostCategory? PostCat { get; set; }
        public virtual ICollection<PostComment> PostComments { get; } = new List<PostComment>();
        public virtual PostTag? Posttag { get; set; }
    }
}