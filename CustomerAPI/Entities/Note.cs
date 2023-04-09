using NotesAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Category Category { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime? TargetDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Content { get; set; }
    }
}
