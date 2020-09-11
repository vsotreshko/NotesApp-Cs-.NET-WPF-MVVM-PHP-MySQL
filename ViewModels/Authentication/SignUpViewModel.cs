using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.Authentication
{
    public class SignUpViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private string _email;
        private string _confirmPassword;

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
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
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
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

        public ICommand SignUpCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public SignUpViewModel(MainWindowViewModel mainWindowViewModel)
        {
            SignUpCommand = new SignUpCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
        }

        public void cleanSignUpView()
        {
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            ConfirmPassword = string.Empty;
        }
    }
}
