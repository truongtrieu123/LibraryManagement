using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class BookDetailViewModel
    {

        public BookModel BookModel { get; set; }
        public DAO DAO { get; set; }
        public string Title { get; set; }
        public string StorageState { get; set; }
        public BookDetailViewModel(long ID)
        {
            DAO = new DAO();

            BookModel = DAO.GetBookInfoById(ID);
            Title = "Sách " + BookModel.Name;
            if (BookModel.StorageState == true) StorageState = "Đang lưu kho";
            else StorageState = "Đang lưu hành";
        }
    }
}
