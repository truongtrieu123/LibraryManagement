using LibraryManagement.Models;
using LibraryManagement.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagement
{
    
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public  DAO AppDAO;
        public static Views.BooksList BooksListPage;
        public static MainWindow mainWindow;
        public App()
        {
            AppDAO = new DAO();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }
}
