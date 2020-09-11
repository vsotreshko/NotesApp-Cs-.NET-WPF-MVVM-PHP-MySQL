using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Custom_types;
using WpfApp.Models;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.LoggedInUser
{
    public class UserPageViewModel : BaseViewModel
    {
        private myBindingList<Note> _userNotesList;
        private User _user;
        
        public myBindingList<Note> UserNotesList
        {
            get { return _userNotesList; }
            set { _userNotesList = value; }
        }

        public User User;

        public UserPageViewModel()
        {
            UserNotesList = new myBindingList<Note>();

            UserNotesList.ListChanged += UserNotesList_ListChanged;
            UserNotesList.BeforeRemove += UserNotesList_BeforeRemove;
        }

        private void UserNotesList_BeforeRemove(Note deletedItem)
        {
            MessageBox.Show("Item deleted");
        }

        private void UserNotesList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {

            }

            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
            }
        }
    }
}
