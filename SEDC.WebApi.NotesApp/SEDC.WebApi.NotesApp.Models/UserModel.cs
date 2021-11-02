using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NotesApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // TODO: add token here
    }
}
