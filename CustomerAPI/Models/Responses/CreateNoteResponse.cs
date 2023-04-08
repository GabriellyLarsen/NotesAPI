using NotesAPI.Enums;

namespace NotesAPI.Models.Responses
{
    public class CreateNoteResponse
    {
        public string NoteId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public DateTime? TargetDate { get; set; }
        public string ResultCode { get; set; } 
        public string Message { get; set; }
    }
}
