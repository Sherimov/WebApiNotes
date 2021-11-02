using SEDC.WebApi.NotesApp.Models;
using System.Collections.Generic;

namespace SEDC.WebApi.NotesApp.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetUserNotes(int userId);
        NoteDto GetNote(int id, int userId);
        void AddNote(NoteDto request);
        void DeleteNote(int id, int userId);
    }
}
