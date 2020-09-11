using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.ViewModels;
using WpfApp.ViewModels.LoggedInUser;

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
                _mainWindowViewModel.loginViewModel.cleanLoginView();
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.loginViewModel;
            }
            else if (parameter.ToString() == "SignUp")
            {
                _mainWindowViewModel.signUpViewModel.cleanSignUpView();
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.signUpViewModel;
            }
            else if (parameter.ToString() == "UserPage")
            {
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.userPageViewModel;
            }
            else if (parameter.ToString() == "AddNewNote")
            {
                _mainWindowViewModel.addNewNoteViewModel.cleanAddNewNoteView();
                _mainWindowViewModel.SelectedViewModel = _mainWindowViewModel.addNewNoteViewModel;
            }
            else if (parameter.ToString() == "EditNote")
            {

            }
        }
    }
}
