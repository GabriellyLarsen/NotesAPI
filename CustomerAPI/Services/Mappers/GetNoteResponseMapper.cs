using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Responses;

namespace NotesAPI.Services.Mappers
{
    public interface IGetNoteResponseMapper
    {
        GetNoteResponse GetNoteResponseMap(Note noteResponse_DB);
    }

    public class GetNoteResponseMapper
    {
        private readonly IGetNoteResponseMapper _getNoteResponseMapper;
        public GetNoteResponseMapper(IGetNoteResponseMapper getNoteResponseMapper)
        {
            _getNoteResponseMapper = getNoteResponseMapper;
        }

        public GetNoteResponse GetNoteResponseMap(Note noteResponse_DB)
        {
            GetNoteResponse noteResponse = new GetNoteResponse();

            noteResponse.NoteId = noteResponse_DB.Id;
            noteResponse.Category = (Category)noteResponse_DB.CategoryId;
            noteResponse.Title = noteResponse_DB.Title;
            noteResponse.TargetDate = noteResponse_DB.TargetDate;
            noteResponse.LastUpdateDate = noteResponse_DB.LastUpdateDate;
            noteResponse.Content = noteResponse_DB.Content;

            return noteResponse;
        }
    }
}
