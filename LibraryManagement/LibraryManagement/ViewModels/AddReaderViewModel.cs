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
    class AddReaderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveNewBook { get; set; }
        public ICommand AddImage { get; set; }
        public DAO _DAO { get; set; }

        public AddReaderViewModel(MainViewModel param)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
            //SaveNewBook = new RelayCommand(o => StoreDateInput());
            //AddImage = new RelayCommand(o => AddBookImage());
            //AllCategory = _DAO.GetCategories();

            //PublicationDateTimeInterval = _DAO.PublicationDateTimeInterval();


            //CategoryID = -1;
            //PublicationDate = System.DateTime.Now;
            //ImageSource = null;
        }
    }
}
