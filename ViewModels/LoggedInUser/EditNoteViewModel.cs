using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Models;
using WpfApp.ViewModels.Base;

namespace WpfApp.ViewModels.LoggedInUser
{
    public class EditNoteViewModel : BaseViewModel
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private Note _noteToEdit;

        private string _title;
        private string _note;
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

        public Note NoteToEdit
        {
            get { return _noteToEdit; }
            set { _noteToEdit = value; }
        }

        public ICommand EditNoteCommand { get; }
        public ICommand UpdateViewCommand { get; set; }

        public EditNoteViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            EditNoteCommand = new EditNoteCommand(this, mainWindowViewModel);
            UpdateViewCommand = new UpdateViewCommand(mainWindowViewModel);
        }

        public void cleanAddNewNoteView()
        {
            _mainWindowViewModel.addNewNoteViewModel.Title = String.Empty;
            _mainWindowViewModel.addNewNoteViewModel.Note = String.Empty;
        }
    }
}
