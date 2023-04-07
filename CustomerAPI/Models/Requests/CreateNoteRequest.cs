using NotesAPI.Models.Enums;
using System.ComponentModel;

namespace NotesAPI.Models.Requests
{
    public class CreateNotesRequest
    {/// <summary>
    /// first create the entity, after that you do the models based on what you'd need
    /// for exercise, you could create another entity for change of schedules, 
    /// so you'd probably keep record of what you changed
    /// you'll probably use 'createdDate' for every entity, so maybe you could use inheritance. Same for Id
    /// </summary>
        public Category Category { get; set; } 
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Content { get; set; }

    }
}
