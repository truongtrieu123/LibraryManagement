using LibraryManagement.Commands;
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
    class AddReaderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveReader { get; set; }
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

        public AddReaderViewModel(MainViewModel param)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);       
            SaveReader = new RelayCommand(o => StoreDataInput());
            AddImage = new RelayCommand(o => AddReaderImage());

            CategoryID = -1;
            CreatedDate = System.DateTime.Now;
            ImageSource = null;
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

        public string TransferSelectedImageToImageFolder(long ID)
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
            System.IO.File.Copy(sourceFile, destFile, true);

            return destFile;
        }

        public Reader GetReaderInfoFromGUI()
        {
            Reader res = new Reader()
            {
                Name = this.ReaderName,
                Email = this.Email,
                CreatedDate = this.CreatedDate,
                CatID = this.CategoryID,
                ExpiryDate = this.CreatedDate.AddMonths(_DAO.CardPeriod())
            };

            return res;
        }

        public void AlertInputDataError(string message)
        {
            if (message != null)
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public string StoreDataInput()
        {
            string message = CheckDataInputError();
            AlertInputDataError(message);

            Reader cur = new Reader();
            if (message == null)
            {
                cur = this.GetReaderInfoFromGUI();

                long ID = 0;

                ID = _DAO.AddNewReader(cur);

                TransferSelectedImageToImageFolder(ID);

                string SourcePath = "Database\\Images\\ReaderImages\\" + ID.ToString() + ".png";
                Console.WriteLine(SourcePath);
                _DAO.UpdateReaderImageByID(ID, SourcePath);

                MessageBox.Show("Thêm độc giả thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new ReaderListViewModel(mainViewModel);
            }

            return message;
        }
    }
}
