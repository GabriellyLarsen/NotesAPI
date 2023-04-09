using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using NotesAPI.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NotesAPI.Models.Requests
{
    public class CreateNoteRequest
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public Category Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime? TargetDate { get; set; }
        public string Content { get; set; }

    }
}
