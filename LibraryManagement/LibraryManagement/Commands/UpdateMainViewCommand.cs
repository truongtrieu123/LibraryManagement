using LibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.Commands
{
    public class UpdateMainViewCommand:ICommand
    {
        //Mô tả cách thực một command được thực hiện
        public MainViewModel viewModel;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public UpdateMainViewCommand(MainViewModel param)
        {
            Console.WriteLine("Init");

            this.viewModel = param;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine("UpdateMainViewCommand");
            if (parameter.ToString() == "BooksList") {
                Console.WriteLine(parameter.ToString());
                viewModel.SelectedViewModel = new BooksListViewModel(viewModel);
            }
            else if (parameter.ToString()=="AddNewBook")
            {
                viewModel.SelectedViewModel = new AddNewBookViewModel(viewModel);
            }
        }
    }
}
