using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Core
{
    public class CommentInteraction:BaseEntity
    {
        #region Constructor

        private CommentInteraction()
        {
            
        }

        public CommentInteraction(InteractionType type, BlogAppUser user, Comment comment, string? value = null)
        {
            InteractionType = type;
            User = user;
            UserId = user.Id;
            Comment = comment;
            CommentId = comment.Id;
            Value = value;
        }
        public CommentInteraction(InteractionType type, Guid userId, Comment comment, string? value = null)
        {
            InteractionType = type;
            UserId = userId;
            Comment = comment;
            CommentId = comment.Id;
            Value = value;
        }
        public CommentInteraction(InteractionType type, BlogAppUser user, Guid commentId, string? value = null)
        {
            InteractionType = type;
            User = user;
            UserId = user.Id;
            CommentId = commentId;
            Value = value;
        }
        public CommentInteraction(InteractionType type, Guid userId, Guid commentId, string? value = null)
        {
            InteractionType = type;
            UserId = userId;
            CommentId = commentId;
            Value = value;
        }

        #endregion

        #region Fields

        [EnumDataType(typeof(InteractionType))]
        public InteractionType InteractionType { get; private set; }

        [MaxLength(50)]
        public string? Value { get; private set; }


        [Required]
        public Guid UserId { get; private set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(BlogAppUser.CommentInteractions))]
        public virtual BlogAppUser? User { get; private set; }


        [Required]
        public Guid CommentId { get; private set; }
        [ForeignKey(nameof(CommentId))]
        [InverseProperty(nameof(Comment.CommentInteractions))]
        public virtual Comment? Comment { get; private set; }

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
