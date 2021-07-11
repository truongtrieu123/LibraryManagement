using LibraryManagement.Commands;
using LibraryManagement.Models;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    internal class EditReaderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public DAO _DAO { get; set; }

        public EditReaderViewModel(MainViewModel param, long iD)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
        }
    }
}