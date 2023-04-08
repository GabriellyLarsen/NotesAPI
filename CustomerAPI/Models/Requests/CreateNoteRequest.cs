using NotesAPI.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Models.Requests
{
    public class CreateNoteRequest
    {
        [Required]
        public Category Category { get; set; } 
        public string Title { get; set; }
        public DateTime? TargetDate { get; set; }
        public string Content { get; set; }

    }
}
