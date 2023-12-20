using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace BlogApp.Core
{
    public class BlogPostInteraction:BaseEntity
    {
        #region Constructor

        private BlogPostInteraction()
        {

        }

        public BlogPostInteraction(InteractionType type, BlogAppUser user, BlogPost blogPost, string? value = null)
        {
            InteractionType = type;
            User = user;
            UserId = user.Id;
            BlogPost = blogPost;
            BlogPostId = blogPost.Id;
            Value = value;
        }
        public BlogPostInteraction(InteractionType type, Guid userId, BlogPost blogPost, string? value = null)
        {
            InteractionType = type;
            UserId = userId;
            BlogPost = blogPost;
            BlogPostId = blogPost.Id;
            Value = value;
        }
        public BlogPostInteraction(InteractionType type, BlogAppUser user, Guid blogPostId, string? value = null)
        {
            InteractionType = type;
            User = user;
            UserId = user.Id;
            BlogPostId = blogPostId;
            Value = value;
        }
        public BlogPostInteraction(InteractionType type, Guid userId, Guid blogPostId, string? value = null)
        {
            InteractionType = type;
            UserId = userId;
            BlogPostId = blogPostId;
            Value = value;
        }

        #endregion

        #region Fields

        [Required]
        [EnumDataType(typeof(InteractionType))]
        public InteractionType InteractionType { get; private set; }

        [MaxLength(50)]
        public string? Value { get; private set; }

        [Required]
        public Guid UserId { get; private set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(BlogAppUser.BlogPostInteractions))]
        public virtual BlogAppUser? User { get; private set; }

        [Required]
        public Guid BlogPostId { get; private set; }
        [ForeignKey(nameof(BlogPostId))]
        [InverseProperty(nameof(BlogPost.BlogPostInteractions))]
        public virtual BlogPost? BlogPost { get; private set; }

        #endregion

        #region Actions
        public void SetValue(string? newValue)
        {
            Value = newValue;
            ModifiedDate = DateTime.Now;
        }
        #endregion
    }
}
