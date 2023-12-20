using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Core
{
    public class BlogAppUser:IdentityUser<Guid>
    {
        [MaxLength(50)]
        public string DisplayName { get; set; } = string.Empty;


        [InverseProperty(nameof(BlogPost.Author))]
        public virtual IEnumerable<BlogPost>? BlogPosts { get; set; }

        [InverseProperty(nameof(Comment.Author))]
        public virtual IEnumerable<Comment>? Comments { get; set; }

        [InverseProperty(nameof(BlogPostInteraction.User))]
        public virtual IEnumerable<BlogPostInteraction>? BlogPostInteractions { get; set; }

        [InverseProperty(nameof(CommentInteraction.User))]
        public virtual IEnumerable<CommentInteraction>? CommentInteractions { get; set; }
    }
}
