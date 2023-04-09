using Microsoft.EntityFrameworkCore;
using NotesAPI.Entities;
using NotesAPI.Repositories;
using System.Linq;
using System.Text;

namespace NotesAPI.Services
{
    public interface INoteService
    {
        List<Note> GetNotesByTargetDate(DateTime targetDate);
        List<Note> GetNotesByCategory(Enums.Category category);
        Task<Note> AddNote(Note createNoteRequest);
        Task<Note> UpdateNote(int noteId, Note createNoteRequest);
        void DeleteNote(int noteId);
    }

    public class NoteService : INoteService
    {
        private readonly AppDbContext _appDbContext;
        public NoteService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Note> GetNotesByTargetDate(DateTime targetDate)
        {
            var result = _appDbContext.Note.Where(x => x.TargetDate == targetDate).ToList();
            return result;
        }

        public List<Note> GetNotesByCategory(Enums.Category category)
        {
            var result = _appDbContext.Note.Where(x => x.CategoryId == category.GetHashCode()).ToList();
            return result;
        }

        public async Task<Note> AddNote(Note createNoteRequest)
        {
            _appDbContext.Note.Add(createNoteRequest);
            await _appDbContext.SaveChangesAsync();

            return createNoteRequest;
        }

        public async Task<Note> UpdateNote(int noteId, Note updateNoteRequest)
        {
            Note noteToUpdate = _appDbContext.Note.SingleOrDefault(x => x.Id == noteId);
            noteToUpdate = updateNoteRequest;
            _appDbContext.SaveChanges();

            return updateNoteRequest;
        }

        public void DeleteNote(int noteId)
        {
            Note noteToDelete = _appDbContext.Note.First(x => x.Id == noteId);
            if (noteToDelete != null)
            {
                _appDbContext.Note.Remove(noteToDelete);
                _appDbContext.SaveChanges();
            }
        }
    }
}
