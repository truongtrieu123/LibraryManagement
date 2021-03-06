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
    public class EditBookViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveChanges { get; set; }
        public ICommand AddImage { get; set; }
        public DAO _DAO { get; set; }
        public BookModel BookModel { get; set; }
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

        public long ID { get; set; }

        public int PublicationDateTimeInterval { get; set; }

        public EditBookViewModel(MainViewModel param, long Id)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
            SaveChanges = new RelayCommand(o => SaveDataInput());
            AddImage = new RelayCommand(o => AddBookImage());
            AllCategory = _DAO.GetCategories();
            PublicationDateTimeInterval = _DAO.PublicationDateTimeInterval();

            this.ID = Id;
            BookModel = _DAO.GetBookInfoById(this.ID);

            BookName = BookModel.Name;
            Author = BookModel.Author;
            CategoryID = BookModel.CatID - 1;
            PublicationDate = (DateTime)BookModel.PublicationDate;
            PublishingCompany = BookModel.PublishingCompany;
            ImageSource = AppDomain.CurrentDomain.BaseDirectory + BookModel.Image;
            Location = BookModel.Location;
            Console.WriteLine(ImageSource);
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
        public string SaveDataInput()
        {
            string message = CheckDataInputError();
            AlertInputDataError(message);

            Book cur = new Book();
            if (message == null)
            {
                cur = this.GetBookInfoFromGUI();
                Console.WriteLine(ImageSource);
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + cur.Image);

                if(ImageSource!=AppDomain.CurrentDomain.BaseDirectory+ cur.Image)
                {
                    string SourcePath = ReplaceOldImageByNewImage(ID);
                }

                _DAO.UpdateBookInfoByID(cur, this.ID);
                MessageBox.Show("Thay đổi thông tin thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new BooksListViewModel(mainViewModel);
            }

            return message;
        }

        public Book GetBookInfoFromGUI()
        {
            Book res = new Book()
            {
                Name = this.BookName,
                Author = this.Author,
                Location = this.Location,
                CatID = this.CategoryID + 1,
                StorageState = true,
                ImportDate = this.PublicationDate,
                PublishingCompany = this.PublishingCompany,
                PublicationDate = this.PublicationDate,
                StoredBook = null,
                Image = "Database\\Images\\BookImages\\" + this.ID.ToString() + ".png",
            };
            return res;
        }

        public string ReplaceOldImageByNewImage(long ID)
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
            System.IO.File.Delete(destFile);
            System.IO.File.Copy(sourceFile, destFile, true);

            return destFile;
        }

        public void AlertInputDataError(string message)
        {
            if (message != null)
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
