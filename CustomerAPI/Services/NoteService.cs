using NotesAPI.Entities;
using NotesAPI.Repositories;

namespace NotesAPI.Services
{
    public interface INoteService
    {
        //Note GetNotesByTargetDate(DateTime targetDate);
        List<Note> GetNotesByCategory(Enums.Category category);
        Task<Note> AddNote(Note createNoteRequest);
        //Note UpdateNote(Note createNoteRequest);
        //Note DeleteNote(Note createNoteRequest);
    }

    public class NoteService : INoteService
    {
        private readonly AppDbContext _appDbContext;
        public NoteService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Note> AddNote(Note createNoteRequest)
        {
            _appDbContext.Note.Add(createNoteRequest);
            await _appDbContext.SaveChangesAsync();

            return createNoteRequest;
        }

        public List<Note> GetNotesByCategory(Enums.Category category)
        {
            var result = _appDbContext.Note.Where(x => x.CategoryId == category.GetHashCode()).ToList();
            return result;
        }

    }
}
