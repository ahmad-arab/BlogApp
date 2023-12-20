using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Core
{
    public class BlogPost:BaseEntity
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Body { get; set; }

        public Guid AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        [InverseProperty(nameof(BlogAppUser.BlogPosts))]
        public virtual BlogAppUser? Author { get; set; }


        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(BlogPostCategory.BlogPosts))]
        public virtual BlogPostCategory? Category { get; set; }


        [InverseProperty(nameof(Comment.BlogPost))]
        public virtual IEnumerable<Comment>? Comments { get; set; }


        [InverseProperty(nameof(BlogPostInteraction.BlogPost))]
        public virtual IEnumerable<BlogPostInteraction>? BlogPostInteractions { get; set; }
    }
}
