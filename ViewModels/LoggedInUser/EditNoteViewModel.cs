using System;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.LoggedInUser
{
    public class EditNoteViewModel : BaseViewModel
    {
        public ICommand EditNoteCommand { get; }
        public ICommand UpdateViewCommand { get; set; }

        private readonly MainWindowViewModel _mainWindowViewModel;

        private Note _noteToEdit;
        public Note NoteToEdit
        {
            get { return _noteToEdit; }
            set { _noteToEdit = value; }
        }

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

        public EditNoteViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            EditNoteCommand = new EditNoteCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
        }

        public void CleanAddNewNoteView()
        {
            _mainWindowViewModel.addNewNoteViewModel.Title = String.Empty;
            _mainWindowViewModel.addNewNoteViewModel.Note = String.Empty;
        }
    }
}
