using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.Authentication
{
    public class SignUpViewModel : BaseViewModel
    {
        public ICommand SignUpCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get
            { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            { return _confirmPassword; }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public SignUpViewModel(MainWindowViewModel mainWindowViewModel)
        {
            SignUpCommand = new SignUpCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
        }

        public void CleanSignUpView()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
