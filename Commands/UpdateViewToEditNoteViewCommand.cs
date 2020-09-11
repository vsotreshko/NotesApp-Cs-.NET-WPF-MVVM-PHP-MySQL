using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Models;
using WpfApp.ViewModels;
using WpfApp.ViewModels.LoggedInUser;

namespace WpfApp.Commands
{
    public class UpdateViewToEditNoteViewCommand : ICommand
    {
        private readonly UserPageViewModel _userPageViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private Note _noteToEdit;

        public UpdateViewToEditNoteViewCommand(UserPageViewModel userPageViewModel, MainWindowViewModel viewModel)
        {
            _userPageViewModel = userPageViewModel;
            _mainWindowViewModel = viewModel;

            _userPageViewModel.PropertyChanged += UserPageViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (_mainWindowViewModel.userPageViewModel.SelectedRow == null) return false;
            return true;
        }

        public void Execute(object parameter)
        {
            _noteToEdit = _userPageViewModel.SelectedRow;

            _mainWindowViewModel.editNoteViewModel.Title = _noteToEdit.title;
            _mainWindowViewModel.editNoteViewModel.Note = _noteToEdit.note_text;

            _mainWindowViewModel.editNoteViewModel.NoteToEdit = _noteToEdit;

            _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.editNoteViewModel;
        }

        private void UserPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
