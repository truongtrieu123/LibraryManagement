using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    public class BookModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public long CatID { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> PublicationDate { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public Nullable<bool> StorageState { get; set; }
        public string Location { get; set; }
        public string PublishingCompany { get; set; }
        public byte[] Image { get; set; }
        public string CatName { get; set; }
    }

    public class BooksListViewModel
    {
        public List<BookModel> BooksList { get; set; }
        public DAO DAO;
        public BooksListViewModel()
        {
            DAO = new DAO();
            BooksList = DAO.GetBooks();
        }

        public List<BookModel> GetBooksList ()
        {
            return BooksList;
        }
    }
}
