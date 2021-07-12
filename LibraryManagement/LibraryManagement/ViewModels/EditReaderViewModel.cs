using LibraryManagement.Commands;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    internal class EditReaderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand AddImage { get; set; }
        public ICommand SaveChanges { get; set; }
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
                if (value != this.CategoryID)
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
            AddImage = new RelayCommand(o => AddReaderImage());
            SaveChanges = new RelayCommand(o => SaveDataInput());

            this.ID = ID;
            ReaderModel = _DAO.GetDetailReaderById(ID);

            this.ReaderName = ReaderModel.Name;
            this.Email = ReaderModel.Email;
            this.CategoryID = (long)ReaderModel.CatID;
            this.CreatedDate = ReaderModel.CreatedDate;
            this.ImageSource = AppDomain.CurrentDomain.BaseDirectory + ReaderModel.Image;
        }

        public string SaveDataInput()
        {
            string message = CheckDataInputError();
            AlertInputDataError(message);

            Reader cur = new Reader();

            if (message == null)
            {
                cur = this.GetReaderInfoFromGUI();
                Console.WriteLine(ImageSource);
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory + cur.Image);

                if (ImageSource != AppDomain.CurrentDomain.BaseDirectory + cur.Image)
                {
                    string SourcePath = ReplaceOldImageByNewImage(ID);
                }

                _DAO.UpdateReaderInfo(cur, this.ID);
                MessageBox.Show("Thay đổi thông tin thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new ReaderListViewModel(mainViewModel);
            }

            return message;
        }

        public Reader GetReaderInfoFromGUI()
        {
            Reader res = new Reader()
            {
                Name = this.ReaderName,
                Email = this.Email,
                CreatedDate = this.CreatedDate,
                CatID = this.CategoryID,
                Image = "Database\\Images\\ReaderImages\\" + this.ID.ToString() + ".png",
                ExpiryDate = this.CreatedDate.AddMonths(_DAO.CardPeriod())
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
            directory += "Database\\Images\\ReaderImages\\";
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

        public void AddReaderImage()
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
                message = "Bạn chưa chọn loại độc giả";
            }
            else if (CreatedDate == null)
            {
                message = "Bạn chưa chọn ngày làm thẻ";
            }
            else if (ReaderName == null)
                message = "Bạn chưa nhập tên của bạn";
            return message;
        }
    }
}