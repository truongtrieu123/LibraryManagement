using LibraryManagement.Commands;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class AddBookRentalViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveBookRental { get; set; }
        public ICommand DeleteBook { get; set; }
        public ICommand AddBook { get; set; }
        public ICommand DoneButton { get; set; }
        public DAO _DAO { get; set; }

        public int MaxBorrowedBookCount { get; set; }

        private BindingList<Book> bookList;
        public BindingList<Book> BookList
        {
            get { return bookList; }
            set
            {
                bookList = value;
                OnPropertyChanged(nameof(BookList));
            }
        }

        private int selectedBookRentalIndex;
        public int SelectedBookRentalIndex
        {
            get { return selectedBookRentalIndex; }
            set
            {
                selectedBookRentalIndex = value;
                OnPropertyChanged(nameof(SelectedBookRentalIndex));
            }
        }

        private int selectedReaderIndex;
        public int SelectedReaderIndex
        {
            get { return selectedReaderIndex; }
            set
            {
                selectedReaderIndex = value;
                if (selectedReaderIndex != -1) {
                    long readerID = ReaderList[SelectedReaderIndex].ID;
                    CurBorrowingBookCount = _DAO.CurBorrowingBookCountByReaderID(readerID);
                }
                
                OnPropertyChanged(nameof(SelectedReaderIndex));
            }
        }

        private BindingList<Reader> readerList;
        public BindingList<Reader> ReaderList
        {
            get { return readerList; }
            set
            {
                readerList = value;
                OnPropertyChanged(nameof(readerList));
            }
        }

        private BindingList<Book> bookListDataGrid;
        public BindingList<Book> BookListDataGrid
        {
            get { return bookListDataGrid; }
            set
            {
                bookListDataGrid = value;
                OnPropertyChanged(nameof(bookListDataGrid));
            }
        }

        private DateTime createdDate;
        public DateTime CreatedDate
        {
            get { return createdDate; }
            set
            {
                createdDate = value;
                Console.WriteLine(createdDate);
                OnPropertyChanged(nameof(CreatedDate));
            }
        }


        private long _curBorrowingBookCount;
        public long CurBorrowingBookCount
        {
            get { return _curBorrowingBookCount; }
            set
            {
                _curBorrowingBookCount = value;
                OnPropertyChanged(nameof(CurBorrowingBookCount));
            }
        }


        public AddBookRentalViewModel(MainViewModel param)
        {
            mainViewModel = param;
            _DAO = new DAO();

            UpdateView =new  UpdateMainViewCommand(mainViewModel);
            AddBook = new RelayCommand(o => AddBookIntoDataGrid());
            DeleteBook = new RelayCommand(o => DeleteBookInDataGrid(o));
            DoneButton = new RelayCommand(o => DoneButton_Click());

            MaxBorrowedBookCount = _DAO.MaxBrowwedBookCount();
            List<Book> cur_book_list = _DAO.GetNativeBooks();
            List<Reader>cur_reader_list = _DAO.GetReaderList();
            BookListDataGrid = new BindingList<Book>();


            BookList = ConvertBookListToBindingList(cur_book_list);
            ReaderList = ConvertReaderListToBindingList(cur_reader_list);
            SelectedBookRentalIndex = -1;
            SelectedReaderIndex = -1;
            CreatedDate = System.DateTime.Now;
        }

        public string CheckDataInputError()
        {
            string message = "";

            if (SelectedReaderIndex == -1) {
                message = "Bạn chưa chọn độc giả";
                return message;
            }

            long ReaderID = ReaderList[SelectedReaderIndex].ID;
            CurBorrowingBookCount = _DAO.CurBorrowingBookCountByReaderID(ReaderID);
            if (BookListDataGrid.Count() + CurBorrowingBookCount > MaxBorrowedBookCount)
            {
                if (CurBorrowingBookCount == 0)
                    message = $"Chỉ được mượn tối đa {MaxBorrowedBookCount} quyển.\n Số sách hiện tại {BookListDataGrid.Count()}";
                else
                    message = $"Chỉ được mượn thêm {MaxBorrowedBookCount - CurBorrowingBookCount} quyển.\nSố sách đã mượn {CurBorrowingBookCount}.\nSố sách hiện tại {BookListDataGrid.Count()}.";
            }
            else if (BookListDataGrid.Count() == 0)
                message = "Bạn chưa chọn sách";
            return message;
        }

        public void DoneButton_Click()
        {
            String message = CheckDataInputError();
            AlertMessageWarning(message);

            if (message == "") {
                DateTime noww = System.DateTime.Now;
                BookRentalHitory bookRentalHitory = new BookRentalHitory
                {
                    ReaderID = ReaderList[SelectedReaderIndex].ID,
                    CreatedDate = new DateTime(createdDate.Year, createdDate.Month, createdDate.Day, noww.Hour, noww.Minute, noww.Second),
                    ReturnDate = null,
                    State = false,

                };
                long BookRentalID = _DAO.AddBookRentalHitory(bookRentalHitory);
                _DAO.AddBookRentalList(BookRentalID, bookListDataGrid);
                _DAO.SetStorageStateInBook(bookListDataGrid, false);
                MessageBox.Show("Thêm phiếu mượn thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new BookRentalListViewModel(mainViewModel);
            }

        }

        public void AlertMessageWarning(string message)
        {
            if(message!="" && message!=null)
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public void DeleteBookInDataGrid(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            foreach(var i in BookListDataGrid)
            {
                if(i.ID==ID)
                {
                    Book cur = i;
                    BookList.Add(cur);
                    BookListDataGrid.Remove(i); 
                    break;
                }
            }
            Console.WriteLine(BookList.Count() + " " + BookListDataGrid.Count());
        }

        public void AddBookIntoDataGrid()
        {
            if (SelectedBookRentalIndex != -1)
            {
                Book cur = BookList[SelectedBookRentalIndex];
                BookListDataGrid.Add(cur);
                BookList.RemoveAt(SelectedBookRentalIndex);
                SelectedBookRentalIndex = -1;
                Console.WriteLine(BookList.Count() + " " + BookListDataGrid.Count());
            }
        }

        public BindingList<Book> ConvertBookListToBindingList(List<Book> curList)
        {
            BindingList<Book> res = new BindingList<Book>();
            foreach (var i in curList)
                res.Add(i);
            return res;
        }

        public BindingList<Reader> ConvertReaderListToBindingList(List<Reader> curList)
        {
            BindingList<Reader> res = new BindingList<Reader>();
            foreach (var i in curList)
                res.Add(i);
            return res;
        }
    }
}
