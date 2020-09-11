using WpfApp.Commands;
using WpfApp.Services;
using WpfApp.ViewModels.Authentication;
using WpfApp.ViewModels.Base;
using WpfApp.ViewModels.LoggedInUser;

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
        public SignUpViewModel signUpViewModel;

        public UserPageViewModel userPageViewModel;
        //public AddNoteViewModel addNoteViewModel;
        #endregion

        public WebServise webServise;

        public MainWindowViewModel()
        {
            webServise = new WebServise();

            loginViewModel = new LoginViewModel(this);
            signUpViewModel = new SignUpViewModel(this);

            SelectedViewModel = loginViewModel;
        }
    }
}
