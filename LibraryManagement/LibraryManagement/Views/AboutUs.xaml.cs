﻿using MaterialDesignThemes.Wpf;
using System.Data.Linq;
using System.Diagnostics;
using System.Windows.Controls;

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for AboutUs.xaml
    /// </summary>
    public partial class AboutUs : UserControl
    {

        /// <summary>
        /// Hàm khởi tạo trang
        /// </summary>
        public AboutUs()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hàm liên hệ qua facebook
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactFb_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = sender as Chip;
            var content = item.Content as TextBlock;
            var text = content.Text;

            Process.Start(@"https://m.me/" + text);
        }

        /// <summary>
        /// Hàm liên hệ qua email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactEmail_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var item = sender as Chip;
            var content = item.Content as TextBlock;
            var text = content.Text + "@gmail.com";

            Process.Start(@"mailto:" + text + "?subject=WPF.App.Cakeshop Question");
        }

        /// <summary>
        /// Hàm liên hệ qua facebook của team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TeamContactFb_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Process.Start(@"https://facebook.com/" + _mainVM.Members[0].Facebook);
            Process.Start(@"https://facebook.com/");
        }

        private void TeamContactGg_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void TeamContactGit_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
