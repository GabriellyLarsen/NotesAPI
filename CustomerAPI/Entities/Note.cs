using NotesAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Enums.Category Category => (Enums.Category)CategoryId;

        [Required]
        public virtual Category CategoryEntity { get; set; }
        
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime? TargetDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Content { get; set; }
    }
}
