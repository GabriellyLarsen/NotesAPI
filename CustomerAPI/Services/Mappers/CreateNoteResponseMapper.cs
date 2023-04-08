using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Responses;

namespace NotesAPI.Services.Mappers
{
    public interface ICreateNoteResponseMapper
    {
        CreateNoteResponse CreateNoteResponseMap(Note noteResponse_DB);
    }
    public class CreateNoteResponseMapper : ICreateNoteResponseMapper
    {
        public CreateNoteResponse CreateNoteResponseMap(Note createNoteResponse_DB)
        {
            CreateNoteResponse createNoteResponse = new CreateNoteResponse();

            createNoteResponse.NoteId = createNoteResponse_DB.Id;
            createNoteResponse.Category = (Enums.Category)createNoteResponse_DB.CategoryId;
            createNoteResponse.Title = createNoteResponse_DB.Title;
            createNoteResponse.TargetDate = createNoteResponse_DB.TargetDate;

            return createNoteResponse;
        }
    }
}
