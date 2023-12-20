using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Core
{
    public class Comment:BaseEntity
    {
        #region Constructors
        private Comment()
        {

        }

        public Comment(string body, BlogAppUser author, BlogPost blogPost)
        {
            Body = body;
            AuthorId = author.Id;
            Author = author;
            BlogPostId = blogPost.Id;
            BlogPost = blogPost;
        }
        public Comment(string body, Guid authorId, BlogPost blogPost)
        {
            Body = body;
            AuthorId = authorId;
            BlogPostId = blogPost.Id;
            BlogPost = blogPost;
        }
        public Comment(string body, BlogAppUser author, Guid blogPostId)
        {
            Body = body;
            AuthorId = author.Id;
            Author = author;
            BlogPostId = blogPostId;
        }
        public Comment(string body, Guid authorId, Guid blogPostId)
        {
            Body = body;
            AuthorId = authorId;
            BlogPostId = blogPostId;
        }

        #endregion

        #region Fields
        [Required]
        public string Body { get; private set; }

        [Required]
        public Guid AuthorId { get; private set; }
        [ForeignKey(nameof(AuthorId))]
        [InverseProperty(nameof(BlogAppUser.Comments))]
        public virtual BlogAppUser? Author { get; private set; }

        [Required]
        public Guid BlogPostId { get; private set; }
        [ForeignKey(nameof(BlogPostId))]
        [InverseProperty(nameof(BlogPost.Comments))]
        public virtual BlogPost? BlogPost { get; private set; }


        [InverseProperty(nameof(CommentInteraction.Comment))]
        public virtual IEnumerable<CommentInteraction>? CommentInteractions { get; private set; }
        #endregion

        #region Actions
        public void SetBody(string body)
        {
            Body = body;
        }
        #endregion

    }
}
