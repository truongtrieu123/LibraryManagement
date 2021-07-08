using LibraryManagement.Commands;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class BookRentalStateViewModel 
    {
        public static List<State> StateCategoryList { get; set; } = new List<State>()
        {
            new State{StateName="Tất cả",ID=0 },
            new State{StateName="Đang mượn",ID=1 },
            new State{StateName="Đã trả",ID=2 },
            new State{StateName="Quá hạn",ID=3 },
        };
    }

    public class BookRentalListViewModel : BaseViewModel
    {
        public DAO _DAO = new DAO();
        public MainViewModel mainViewModel;
        public ICommand UpdateView { get; set; }
        public ICommand AddNewBookRental { get; set; }
        public ICommand EditBookRental { get; set; }
        public ICommand BookRentalDetail { get; set; }
        public ICommand SearchBookRental { get; set; }
        public ICommand SelectedStateChanged { get; set; }
        public ICommand EditBookRentalInfo { get; set; }
        public List<BookRentalHitoryModel> _bookRentalList;
        public List<BookRentalHitoryModel> BookRentalList
        {
            get { return _bookRentalList; }
            set
            {
                _bookRentalList = value;
                OnPropertyChanged(nameof(BookRentalList));
            }
        }

        public List<State> StateCategoryList { get; set; }

        public int _selectedState;
        public int SelectedState
        {
            get { return _selectedState; }
            set
            {
                _selectedState = value;
                OnPropertyChanged(nameof(SelectedState));
            }
        }

        public string _searchingText;
        public string SearchingText
        {
            get { return _searchingText; }
            set
            {
                _searchingText = value;
                OnPropertyChanged(SearchingText);
            }
        }

        public BookRentalListViewModel(MainViewModel param)
        {
            this.mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            _DAO = new DAO();
            BookRentalList = _DAO.GetBookRentalHitories();
            SearchBookRental = new RelayCommand(o => SearchBookRentalName(o));
            SelectedStateChanged = new RelayCommand(o => SelectedStateChanged_Click(o));
            EditBookRentalInfo = new RelayCommand(o => EditBookRetalInfo_click(o));
            SelectedState = 0;
            StateCategoryList = BookRentalStateViewModel.StateCategoryList;
            SearchingText = null;
        }

        public void EditBookRetalInfo_click(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            mainViewModel.SelectedViewModel = new BookRentalDetailViewModel(mainViewModel, ID);
               
        }

        public void SearchBookRentalName(object parameter)
        {
            string searchingText = parameter.ToString();
            string StateName = StateCategoryList[SelectedState].StateName;
            Console.WriteLine(SearchingText);

            BookRentalList = _DAO.SearchBookRentalHistories(SearchingText,StateName);
        }


        public void SelectedStateChanged_Click(object parameter)
        {
            string searchingText = parameter.ToString();
            string StateName = StateCategoryList[SelectedState].StateName;
            Console.WriteLine(StateName);
            Console.WriteLine(SearchingText);
            BookRentalList = _DAO.SearchBookRentalHistories(SearchingText,StateName);
        }
    }
}
