using LibraryManagement.Commands;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    class AddReaderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveNewBook { get; set; }
        public ICommand AddImage { get; set; }
        public DAO _DAO { get; set; }

        private string _readerName;
        public string ReaderName
        {
            get { return _readerName; }
            set
            {
                if (value != null)
                {
                    _readerName = value;
                    OnPropertyChanged(nameof(_readerName));
                }
            }
        }

        private DateTime _createDate;
        public DateTime CreatedDate
        {
            get { return _createDate; }
            set
            {
                if (value != null)
                {
                    _createDate = value;
                    OnPropertyChanged(nameof(_createDate));
                }
            }
        }

        private long _categoryID;
        public long CategoryID
        {
            get { return _categoryID; }
            set
            {
                if (value != this._categoryID)
                {
                    _categoryID = value;
                    OnPropertyChanged(nameof(_categoryID));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value != null)
                {
                    _email = value;
                    OnPropertyChanged(nameof(_email));
                }
            }
        }

        public AddReaderViewModel(MainViewModel param)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
            //SaveNewBook = new RelayCommand(o => StoreDateInput());
            //AddImage = new RelayCommand(o => AddBookImage());
            //AllCategory = _DAO.GetCategories();

            //PublicationDateTimeInterval = _DAO.PublicationDateTimeInterval();


            CategoryID = -1;
            //PublicationDate = System.DateTime.Now;
            //ImageSource = null;
        }
    }
}
