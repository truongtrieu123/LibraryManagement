using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for BooksList.xaml
    /// </summary>
    public partial class BooksList : Page
    {
        List<BookModel> booksList;
        BooksListViewModel _mainvm;
        public BooksList()
        {
            
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            _mainvm = new BooksListViewModel();
            booksList = _mainvm.GetBooksList();
            BooksListDatagrid.ItemsSource = booksList;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewBook_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewBook_Click(object sender, RoutedEventArgs e)
        {
            if(BooksListDatagrid.SelectedIndex!=-1)
            {
                int index = BooksListDatagrid.SelectedIndex;
                BookModel obj = booksList[index];
                Console.WriteLine(obj.Name);
             
            }
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            if (BooksListDatagrid.SelectedIndex != -1)
            {
                int index = BooksListDatagrid.SelectedIndex;
                BookModel obj = booksList[index];
                Console.WriteLine(obj.Name);

            }
        }
    }
}
