using NotesAPI.Entities;
using NotesAPI.Enums;
using NotesAPI.Models.Responses;

namespace NotesAPI.Services.Mappers
{
    public interface IGetNoteResponseMapper
    {
        List<GetNoteResponse> GetNoteResponseMap(List<Note> noteResponse_DB);
    }

    public class GetNoteResponseMapper : IGetNoteResponseMapper
    {
        public List<GetNoteResponse> GetNoteResponseMap(List<Note> noteResponse_DB)
        {
            List<GetNoteResponse> noteResponseList = new List<GetNoteResponse>(); 

            foreach(Note response in noteResponse_DB)
            {
                GetNoteResponse noteResponse = new GetNoteResponse();

                noteResponse.NoteId = response.Id;
                noteResponse.Category = (Enums.Category)response.CategoryId;
                noteResponse.Title = response.Title;
                noteResponse.TargetDate = response.TargetDate;
                noteResponse.LastUpdateDate = response.LastUpdateDate;
                noteResponse.Content = response.Content;

                noteResponseList.Add(noteResponse);
            }
            
            return noteResponseList;
        }
    }
}
