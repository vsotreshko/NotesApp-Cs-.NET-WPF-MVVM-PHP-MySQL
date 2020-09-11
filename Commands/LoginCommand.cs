using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp.Custom_types;
using WpfApp.Models;
using WpfApp.ViewModels;
using WpfApp.ViewModels.Authentication;

namespace WpfApp.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;

        private ICommand _updateViewCommand;

        public LoginCommand(LoginViewModel loginViewModel, MainWindowViewModel mainWindowViewModel)
        {
            _updateViewCommand = new UpdateViewCommand(mainWindowViewModel);

            _loginViewModel = loginViewModel;
            _mainWindowViewModel = mainWindowViewModel;

            _loginViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_loginViewModel.Username) &&
                !string.IsNullOrEmpty(_loginViewModel.Password);
        }

        public void Execute(object parameter)
        {
            var t = Task.Run(() => _mainWindowViewModel.webServise.Login(_loginViewModel.Username, _loginViewModel.Password));
            t.Wait();

            if (t.Result.ToString().Substring(0, 7) == "Success")
            {
                int jsonLength = t.Result.ToString().Length - 7;
                myBindingList<Note> userNotesList = JsonConvert.DeserializeObject<myBindingList<Note>>(t.Result.ToString().Substring(7, jsonLength));
                
                _mainWindowViewModel.userPageViewModel.user = new User(_loginViewModel.Username,
                                                                        _loginViewModel.Password,
                                                                        true,
                                                                        userNotesList
                );

                _mainWindowViewModel.userPageViewModel.bindUserNotes();

                _updateViewCommand.Execute("UserPage");
            } else
            {
                MessageBox.Show(t.Result.ToString());
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
