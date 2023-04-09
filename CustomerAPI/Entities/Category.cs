using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
