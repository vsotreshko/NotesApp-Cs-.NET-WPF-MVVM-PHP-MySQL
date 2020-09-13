using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Custom_types;
using WpfApp.Models;
using WpfApp.ViewModels;
using WpfApp.ViewModels.LoggedInUser;

namespace WpfApp.Commands
{
    public class AddNewNoteCommand : ICommand
    {
        private readonly AddNewNoteViewModel _addNewNoteViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private ICommand _updateViewCommand;

        public AddNewNoteCommand(AddNewNoteViewModel addNoteViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _updateViewCommand = new UpdateViewCommand(mainWindowViewModel);

            _addNewNoteViewModel = addNoteViewModel;
            _mainWindowViewModel = mainWindowViewModel;

            _addNewNoteViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_addNewNoteViewModel.Title) &&
                !string.IsNullOrEmpty(_addNewNoteViewModel.Note);
        }

        public void Execute(object parameter)
        {
            string username = _mainWindowViewModel.userPageViewModel.User.Username;
            string password = _mainWindowViewModel.userPageViewModel.User.Password;
            string noteTitle = _addNewNoteViewModel.Title;
            string noteText = _addNewNoteViewModel.Note;

            var t = Task.Run(() => _mainWindowViewModel.WebServise.AddNote(username, password, noteTitle, noteText));
            t.Wait();

            if (t.Result.ToString().Substring(0, 7) == "Success")
            {
                int jsonLength = t.Result.ToString().Length - 7;
                myBindingList<Note> addedNote = JsonConvert.DeserializeObject<myBindingList<Note>>(t.Result.ToString().Substring(7, jsonLength));


                _mainWindowViewModel.userPageViewModel.UserNotesList.Add(addedNote[0]);
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
