using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Custom_types;
using WpfApp.Models;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class LogoutCommand : ICommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private ICommand _updateViewCommand;

        public LogoutCommand(MainWindowViewModel mainWindowViewModel)
        {
            _updateViewCommand = new UpdateViewCommand(mainWindowViewModel);
            _mainWindowViewModel = mainWindowViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.userPageViewModel.user = null;
            _mainWindowViewModel.userPageViewModel.UserNotesList = new myBindingList<Note>();
            _updateViewCommand.Execute("Login");
        }
    }
}
