using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModels;
using WpfApp.ViewModels.Authentication;

namespace WpfApp.Commands
{
    public class SignUpCommand : ICommand
    {
        private readonly SignUpViewModel _signUpViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;

        private ICommand _updateViewCommand;

        public SignUpCommand(SignUpViewModel signUpViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _updateViewCommand = new UpdateViewCommand(mainWindowViewModel);

            _signUpViewModel = signUpViewModel;
            _mainWindowViewModel = mainWindowViewModel;

            _signUpViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_signUpViewModel.Username) &&
                !string.IsNullOrEmpty(_signUpViewModel.Password) &&
                !string.IsNullOrEmpty(_signUpViewModel.Email) &&
                !string.IsNullOrEmpty(_signUpViewModel.ConfirmPassword);
        }

        public async void Execute(object parameter)
        {
            if (_signUpViewModel.Password != _signUpViewModel.ConfirmPassword)
            {
                MessageBox.Show("Password and confirm password does not match.");
            }
            else
            {
                var t = Task.Run(() => _mainWindowViewModel.webServise.SignUp(_signUpViewModel.Email, _signUpViewModel.Username, _signUpViewModel.Password));
                t.Wait();
                MessageBox.Show(t.Result.ToString());

                if (t.Result.ToString() == "Success")
                {
                    _updateViewCommand.Execute("Login");
                }
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
