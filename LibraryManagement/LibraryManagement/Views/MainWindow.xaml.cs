using LibraryManagement.Views;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("MainWindow");
            DataContext = new MainViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeMenuButtonClick(object sender, RoutedEventArgs e)
        {
            HideMenu();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openMenuButtonClick(object sender, RoutedEventArgs e)
        {
            ShowMenu();
        }
        /// <summary>
        /// 
        /// </summary>
        public void ShowMenu()
        {
            if (closeMenuButton.Visibility != Visibility.Visible)
            {
                openMenuButton.Visibility = Visibility.Collapsed;
                closeMenuButton.Visibility = Visibility.Visible;
                UserAccountFrame.Visibility = Visibility.Visible;
            }
            else { }

        }
        /// <summary>
        /// 
        /// </summary>
        public void HideMenu()
        {
            if (openMenuButton.Visibility != Visibility.Visible)
            {
                openMenuButton.Visibility = Visibility.Visible;
                closeMenuButton.Visibility = Visibility.Collapsed;
                UserAccountFrame.Visibility = Visibility.Hidden;
            }
            else { }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var move = sender as System.Windows.Controls.Grid;
            var win = Window.GetWindow(move);
            win.DragMove();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimiseButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximiseButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

    }
}