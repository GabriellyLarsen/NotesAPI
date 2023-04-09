using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Responses;

namespace NotesAPI.Services.Mappers
{
    public interface IUpdateNoteResponseMapper
    {
        UpdateNoteResponse UpdateNoteResponseMap(Note noteResponse_DB);
    }
    public class UpdateNoteResponseMapper : IUpdateNoteResponseMapper
    {
        public UpdateNoteResponse UpdateNoteResponseMap(Note updateNoteResponse_DB)
        {
            UpdateNoteResponse updateNoteResponse = new UpdateNoteResponse();

            updateNoteResponse.NoteId = updateNoteResponse_DB.Id;
            updateNoteResponse.Category = (Enums.Category)updateNoteResponse_DB.CategoryId;
            updateNoteResponse.Title = updateNoteResponse_DB.Title;
            updateNoteResponse.TargetDate = updateNoteResponse_DB.TargetDate;
            updateNoteResponse.Content = updateNoteResponse_DB.Content;
            updateNoteResponse.LastUpdateDate = DateTime.Now;

            return updateNoteResponse;
        }
    }
}
