using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Custom_types;
using WpfApp.Models;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.LoggedInUser
{
    public class UserPageViewModel : BaseViewModel
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private myBindingList<Note> _userNotesList;
        private Note _selectedRow;
        

        public myBindingList<Note> UserNotesList
        {
            get { return _userNotesList; }
            set { _userNotesList = value; }
        }
        public User user;
        
        public Note SelectedRow
        {
            get { return _selectedRow; }
            set 
            {
                _selectedRow = value;
                OnPropertyChanged(nameof(SelectedRow));
            }
        }

        public ICommand LogoutCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }
        public ICommand UpdateViewToEditNoteViewCommand { get; set; }

        public UserPageViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            UpdateViewToEditNoteViewCommand = new UpdateViewToEditNoteViewCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
            LogoutCommand = new LogoutCommand(mainWindowViewModel);
            
            UserNotesList = new myBindingList<Note>();

            UserNotesList.BeforeRemove += UserNotesList_BeforeRemove;
            
        }

        private void UserNotesList_BeforeRemove(Note deletedItem)
        {
            var t = Task.Run(() => _mainWindowViewModel.webServise.DeleteNote(user.Username, user.Password, deletedItem.id));
            t.Wait();

            if (t.Result.ToString().Substring(0, 7) == "Success")
            {
                MessageBox.Show("Successfully deleted.");
            }
        }

        public void bindUserNotes()
        {
            foreach (Note note in user.UserNotes)
            {
                UserNotesList.Add(note);
            }
        }
    }
}
