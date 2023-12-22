using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Core
{
    public class BlogPost:BaseEntity
    {
        #region Constructors

        private BlogPost() { }

        public BlogPost(string title, string body, Guid authorId, Guid categoryId)
        {
            Title = title;
            Body = body;
            AuthorId = authorId;
            CategoryId = categoryId;
        }

        #endregion

        #region Fields

        [Required]
        [MaxLength(100)]
        public string Title { get; private set; }

        [Required]
        public string Body { get; private set; }

        [Required]
        public bool IsPublished { get; set; } = false;

        [Required]
        public Guid AuthorId { get; private set; }
        [ForeignKey(nameof(AuthorId))]
        [InverseProperty(nameof(BlogAppUser.BlogPosts))]
        public virtual BlogAppUser? Author { get; private set; }

        [Required]
        public Guid CategoryId { get; private set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(BlogPostCategory.BlogPosts))]
        public virtual BlogPostCategory? Category { get; private set; }


        [InverseProperty(nameof(Comment.BlogPost))]
        public virtual IEnumerable<Comment>? Comments { get; private set; }


        [InverseProperty(nameof(BlogPostInteraction.BlogPost))]
        public virtual IEnumerable<BlogPostInteraction>? BlogPostInteractions { get; private set; }
        #endregion

        #region Actions
        public void SetTitle(string title) { Title = title; ModifiedDate = DateTime.Now; }   
        public void SetBody(string body) {  Body = body; ; ModifiedDate = DateTime.Now; }
        public void SetAuthor(Guid authorId) {  AuthorId = authorId; ; ModifiedDate = DateTime.Now; }
        public void SetAuthor(BlogAppUser author) { AuthorId = author.Id; Author = author; ; ModifiedDate = DateTime.Now; }
        public void SetCategory(BlogPostCategory category) { Category = category;CategoryId=category.Id; ; ModifiedDate = DateTime.Now; }
        public void SetCategory(Guid categoryId) {  CategoryId = categoryId; ; ModifiedDate = DateTime.Now; }
        public void Publish() { IsPublished=true; ModifiedDate = DateTime.Now; }
        #endregion

    }
}
