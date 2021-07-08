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
    public class BookRentalDetailViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand ComeBack { get; set; }
        public ICommand DoneBookRental { get; set; }
        public DAO _DAO { get; set; }

        private List<Book> _bookList;
        public List<Book> BookList
        {
            get { return _bookList; }
            set
            {
                _bookList = value;
                OnPropertyChanged(nameof(BookList));
            }
        }

        public Reader Reader { get; set; }
        public BookRentalHitory BookRentalInfo { get; set; }
        public long BookRentalID { get; set; }

        

        //Change content in DoneButtonClick
        private string _doneButtonContent;
        public string DoneButtonContent
        {
            get { return _doneButtonContent; }
            set
            {
                _doneButtonContent = value;
                OnPropertyChanged(nameof(DoneButtonContent));
            }
        }

        public long CurBorrowingBookCount { get; set; }

        public BookRentalDetailViewModel(MainViewModel param,long bookRentalID)
        {
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            ComeBack = new RelayCommand(o => ComeBack_Click());
            DoneBookRental = new RelayCommand(o => DoneBookRental_click());
            _DAO = new DAO();

            this.BookRentalID = bookRentalID;
            this.Reader = _DAO.GetReaderInfoByBookRentalID(bookRentalID);
            this.BookRentalInfo = _DAO.GetBookRentalHistoryByID(bookRentalID);
            this.BookList = _DAO.GetBookRentalList(bookRentalID);
            this.CurBorrowingBookCount = BookList.Count();

            if ((bool)this.BookRentalInfo.State)  DoneButtonContent = "Đã trả sách";
            else DoneButtonContent = "Đánh dấu trả sách";
        }

        public void ComeBack_Click ()
        {
            mainViewModel.SelectedViewModel = new BookRentalListViewModel(mainViewModel);
        }

        public void DoneBookRental_click()
        {
            if ((bool)BookRentalInfo.State==false)
            {
                _DAO.SetStateInBookRental(this.BookRentalID, true);
                _DAO.SetReturnDateInBookRental(this.BookRentalID, System.DateTime.Now);
                _DAO.SetStorageStateInBook(this.BookList, true);
                DoneButtonContent = "Đã trả sách";
                BookRentalInfo.State = true;
            }
        }
    }
}
