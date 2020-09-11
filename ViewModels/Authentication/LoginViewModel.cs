using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.Authentication
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

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

        public ICommand LoginCommand { get; set; }
        public ICommand UpdateViewCommand { get; set; }

        public LoginViewModel (MainWindowViewModel mainWindowViewModel)
        {
            LoginCommand = new LoginCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
        }

        public void cleanLoginView()
        {
            Password = string.Empty;
            Username = string.Empty;
        }
    }
}
