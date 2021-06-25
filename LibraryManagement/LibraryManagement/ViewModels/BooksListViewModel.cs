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
        public List<BookModel> BooksList { get; set; }
        public DAO _DAO = new DAO();
        public MainViewModel mainViewModel;
        public ICommand UpdateView { get; set; }
        public ICommand ViewBookDetail { get; set; }
        public ICommand EditBookInfo { get; set; }

        public BooksListViewModel()
        {
            BooksList = _DAO.GetBooks();


        }

        public BooksListViewModel(MainViewModel param)
        {
            Console.WriteLine("BooksListViewModel");
            BooksList = _DAO.GetBooks();

            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            ViewBookDetail = new RelayCommand(o => ShowBookDetail(o));
            EditBookInfo = new RelayCommand(o => ShowBookDetail(o));
        }

        public void ShowBookDetail(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            Console.WriteLine("BookListViewModel");
            Console.WriteLine(ID);
            BookDetail screen = new BookDetail(ID);
            screen.Show();
        }
    }
}
