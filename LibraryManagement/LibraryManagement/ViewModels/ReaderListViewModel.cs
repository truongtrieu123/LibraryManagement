using LibraryManagement.Commands;
using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using LibraryManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class ReaderListViewModel : BaseViewModel
    {
        private List<Reader> _readerList;
        public List<Reader> ReaderList
        {
            get { return _readerList; }
            set
            {
                _readerList = value;
                OnPropertyChanged(nameof(ReaderList));
            }
        }
        public DAO _DAO = new DAO();
        public MainViewModel mainViewModel;

        public ICommand UpdateView { get; set; }
        public ICommand ViewReaderDetail { get; set; }
        public ICommand EditReader { get; set; }
        public ICommand SearchReader { get; set; }

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
                OnPropertyChanged(MySearchingText);
            }
        }

        public ReaderListViewModel()
        {
            ReaderList = _DAO.GetReaderList().ToList();
        }

        public ReaderListViewModel(MainViewModel param)
        {
            Console.WriteLine("ReaderListViewModel");
            ReaderList = _DAO.GetReaderList().ToList();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            ViewReaderDetail = new RelayCommand(o => ShowReaderDetail(o));
            EditReader = new RelayCommand(o => EditReaderInfo(o));
            SearchReader = new RelayCommand(o=>SearchReaders(o));
        }

        public void ShowReaderDetail(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            Console.WriteLine("ReaderListViewModel");
            Console.WriteLine(ID);
            ReaderDetail screen = new ReaderDetail(ID);
            screen.Show();
        }

        public void EditReaderInfo(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            Console.WriteLine("ReaderListViewModel");
            Console.WriteLine(ID);
            mainViewModel.SelectedViewModel = new EditReaderViewModel(mainViewModel, ID);
        }

        public void SearchReaders(object parameter)
        {
            string searchingText = parameter.ToString();
            ReaderList = _DAO.SearchReader(searchingText);
        }
    }
}
