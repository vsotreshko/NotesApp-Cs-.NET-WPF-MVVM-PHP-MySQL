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
        private string _password;
        private myBindingList<Note> _userNotes;

        public string Username { get; set; }
        public string Password { get; set; }

        public bool isLoggedIn;

        public myBindingList<Note> UserNotes
        {
            get { return _userNotes; }
            set { _userNotes = value; }
        }

        public User(string username, string password, bool isLoggedIn, myBindingList<Note> userNotes)
        {
            Username = username;
            Password = password;
            this.isLoggedIn = isLoggedIn;
            UserNotes = userNotes;
        }
    }
}
