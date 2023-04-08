using NotesAPI.Entities;
using NotesAPI.Models.Requests;
using NotesAPI.Models.Responses;

namespace NotesAPI.Services.Mappers
{
    public interface IUpdateNoteRequestMapper
    {
        Note UpdateNoteRequestMap(UpdateNoteRequest updateNoteRequest);
    }
    public class UpdateNoteRequestMapper
    {
        private readonly IUpdateNoteRequestMapper _updateNoteResponseMapper;
        public UpdateNoteRequestMapper(IUpdateNoteRequestMapper updateNoteResponseMapper)
        {
            _updateNoteResponseMapper = updateNoteResponseMapper;
        }

        public Note UpdateNoteRequestMap(UpdateNoteRequest updateNoteRequest)
        {
            Note noteRequest_DB = new Note();

            noteRequest_DB.CategoryId = updateNoteRequest.Category.GetHashCode();
            noteRequest_DB.Title = updateNoteRequest.Title;
            noteRequest_DB.TargetDate = updateNoteRequest.TargetDate;
            noteRequest_DB.Content = updateNoteRequest.Content;
            noteRequest_DB.LastUpdateDate = DateTime.Now;

            return noteRequest_DB;
        }
    }
}
