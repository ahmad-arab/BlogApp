using System.ComponentModel.DataAnnotations;

namespace BlogApp.Core
{
    public class BaseEntity
    {
        #region Fields
        [Required]
        [Key]
        public Guid Id { get; protected set; }

        [Required]
        public bool IsDeleted { get; protected set; } = false;
        public DateTime? ModifiedDate { get; protected set; }

        [Required]
        public DateTime CreatedDate { get; protected set; } = DateTime.Now;
        #endregion

        #region Actions

        public void NewId(Guid id)
        {
            Id = id;
        }

        public void NewId()
        {
            Id = Guid.NewGuid();
        }

        public void Delete()
        {
            IsDeleted = true;
            ModifiedDate = DateTime.Now;
        }

        #endregion

    }
}
