using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class AddNewBookViewModel : BaseViewModel
    {
        public DAO _DAO { get; set; }
        public BookModel _bookModel { get; set; }

        public AddNewBookViewModel()
        {
            _DAO = new DAO();
        }

        public string CheckDataInputError(BookModel bookDetail)
        {
            string message = "";
            if (bookDetail.Image == "")
                message = "Bạn chưa tạo ảnh đại diện sách";
            else if (bookDetail.PublicationDate == null)
                message = "Bạn chưa chọn ngày xuất bản";
            else if (bookDetail.CatID == -1 || bookDetail.CatID == null)
                message = "Bạn chưa chọn thể loại sách";
            else if (bookDetail.Name == null ||
                bookDetail.Location == null ||
                bookDetail.PublicationDate == null ||
                bookDetail.Author == null)
                message = "Bạn chưa nhập đủ tất cả thông tin";
            else if (bookDetail.Name.Length >= 200)
                message = "Tên sách ít hơn 200 ký tự";
            else if (bookDetail.PublishingCompany.Length > 100)
                message = "Nhà xuất bản ít hơn 100 ký tự";
            else if (bookDetail.Author.Length > 200)
                message = "Tên tác giả ít hơn 200 ký tự ";
            

            return message;
        }
        
        public string StoreDataInput(BookModel bookDetail)
        {
            string message = CheckDataInputError(bookDetail);
            if(message!=null)
            {

            }

            return message;
        }
    }
}
