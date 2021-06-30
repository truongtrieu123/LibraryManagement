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
    public class CategoryListViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; } 
        public ICommand UpdateView { get; set; }
        public ICommand EditCategoryName { get; set; }
        public ICommand AddCategory { get; set; }
        public DAO _DAO { get; set; }

        private List<CategoryModel> categoryList;
        public List<CategoryModel> CategoryList
        {
            get { return categoryList; }
            set
            {
                categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }

        public CategoryListViewModel(MainViewModel param)
        {
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            _DAO = new DAO();

            EditCategoryName = new RelayCommand(o => EditCategoryName_Click(o));

            CategoryList = _DAO.GetCategoriesModel();
        }

        public void EditCategoryName_Click(object parameter)
        {
            long ID = long.Parse(parameter.ToString());
            mainViewModel.SelectedViewModel = new EditCategoryViewModel(mainViewModel, ID);
        }

    }
}
