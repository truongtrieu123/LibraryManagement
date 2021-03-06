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
            else if(parameter.ToString() == "ReaderList")
            {
                viewModel.SelectedViewModel = new ReaderListViewModel(viewModel);
            }
            else if(parameter.ToString() == "AddReader")
            {
                viewModel.SelectedViewModel = new AddReaderViewModel(viewModel);
            }
            else if (parameter.ToString() == "BorrowBook")
            {
                viewModel.SelectedViewModel = new BookRentalListViewModel(viewModel);
            }
            else if(parameter.ToString()=="AddBookRental")
            {
                viewModel.SelectedViewModel = new AddBookRentalViewModel(viewModel);
            }
            else if(parameter.ToString()== "CategoryList")
            {
                viewModel.SelectedViewModel = new CategoryListViewModel(viewModel);
            }
            else if (parameter.ToString() == "AddCategory")
            {
                viewModel.SelectedViewModel = new AddCategoryViewModel(viewModel);
            }
            else if (parameter.ToString() == "ConfigList")
            {
                viewModel.SelectedViewModel = new ConfigListViewModel(viewModel);
            }
            else if(parameter.ToString()=="ChartPage")
            {
                viewModel.SelectedViewModel = new ChartPageViewModel(viewModel);
            }
            else if (parameter.ToString()=="AboutUs")
            {
                viewModel.SelectedViewModel = new AboutUsViewModel(viewModel);
            }
        }
    }
}
