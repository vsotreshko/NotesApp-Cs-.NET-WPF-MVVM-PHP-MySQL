using WpfApp.Services;
using WpfApp.ViewModels.Authentication;
using WpfApp.ViewModels.Base;
using WpfApp.ViewModels.LoggedInUser;

namespace WpfApp.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// 
        /// MainWindow viewmodel is the main class in the program.
        /// It is including all other viewmodels, that will arise in program.
        /// 
        /// "SelectedViewModel" variable is using to change user controls in the main window, during program run.
        /// 
        /// "WebService" variable is including entity that allows program to make HTTP requests.
        /// 
        /// </summary>

        #region Variable to control selected view model for MainWindow
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
        #endregion

        #region Variables for all viewmodels of the program
        public LoginViewModel loginViewModel;
        public SignUpViewModel signUpViewModel;
        public UserPageViewModel userPageViewModel;
        public AddNewNoteViewModel addNewNoteViewModel;
        public EditNoteViewModel editNoteViewModel;
        #endregion

        // Web service for HTTP requests
        public WebServise WebServise;


        public MainWindowViewModel()
        {
            WebServise = new WebServise();

            loginViewModel = new LoginViewModel(this);
            signUpViewModel = new SignUpViewModel(this);
            userPageViewModel = new UserPageViewModel(this);
            addNewNoteViewModel = new AddNewNoteViewModel(this);
            editNoteViewModel = new EditNoteViewModel(this);

            SelectedViewModel = loginViewModel;
        }
    }
}
