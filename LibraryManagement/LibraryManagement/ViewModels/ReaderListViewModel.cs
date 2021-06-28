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
    class ReaderListViewModel : BaseViewModel
    {
        public List<Reader> ReaderList { get; set; }
        public DAO _DAO = new DAO();
        public MainViewModel mainViewModel;
        public ICommand UpdateView { get; set; }

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
        }
    }
}
