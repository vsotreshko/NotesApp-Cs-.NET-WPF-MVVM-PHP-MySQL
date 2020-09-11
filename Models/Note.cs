using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Models
{
    public class Note : INotifyPropertyChanged
    {
        #region Property Changed Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public DateTime creation_date { get; set; }

        private int _id;
        private string _title;
        private string _note;

        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(id));
            }
        }
        public string title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(title));
            }
        }
        public string note_text
        {
            get { return _note; }
            set
            {
                _note = value;
                OnPropertyChanged(nameof(note_text));
            }
        }
    }
}
