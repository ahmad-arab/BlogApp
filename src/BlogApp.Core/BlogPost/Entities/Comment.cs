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
        public Comment(string body, BlogAppUser author, Comment parentComment)
        {
            Body = body;
            AuthorId = author.Id;
            Author = author;
            ParentCommentId = parentComment.Id;
            ParentComment = parentComment;
        }
        public Comment(string body, Guid authorId, BlogPost blogPost)
        {
            Body = body;
            AuthorId = authorId;
            BlogPostId = blogPost.Id;
            BlogPost = blogPost;
        }
        public Comment(string body, Guid authorId, Comment parentComment)
        {
            Body = body;
            AuthorId = authorId;
            ParentCommentId = parentComment.Id;
            ParentComment = parentComment;
        }
        public Comment(string body, BlogAppUser author, Guid parentId,CommentParentType commentParentType)
        {
            Body = body;
            AuthorId = author.Id;
            Author = author;
            if(commentParentType == CommentParentType.BlogPost)
            {
                BlogPostId = parentId;
            }
            else
            {
                ParentCommentId = parentId;
            }
        }

        public Comment(string body, Guid authorId, Guid parentId, CommentParentType commentParentType)
        {
            Body = body;
            AuthorId = authorId;
            if (commentParentType == CommentParentType.BlogPost)
            {
                BlogPostId = parentId;
            }
            else
            {
                ParentCommentId = parentId;
            }
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

        public Guid? BlogPostId { get; private set; }
        [ForeignKey(nameof(BlogPostId))]
        [InverseProperty(nameof(BlogPost.Comments))]
        public virtual BlogPost? BlogPost { get; private set; }

        public Guid? ParentCommentId { get; private set; }
        [ForeignKey(nameof(ParentCommentId))]
        [InverseProperty(nameof(Comment.ChildComments))]
        public virtual Comment? ParentComment { get; private set; }

        [InverseProperty(nameof(Comment.ParentComment))]
        public virtual IEnumerable<Comment>? ChildComments { get; private set; }


        [InverseProperty(nameof(CommentInteraction.Comment))]
        public virtual IEnumerable<CommentInteraction>? CommentInteractions { get; private set; }
        #endregion

        #region Actions
        public void SetBody(string body)
        {
            Body = body;
            ModifiedDate = DateTime.Now;
        }
        #endregion

    }
}
