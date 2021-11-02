using System;

namespace SEDC.WebApi.NotesApp.Services.Exceptions
{
    public class NoteException : Exception
    {
        public NoteException(string message)
            : base(message)
        {
        }
    }
}
