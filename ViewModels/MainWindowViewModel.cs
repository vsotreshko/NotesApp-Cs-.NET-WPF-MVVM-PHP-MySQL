using System.Windows.Input;

using WpfApp.Commands;
using WpfApp.ViewModels.Authentication;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region View models
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public LoginViewModel loginViewModel;
        //public SignUpViewModel signUpViewModel;
        //public UserPageViewModel userPageViewModel;
        //public AddNoteViewModel addNoteViewModel;
        #endregion

        public ICommand UpdateViewCommand { get; set; }

        public MainWindowViewModel()
        {
            loginViewModel = new LoginViewModel(this);

            UpdateViewCommand = new UpdateViewCommand(this);

            UpdateViewCommand.Execute("Login");
        }
    }
}
