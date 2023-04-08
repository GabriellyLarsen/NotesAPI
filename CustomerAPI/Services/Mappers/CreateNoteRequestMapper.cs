using NotesAPI.Entities;
using NotesAPI.Models.Requests;

namespace NotesAPI.Services.Mappers
{
    public interface ICreateNoteRequestMapper
    {
        Note CreateNoteRequestMap(CreateNoteRequest noteRequest);
    }
    public class CreateNoteRequestMapper: ICreateNoteRequestMapper
    {
        private readonly ICreateNoteRequestMapper _createNoteRequestMapper;
        public CreateNoteRequestMapper(ICreateNoteRequestMapper createNoteRequest)
        {
            _createNoteRequestMapper = createNoteRequest;
        }
        public Note CreateNoteRequestMap(CreateNoteRequest noteRequest)
        {
            Note noteRequest_DB = new Note();

            noteRequest_DB.CategoryId = noteRequest.Category.GetHashCode();
            noteRequest_DB.Title = noteRequest.Title;
            noteRequest_DB.TargetDate = noteRequest.TargetDate;
            noteRequest_DB.Content = noteRequest.Content;
            noteRequest_DB.CreatedDate = DateTime.Now;
            noteRequest_DB.LastUpdateDate = DateTime.Now;

            return noteRequest_DB;
        }
    }
}
