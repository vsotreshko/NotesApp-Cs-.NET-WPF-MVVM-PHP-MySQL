using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.ViewModels;
using WpfApp.ViewModels.LoggedInUser;

namespace WpfApp.Commands
{
    public class EditNoteCommand : ICommand
    {
        private readonly EditNoteViewModel _editNoteViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private ICommand _updateViewCommand;

        public EditNoteCommand(EditNoteViewModel editNoteViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _updateViewCommand = new UpdateViewCommand(mainWindowViewModel);

            _editNoteViewModel = editNoteViewModel;
            _mainWindowViewModel = mainWindowViewModel;

            _editNoteViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_editNoteViewModel.Title) &&
                !string.IsNullOrEmpty(_editNoteViewModel.Note);
        }

        public void Execute(object parameter)
        {
            string username = _mainWindowViewModel.userPageViewModel.user.Username;
            string password = _mainWindowViewModel.userPageViewModel.user.Password;
            int noteId = _editNoteViewModel.NoteToEdit.id;
            string noteTitle = _editNoteViewModel.Title;
            string noteText = _editNoteViewModel.Note;

            var t = Task.Run(() => _mainWindowViewModel.webServise.EditNote(username, password, noteId, noteTitle, noteText));
            t.Wait();

            if (t.Result.ToString().Substring(0, 7) == "Success")
            {
                //Note editedNote = _mainWindowViewModel.userPageViewModel.UserNotesList.SingleOrDefault(p => p.id == noteId);

                //Note editedNote = _mainWindowViewModel.userPageViewModel.UserNotesList.Where(x => (x.id == noteId)).ToList();
                var editedNote = _mainWindowViewModel.userPageViewModel.UserNotesList.Select((Item, Index) => new { Item, Index }).LastOrDefault(x => x.Item.id == noteId);

                if (editedNote != null)
                {
                    _mainWindowViewModel.userPageViewModel.UserNotesList[editedNote.Index] = new Note() {
                        id = noteId,
                        creation_date = editedNote.Item.creation_date,
                        title = noteTitle,
                        note_text = noteText
                    };
                }

                _updateViewCommand.Execute("UserPage");
            }
            else
            {
                MessageBox.Show(t.Result.ToString());
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

    }
}
