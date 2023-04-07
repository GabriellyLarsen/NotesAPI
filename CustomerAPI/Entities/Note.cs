using NotesAPI.Enums;

namespace NotesAPI.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Content { get; set; }
    }
}
