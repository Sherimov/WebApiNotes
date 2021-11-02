using SEDC.WebApi.NotesApp.DataModel;
using SEDC.WebApi.NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NotesApp.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        
        void Register(RegisterModel request);
    }
}
