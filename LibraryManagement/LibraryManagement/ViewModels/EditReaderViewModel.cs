using LibraryManagement.Commands;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    internal class EditReaderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public DAO _DAO { get; set; }

        public long ID { get; set; }
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

        public string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (value != null)
                {
                    Console.WriteLine(value.ToString());
                    _imageSource = value;
                    OnPropertyChanged(nameof(_imageSource));
                }
            }
        }

        public ReaderModel ReaderModel { get; set; }

        public EditReaderViewModel(MainViewModel param, long ID)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);

            this.ID = ID;
            ReaderModel = _DAO.GetDetailReaderById(ID);

            this.ReaderName = ReaderModel.Name;
            this.Email = ReaderModel.Email;
            this.CategoryID = (long)ReaderModel.CatID;
            this.CreatedDate = ReaderModel.CreatedDate;
        }
    }
}