using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace BlogApp.Core
{
    public class BlogPostCategory:BaseEntity
    {
        #region Constructors
        private BlogPostCategory()
        {
            Name = string.Empty;
        }

        public BlogPostCategory(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("name");
            Name = name;
        }

        #endregion

        #region Fields

        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }

        public Guid? ParentId { get; private set; }
        [ForeignKey(nameof(ParentId))]
        [InverseProperty(nameof(Children))]
        public virtual BlogPostCategory? Parent { get; private set; }


        [InverseProperty(nameof(Parent))]
        public virtual IEnumerable<BlogPostCategory>? Children { get; private set; }


        [InverseProperty(nameof(BlogPost.Category))]
        public virtual IEnumerable<BlogPost>? BlogPosts { get; private set; }

        #endregion

        #region Actions
        public void SetName(string newName)
        {
            if (string.IsNullOrEmpty(newName)) throw new ArgumentNullException("newName");
            Name = newName;
            ModifiedDate = DateTime.Now;
        }

        public void SetParent(BlogPostCategory newParent)
        {
            if(newParent == null) throw new ArgumentNullException("newParent");
            Parent = newParent;
            ParentId = newParent.Id;
            ModifiedDate = DateTime.Now;
        }

        public void SetParentId(Guid newParentId)
        {
            ParentId = newParentId;
            ModifiedDate = DateTime.Now;
        }

        #endregion

    }
}
