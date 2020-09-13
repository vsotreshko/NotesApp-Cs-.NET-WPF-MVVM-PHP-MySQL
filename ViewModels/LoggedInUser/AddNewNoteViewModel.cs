using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.LoggedInUser
{
    public class AddNewNoteViewModel : BaseViewModel
    {
        public ICommand AddNewNoteCommand { get; }
        public ICommand UpdateViewCommand { get; set; }

        private readonly MainWindowViewModel _mainWindowViewModel;
        
        private string _title;
        public string Title
        {
            get
            { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _note;
        public string Note
        {
            get
            { return _note; }
            set
            {
                _note = value;
                OnPropertyChanged(nameof(Note));
            }
        }

        public AddNewNoteViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            AddNewNoteCommand = new AddNewNoteCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
        }

        public void CleanAddNewNoteView()
        {
            _mainWindowViewModel.addNewNoteViewModel.Title = String.Empty;
            _mainWindowViewModel.addNewNoteViewModel.Note = String.Empty;
        }
    }
}
