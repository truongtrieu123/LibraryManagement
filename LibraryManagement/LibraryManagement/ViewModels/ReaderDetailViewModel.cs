using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    class ReaderDetailViewModel
    {
        public ReaderModel ReaderInfo { get; set; }
        public DAO DAO { get; set; }
        public string ReaderImage { get; set; }
        public string CardStatus { get; set; }
        public string ReaderCat { get; set; }

        public ReaderDetailViewModel(long ID)
        {
            DAO = new DAO();

            ReaderInfo = DAO.GetDetailReaderById(ID);
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            ReaderImage = directory + ReaderInfo.Image;
            
            if(ReaderInfo.ExpiryDate < DateTime.Now)
            {
                CardStatus = "Đã hết hạn";
            } else
            {
                CardStatus = "Còn hạn";
            }

            if(ReaderInfo.CatID == 0)
            {
                ReaderCat = "Độc giả X";
            } else
            {
                ReaderCat = "Độc giả Y";
            }
        }
    }
}
