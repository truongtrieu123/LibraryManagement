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
        public int ID = 0;
        public string Name = "Trieu2";
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
            Console.WriteLine(BooksList[0].Name);
            Console.WriteLine(BooksList[1].Name);
            Console.WriteLine(BooksList[2].Name);

        }

        public List<BookModel> GetBooksList ()
        {
            return BooksList;
        }
    }
}
