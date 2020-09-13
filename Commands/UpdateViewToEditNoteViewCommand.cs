using System;
using System.Windows.Input;
using WpfApp.ViewModels;
using WpfApp.ViewModels.LoggedInUser;

namespace WpfApp.Commands
{
    public class UpdateViewToEditNoteViewCommand : ICommand
    {
        private readonly UserPageViewModel _userPageViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;

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
            _mainWindowViewModel.editNoteViewModel.Title = _userPageViewModel.SelectedRow.title;
            _mainWindowViewModel.editNoteViewModel.Note = _userPageViewModel.SelectedRow.note_text;

            _mainWindowViewModel.editNoteViewModel.NoteToEdit = _userPageViewModel.SelectedRow;

            _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.editNoteViewModel;
        }

        private void UserPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
