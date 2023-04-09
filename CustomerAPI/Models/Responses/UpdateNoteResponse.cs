using NotesAPI.Enums;

namespace NotesAPI.Models.Responses
{
    public class UpdateNoteResponse
    {
        public int NoteId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Content { get; set; }
    }
}
