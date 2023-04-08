namespace NotesAPI.Models.Requests
{
    public class UpdateNoteRequest
    {
        public Category Category { get; set; }
        public string Title { get; set; }
        public DateTime? TargetDate { get; set; }
        public string Content { get; set; }
    }
}
