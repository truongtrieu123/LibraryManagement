using LibraryManagement.Commands;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class AddNewBookViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveNewBook { get; set; }
        public ICommand AddImage { get; set; }
        public DAO _DAO { get; set; }

        private string _bookName;
        public string BookName
        {
            get { return _bookName; }
            set
            {
                if (value != null)
                {
                    _bookName = value;
                    OnPropertyChanged(nameof(_bookName));
                }
            }
        }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                if (value != null)
                {
                    _author = value;
                    OnPropertyChanged(nameof(_author));
                }
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                if (value != null)
                {
                    _location = value;
                    OnPropertyChanged(nameof(_location));
                }
            }
        }

        private DateTime _publicationDate;
        public DateTime PublicationDate
        {
            get { return _publicationDate; }
            set
            {
                if (value != null)
                {
                    _publicationDate = value;
                    OnPropertyChanged(nameof(_publicationDate));
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
                    _imageSource = value;
                    OnPropertyChanged(nameof(_imageSource));
                }
            }
        }

        public string _publishingCompany;
        public string PublishingCompany
        {
            get { return _publishingCompany; }
            set
            {
                if (value != null)
                {
                    _publishingCompany = value;
                    OnPropertyChanged(nameof(_publishingCompany));
                }
            }
        }

        private List<Category> _allCategory;
        public List<Category> AllCategory
        {
            get { return _allCategory; }
            set
            {
                if (value != null)
                {
                    _allCategory = value;
                    OnPropertyChanged(nameof(_allCategory));
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

        public int PublicationDateTimeInterval { get; set; }


        public AddNewBookViewModel(MainViewModel param)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
            SaveNewBook = new RelayCommand(o => StoreDateInput());
            AddImage = new RelayCommand(o => AddBookImage());
            AllCategory = _DAO.GetCategories();

            PublicationDateTimeInterval = _DAO.PublicationDateTimeInterval();


            CategoryID = -1;
            PublicationDate = System.DateTime.Now;
            ImageSource = null;
        }

        public void AddBookImage()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                File.ReadAllText(openFileDialog.FileName);
                try
                {
                    ImageSource = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            OnPropertyChanged(nameof(ImageSource));
        }

        public string CheckDataInputError()
        {
            string message = null;
            if (ImageSource == null || ImageSource == "")
            {
                message = "Bạn chưa thêm ảnh đại diện";
            }
            else if (CategoryID == -1)
            {
                message = "Ban chưa chọn thể loại sách";
            }
            else if (PublicationDate.Year < System.DateTime.Now.Year - PublicationDateTimeInterval)
            {
                message = "Quyển sách hợp lệ có thời điểm xuất bản trong 10 năm trở lại";
            }
            else if (BookName == null || Author == null || Location == null || PublishingCompany == null
                || BookName == "" || Author == "" || Location == "" || PublishingCompany == "")
                message = "Yêu cầu nhập đầy đủ thông tin";
            return message;
        }
        public string StoreDateInput()
        {
            string message = CheckDataInputError();
            AlertInputDataError(message);

            Book cur = new Book();
            if (message == null)
            {
                cur = this.GetBookInfoFromGUI();

                long ID = 0;

                ID = _DAO.AddNewBook(cur);

                TransferSelectedImageToImageFolder(ID);

                string SourcePath = "Database\\Images\\BookImages\\" + ID.ToString() + ".png";
                Console.WriteLine(SourcePath);
                _DAO.UpdateBookImageByID(ID, SourcePath);

                MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new BooksListViewModel(mainViewModel);
            }

            return message;
        }

        public string TransferSelectedImageToImageFolder(long ID)
        {
            if (ImageSource == null)
            {
                ImageSource = "";
            }
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            directory += "Database\\Images\\BookImages\\";
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string fileName = ID.ToString() + ".png";
            string sourcePath = ImageSource;
            string targetPath = directory;
            string sourceFile = System.IO.Path.Combine(sourcePath, "");
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.IO.File.Copy(sourceFile, destFile, true);

            return destFile;
        }

        public Book GetBookInfoFromGUI()
        {
            Book res = new Book()
            {
                Name = this.BookName,
                Author = this.Author,
                Location = this.Location,
                CatID = this.CategoryID + 1,
                StorageState = false,
                ImportDate = System.DateTime.Now,
                PublishingCompany = this.PublishingCompany,
                PublicationDate = this.PublicationDate,
                StoredBook = null
            };
            return res;
        }

        public void AlertInputDataError(string message)
        {
            if (message != null)
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
