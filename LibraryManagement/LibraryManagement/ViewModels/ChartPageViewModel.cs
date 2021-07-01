using LibraryManagement.Commands;
using LibraryManagement.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManagement.ViewModels
{
    public class ChartPageViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveChanges { get; set; }
        public DAO _DAO { get; set; }

        private SeriesCollection bookRentalData;
        public SeriesCollection BookRentalData
        {
            get
            {
                return bookRentalData;
            }
            set
            {
                bookRentalData = value;
                OnPropertyChanged(nameof(BookRentalData));
            }
        }
        private SeriesCollection categoryData;
        public SeriesCollection CategoryData
        {
            get
            {
                return categoryData;
            }
            set
            {
                categoryData = value;
                OnPropertyChanged(nameof(CategoryData));
            }
        }

        private SeriesCollection registredReaderData;
        public SeriesCollection RegistredReaderData
        {
            get
            {
                return registredReaderData;
            }
            set
            {
                registredReaderData = value;
                OnPropertyChanged(nameof(RegistredReaderData));
            }
        }

        public ChartPageViewModel(MainViewModel param)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
            List<int> bookRentalDataByMonth = _DAO.GetBookRentalDataByMonth(2021);
            List<(string,int)> categoryDataByYear = _DAO.GetCategoryDataByYear(2021);
            List<int> registeredReaderByMonth = _DAO.GetRegisteredReaderDataByMonth(2021);
            InitRegisteredReader(registeredReaderByMonth);
            InitBookRentalData(bookRentalDataByMonth);
            InitCategoryData(categoryDataByYear);
        }

        public void InitRegisteredReader(List<int> data)
        {
            RegistredReaderData = new SeriesCollection { };
            int currentYear = 2021;
            RegistredReaderData.Add(
                new ColumnSeries
                {
                    Title = $"Thống kê số lượt đăng ký mới theo từng tháng (năm {currentYear})",
                    Values = new ChartValues<double> { data[0], data[1], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[11] },
                });
        }

        public void InitBookRentalData(List<int> data)
        {
            BookRentalData = new SeriesCollection { };
            int currentYear = 2021;
            BookRentalData.Add(
                new ColumnSeries
                {
                    Title =$"Thống kê số phiếu mượn theo từng tháng (năm {currentYear})",
                    Values = new ChartValues<double> { data[0], data[1], data[3], data[4], data[5], data[6], data[7], data[8], data[9], data[10], data[11] },
                });
        }


        public void InitCategoryData(List<(string, int)> data)
        {
            CategoryData = new SeriesCollection { };
            foreach (var element in data)
            {
                CategoryData.Add(
                    new PieSeries
                    {
                        Title = element.Item1,
                        Values = new ChartValues<int> { element.Item2 },
                        DataLabels = true
                    });
            }
        }

        public List<string> Months
        {
            get
            {
                string[] allMonths = { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
                return new List<string>(allMonths);
            }
        }
    }
}
