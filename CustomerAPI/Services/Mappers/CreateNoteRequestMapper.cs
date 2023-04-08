using NotesAPI.Entities;
using NotesAPI.Models.Requests;

namespace NotesAPI.Services.Mappers
{
    public interface ICreateNoteRequestMapper
    {
        Note CreateNoteRequestMap(CreateNoteRequest createNoteRequest);
    }
    public class CreateNoteRequestMapper: ICreateNoteRequestMapper
    {
        private readonly ICreateNoteRequestMapper _createNoteRequestMapper;
        public CreateNoteRequestMapper(ICreateNoteRequestMapper createNoteRequest)
        {
            _createNoteRequestMapper = createNoteRequest;
        }
        public Note CreateNoteRequestMap(CreateNoteRequest createNoteRequest)
        {
            Note noteRequest_DB = new Note();

            noteRequest_DB.CategoryId = createNoteRequest.Category.GetHashCode();
            noteRequest_DB.Title = createNoteRequest.Title;
            noteRequest_DB.TargetDate = createNoteRequest.TargetDate;
            noteRequest_DB.Content = createNoteRequest.Content;
            noteRequest_DB.CreatedDate = DateTime.Now;
            noteRequest_DB.LastUpdateDate = DateTime.Now;

            return noteRequest_DB;
        }
    }
}
