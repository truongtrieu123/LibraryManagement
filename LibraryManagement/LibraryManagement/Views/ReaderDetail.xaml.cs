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
using System.Windows.Shapes;

namespace LibraryManagement.Views
{
    /// <summary>
    /// Interaction logic for ReaderDetail.xaml
    /// </summary>
    public partial class ReaderDetail : Window
    {
        public ReaderDetail(long ID)
        {
            InitializeComponent();
            Console.WriteLine("ReaderDetail");
            DataContext = new ReaderDetailViewModel(ID);
        }
    }
}
