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
    public class ConfigListViewModel:BaseViewModel
    {
        public MainViewModel mainViewModel { get; set; }
        public ICommand UpdateView { get; set; }
        public ICommand SaveChanges { get; set; }
        public DAO _DAO { get; set; }

        private string publicationYearGap;
        public string PublicationYearGap
        {
            get { return publicationYearGap; }
            set
            {
                    publicationYearGap = value;
                OnPropertyChanged(nameof(PublicationYearGap));
            }
        }

        private string maximumBorrowedTimeInterval;
        public string MaximumBorrowedTimeInterval
        {
            get { return maximumBorrowedTimeInterval; }
            set
            {
                    maximumBorrowedTimeInterval = value;
                OnPropertyChanged(nameof(MaximumBorrowedTimeInterval));
            }
        }

        private string maximumBorrowedBook;
        public string MaximumBorrowedBook
        {
            get { return maximumBorrowedBook; }
            set
            {
                    maximumBorrowedBook = value;
                OnPropertyChanged(nameof(MaximumBorrowedBook));
            }
        }

        private string cardPeriod;
        public string CardPeriod
        {
            get { return cardPeriod; }
            set
            {
                    cardPeriod = value;
                OnPropertyChanged(nameof(CardPeriod));
            }
        }

        private string ageLimit;
        public string AgeLimit
        {
            get { return ageLimit; }
            set
            {
                    ageLimit = value;
                OnPropertyChanged(nameof(AgeLimit));
            }
        }

        public ConfigListViewModel(MainViewModel param)
        {
            _DAO = new DAO();
            mainViewModel = param;
            UpdateView = new UpdateMainViewCommand(this.mainViewModel);
            AgeLimit = _DAO.AgeLimit().ToString();
            CardPeriod = _DAO.CardPeriod().ToString();
            PublicationYearGap = _DAO.PublicationDateTimeInterval().ToString();
            MaximumBorrowedBook = _DAO.MaxBrowwedBookCount().ToString();
            MaximumBorrowedTimeInterval = _DAO.MaximumBorrowedTimeInterval().ToString();
            SaveChanges = new RelayCommand(o => SaveChanges_Click());
        }

        public string CheckDataInputError()
        {
            string message = "";
            if (AgeLimit == "" || MaximumBorrowedBook == "" || PublicationYearGap == "" || CardPeriod == "" && MaximumBorrowedTimeInterval == ""
               || AgeLimit == null || MaximumBorrowedBook == null || PublicationYearGap == null || CardPeriod == null && MaximumBorrowedTimeInterval == null)
                message = "Giá trị nhập vào phải khác rỗng";
            else if (AgeLimit == "0" || MaximumBorrowedBook == "0" || PublicationYearGap == "0" || CardPeriod == "0" && MaximumBorrowedTimeInterval == "0")
                message = "Giá trị nhập và phải khác 0";
            else if (AgeLimit.Count() >3  || MaximumBorrowedBook.Count() >3  || PublicationYearGap.Count() >3  || CardPeriod.Count() >3  && MaximumBorrowedTimeInterval.Count() >3 )
                message = "Số nhập vào <1000";
            return message;
        }

        public void SaveChanges_Click()
        {
            string message = CheckDataInputError();
            AlertMessageWarning(message);
            if (message == "")
            {
                _DAO.UpdateAgeLimit(AgeLimit.ToString());
                _DAO.UpdateMaxBrowwedBookCount(MaximumBorrowedBook.ToString());
                _DAO.UpdateMaximumBorrowedTimeInterval(MaximumBorrowedTimeInterval.ToString());
                _DAO.UpdateCardPeriod(CardPeriod.ToString());
                _DAO.UpdatePublicationDateTimeInterval(PublicationYearGap.ToString());
                MessageBox.Show("Thay đổi thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }

        public void AlertMessageWarning(string message)
        {
            if (message != "" && message != null)
                MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
