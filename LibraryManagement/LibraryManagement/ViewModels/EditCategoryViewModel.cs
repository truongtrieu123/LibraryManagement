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
    public class EditCategoryViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand EditCategoryName { get; set; }
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
        public long CatID { get; set; }

        public EditCategoryViewModel(MainViewModel param, long catID)
        {
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(mainViewModel);
            _DAO = new DAO();
            CategoryName = _DAO.GetCategoryNameByID(catID) ;
            this.CatID = catID;
            EditCategoryName = new RelayCommand(o => EditCategoryName_Click(o));
        }

        public void EditCategoryName_Click(object parameter)
        {
            string input = parameter.ToString();
            if (input != null && input != "")
            {
                _DAO.UpdateCategoryName(this.CatID,input);
                MessageBox.Show("Chỉnh sửa thành công", "Thông báo", MessageBoxButton.OK);
                mainViewModel.SelectedViewModel = new CategoryListViewModel(mainViewModel);
            }
        }
    }
}
