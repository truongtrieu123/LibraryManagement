using LibraryManagement.DataAccess;
using LibraryManagement.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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
    /// Interaction logic for AddNewBook.xaml
    /// </summary>
    public partial class AddNewBook : UserControl
    {
        AddNewBookViewModel _mainvm { get; set; }
        BookModel _bookModel { get; set; }
        public AddNewBook()
        {
            InitializeComponent();
        }

        private void Prepare()
        {
            _mainvm = new AddNewBookViewModel();

        }

        private void AddAvatarImage_Click(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();

            // Thiết đặt bộ lọc (filter) cho file hình ảnh
            var codecs = ImageCodecInfo.GetImageEncoders();
            var sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                screen.Filter = String.Format("{0}{1}{2} ({3})|{3}", screen.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }

            screen.Filter = String.Format("{0}{1}{2} ({3})|{3}", screen.Filter, sep, "All Files", "*.*");

            screen.Title = "Choose food cover image";
            screen.FilterIndex = 2;
            screen.RestoreDirectory = true;

            if (screen.ShowDialog() == true)
            {
                var filepath = screen.FileName;
                Uri bitmap = new Uri(filepath);

                AvatarImage.ImageSource = new BitmapImage(bitmap);
                Console.WriteLine(filepath);
            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            PublicationDate.Text = null;
            bookName.Text = null;
            Author.Text = null;
            PublishingCompany.Text = null;
            Location.Text = null;
            chosenCategory.SelectedIndex = -1;
            AvatarImage.ImageSource = null;
        }

        private BookModel CrawlDataInput()
        {
            BookModel res = new BookModel();
            try
            {
                res = new BookModel()
                {
                    Name = bookName.Text,
                    Author = Author.Text,
                    PublicationDate = PublicationDate.SelectedDate,
                    PublishingCompany = PublishingCompany.Text,
                    CatID = chosenCategory.SelectedIndex,
                    CatName = chosenCategory.SelectedIndex.ToString(),
                    Location = Location.Text,
                    Image = AvatarImage.ImageSource.ToString(),
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }

        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            BookModel bookDetail = CrawlDataInput();
            string message = _mainvm.StoreDataInput(bookDetail);
            if (message != null)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ComeBack_Click(object sender, RoutedEventArgs e)
        {

        }

        private void chosenCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
