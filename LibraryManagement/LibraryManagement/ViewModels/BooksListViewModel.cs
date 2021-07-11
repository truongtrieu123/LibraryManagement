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
        public ICommand SelectionChanged { get; set; }

        private List<Category> categoryList;
        public List<Category> CategoryList
        {
            get { return categoryList; }
            set
            {
                categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }

        private int selectedCategory;
        public int SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

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
            SelectionChanged = new RelayCommand(o => SelectedChanged_Click(o));

            SelectedCategory = 0;
            CategoryList = _DAO.GetCategories();
            CategoryList.Insert(0, new Category { ID = 0, Name = "Tất cả" });
        }

        public void RefreshEntirePage()
        {
            BooksList = _DAO.GetBooks();
        }

        public void SearchBooksName(object parameter)
        {
            string searchingText = parameter.ToString();
            long CatID = CategoryList[SelectedCategory].ID;
            BooksList = _DAO.SearchBookName(searchingText, CatID);
        }

        public void SelectedChanged_Click(object parameter)
        {
            string searchingText = parameter.ToString();
            long CatID =CategoryList[SelectedCategory].ID;
            BooksList = _DAO.SearchBookName(searchingText, CatID);
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
