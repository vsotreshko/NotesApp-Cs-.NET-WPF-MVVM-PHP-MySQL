using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Custom_types;

namespace WpfApp.Models
{
    public class User
    {
        private string _username;
        public string Username { get; set; }

        private string _password;
        public string Password { get; set; }

        private myBindingList<Note> _userNotes;
        public myBindingList<Note> UserNotes
        {
            get { return _userNotes; }
            set { _userNotes = value; }
        }

        public User(string username, string password, myBindingList<Note> userNotes)
        {
            Username = username;
            Password = password;
            UserNotes = userNotes;
        }
    }
}
