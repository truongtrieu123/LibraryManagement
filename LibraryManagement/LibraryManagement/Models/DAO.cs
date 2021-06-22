using LibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LibraryManagement.Models
{
    public class DAO
    {
        public LibraryMangementEntities Database;

        /// <summary>
        /// Hàm khởi tạo kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DAO()
        {
            Database = new LibraryMangementEntities();
        }
        /// <summary>
        /// Hàm cập nhật cơ sở dữ liệu
        /// </summary>
        public void UpdateDatabase()
        {
            Database.SaveChanges();
        }


        #region Book
        public bool UpdateBookInfoByID(Book updateInfo, long ID)
        {
            bool check = true;
            var cur = (from c in Database.Book
                       where c.ID == ID
                       select c).SingleOrDefault();
            try
            {
                cur.Image = updateInfo.Image;
                cur.ImportDate = updateInfo.ImportDate;
                cur.Location = updateInfo.Location;
                cur.Name = updateInfo.Name;
                cur.PublicationDate = updateInfo.PublicationDate;
                cur.PublishingCompany = updateInfo.PublishingCompany;
                
            }
            catch(Exception ex)
            {
                check = false;
            }
            Database.SaveChanges();
            return check;
        }

        public void AddNewBook(Book bookInfo)
        {
            var books = Database.Book;
            books.Add(bookInfo);
            Database.SaveChanges();
        }

        public List<BookModel> GetBooks()
        {
            var bookslist = Database.Book.Join(
                Database.Category,
                b => b.CatID,
                c => c.ID,
                (b, c) => new BookModel()
                {
                    ID = b.ID,
                    Name = b.Name,
                    Author = b.Author,
                    Location = b.Location,
                    CatID = b.CatID,
                    ImportDate = b.ImportDate,
                    PublicationDate = b.PublicationDate,
                    PublishingCompany = b.PublishingCompany,
                    Image = b.Image,
                    CatName = c.Name
                }).ToList();

            return bookslist;
        }
        


        public Book GetBookInfoById(long ID)
        {
            var bookinfo = Database.Book.Where(r => r.ID == ID).SingleOrDefault();
            return bookinfo;
        }

        public List<Book> SearchBookName(string text)
        {
            var query = Database.Book.Where(r => r.Name.Contains(text));
            List<Book>  booklist = query.ToList();
            return booklist;
        }
        
        #endregion Book


        #region Category
        public List<Category> GetCategories()
        {
            var Categories = Database.Category.ToList();
            return Categories;
        }

        public void AddNewCategory(Category catInfo)
        {
            Database.Category.Add(catInfo);
            Database.SaveChanges();
        }

        public void UpdateCategoryName(string text)
        {
            Database.SaveChanges();
        }

        public string GetCategoryNameByID(long ID)
        {
            string res = (from c in Database.Category
                          where c.ID == ID
                          select c.Name).SingleOrDefault();
            return res;
        }
        #endregion Category


        #region  Reader
        public List<Reader> GetReaderList()
        {
            var readerlist = Database.Reader.ToList();
            return readerlist;
        }

        public Reader GetReaderInfoById(long Id)
        {
            var reader = (from r in Database.Reader
                          where r.ID == Id
                          select r).SingleOrDefault();
            return reader;
        }

        public List<Reader> SearchReaderName(string text)
        {
            var query = Database.Reader.Where(r => r.Name.Contains(text));
            List<Reader> readerlist = query.ToList();
            return readerlist;
        }

        public void ExtendExpiryDate(long Id, long TimeInterval)
        {

        }

        public bool UpdateReaderInfo(Reader info, long ID)
        {
            bool check = true;
            var cur = Database.Reader.Where(r=>r.ID==ID).SingleOrDefault();
            try
            {
                cur.Name = info.Name;
                cur.Email = info.Email;
                cur.Image = info.Image;
            }
            catch(Exception ex)
            {
                check = false;
            }
            Database.SaveChanges();
            return check;
        }

        public void AddNewReader(Reader info )
        {
            var reader = Database.Reader;
            reader.Add(info);
            Database.SaveChanges();

        }
        #endregion Reader


        #region BookRentalHistory
        #endregion BookRentalHistory


        #region Config

        public void GetConfigList()
        {

        }

        public void GetConfigById()
        {

        }

        public void UpdateConfig()
        {

        }

        public void AddNewCondif()
        {

        }
        #endregion Config


        #region StoredBook
        #endregion StoredBook
    }
}
