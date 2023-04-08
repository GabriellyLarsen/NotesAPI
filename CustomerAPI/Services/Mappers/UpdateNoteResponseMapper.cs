using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Responses;

namespace NotesAPI.Services.Mappers
{
    public interface IUpdateNoteResponseMapper
    {
        UpdateNoteResponse UpdateNoteResponseMap(Note noteResponse_DB);
    }
    public class UpdateNoteResponseMapper
    {
        private readonly IUpdateNoteResponseMapper _updateNoteResponseMapper;
        public UpdateNoteResponseMapper(IUpdateNoteResponseMapper updateNoteResponseMapper)
        {
            _updateNoteResponseMapper = updateNoteResponseMapper;
        }

        public UpdateNoteResponse UpdateNoteResponseMap(Note updateNoteResponse_DB)
        {
            UpdateNoteResponse updateNoteResponse = new UpdateNoteResponse();

            updateNoteResponse.NoteId = updateNoteResponse_DB.Id;
            updateNoteResponse.Category = (Category)updateNoteResponse_DB.CategoryId;
            updateNoteResponse.Title = updateNoteResponse_DB.Title;
            updateNoteResponse.TargetDate = updateNoteResponse_DB.TargetDate;

            return updateNoteResponse;
        }
    }
}
