using System;
using System.Windows.Input;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainWindowViewModel _mainWindowViewModel;

        public UpdateViewCommand(MainWindowViewModel viewModel)
        {
            _mainWindowViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Login")
            {
                _mainWindowViewModel.loginViewModel.CleanLoginView();
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.loginViewModel;
            }
            else if (parameter.ToString() == "SignUp")
            {
                _mainWindowViewModel.signUpViewModel.CleanSignUpView();
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.signUpViewModel;
            }
            else if (parameter.ToString() == "UserPage")
            {
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.userPageViewModel;
            }
            else if (parameter.ToString() == "AddNewNote")
            {
                _mainWindowViewModel.addNewNoteViewModel.CleanAddNewNoteView();
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.addNewNoteViewModel;
            }
            else if (parameter.ToString() == "EditNote")
            {

            }
        }
    }
}
