using LibraryManagement.Commands;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class AddCategoryViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand AddCategory { get; set; }
        public DAO _DAO { get; set; }

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        public AddCategoryViewModel(MainViewModel param)
        {
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            _DAO = new DAO();
            CategoryName = "";
            AddCategory = new RelayCommand(o => AddCategory_Click(o));
        }

        public void AddCategory_Click(object parameter)
        {
            string input = parameter.ToString();
            if(input!=null && input !="")
            {
                Category catInfo = new Category
                {
                    ID = 0,
                    Name = input,
                };
                _DAO.AddNewCategory(catInfo);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new CategoryListViewModel(mainViewModel);
            }
        }
    }
}
