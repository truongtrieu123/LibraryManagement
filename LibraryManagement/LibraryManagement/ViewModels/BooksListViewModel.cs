using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.DataAccess;
using System.Windows.Input;
using LibraryManagement.Commands;
using LibraryManagement.Views;

namespace LibraryManagement.ViewModels
{
    public class BooksListViewModel : BaseViewModel
    {
        private List<BookModel> _bookList;
        public List<BookModel> BooksList
        {
            get { return _bookList; }
            set
            {
                _bookList = value;
                OnPropertyChanged(nameof(BooksList));
            }
        }

        private string _mySearchingText;
        public string MySearchingText
        {
            get
            {
                return _mySearchingText;
            }
            set
            {
                _mySearchingText = value;
                //SearchBooksName(_mySearchingText);
                //Console.WriteLine("text is null");
                OnPropertyChanged(MySearchingText);
            }
        }
        public DAO _DAO = new DAO();
        public MainViewModel mainViewModel;
        public ICommand UpdateView { get; set; }
        public ICommand ViewBookDetail { get; set; }
        public ICommand EditBook { get; set; }
        public ICommand SearchBookName { get; set; }
        public ICommand RefreshPage { get; set; }

        public BooksListViewModel()
        {
            BooksList = _DAO.GetBooks();
            MySearchingText = "";
        }

        public BooksListViewModel(MainViewModel param)
        {
            Console.WriteLine("BooksListViewModel");
            BooksList = _DAO.GetBooks();

            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            ViewBookDetail = new RelayCommand(o => ShowBookDetail(o));
            EditBook = new RelayCommand(o => EditBookInfo(o));
            SearchBookName = new RelayCommand(o => SearchBooksName(o));
            RefreshPage = new RelayCommand(o => RefreshEntirePage());
        }

        public void RefreshEntirePage()
        {
            BooksList = _DAO.GetBooks();
        }

        public void SearchBooksName(object parameter)
        {
            string text = parameter.ToString();
            List<BookModel> res;
            if (text == null || text == "")
                res = _DAO.GetBooks();
            else
                res = _DAO.SearchBookName(text);
            BooksList = res;
            Console.WriteLine(res.Count());
        }
        public void ShowBookDetail(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            Console.WriteLine("BookListViewModel");
            Console.WriteLine(ID);
            BookDetail screen = new BookDetail(ID);
            screen.Show();
        }

        public void EditBookInfo(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            Console.WriteLine("BookListViewModel");
            Console.WriteLine(ID);
            mainViewModel.SelectedViewModel = new EditBookViewModel(mainViewModel, ID);
        }
    }
}
