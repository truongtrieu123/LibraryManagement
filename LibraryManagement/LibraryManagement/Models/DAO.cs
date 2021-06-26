using LibraryManagement.ViewModels;
using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Models
{
    public class DAO
    {
        public LibraryManagementEntities Database;

        /// <summary>
        /// Hàm khởi tạo kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DAO()
        {
            Database = new LibraryManagementEntities();
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
            var cur = (from c in Database.Books
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

        public long  AddNewBook(Book bookInfo)//without book id
        {
            var books = Database.Books;
            long ID = Database.Books.Max(b => b.ID);
            ID += 1;
            bookInfo.ID = ID;
            books.Add(bookInfo);
            Database.SaveChanges();
            return ID;
        }

        public List<BookModel> GetBooks()
        {
            var bookslist = Database.Books.Join(
                Database.Categories,
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
                    CatName = c.Name
                }).ToList();

            return bookslist;
        }
        
        public void UpdateBookImageByID(long ID, string ImageSource)
        {
            Book cur = (Book)Database.Books.Where(b => b.ID == ID).SingleOrDefault();
            cur.Image = ImageSource;
            Database.SaveChanges();
        }

        public BookModel GetBookInfoById(long ID)
        {
            var bookinfo = Database.Books.Where(r => r.ID == ID).SingleOrDefault();
            string catName = GetCategoryNameByID(bookinfo.CatID);
            BookModel res = new BookModel()
            {
                Name = bookinfo.Name,
                ID = bookinfo.ID,
                CatID = bookinfo.CatID,
                CatName=catName,
                Author=bookinfo.Author,
                PublicationDate=bookinfo.PublicationDate,
                PublishingCompany=bookinfo.PublishingCompany,
                StorageState=bookinfo.StorageState,
                Location=bookinfo.Location,
                ImportDate=bookinfo.ImportDate,
                
            };
            return res;
        }

        public List<Book> SearchBookName(string text)
        {
            var query = Database.Books.Where(r => r.Name.Contains(text));
            List<Book>  booklist = query.ToList();
            return booklist;
        }
        
        #endregion Book


        #region Category
        public List<Category> GetCategories()
        {
            var Categories = Database.Categories.ToList();
            return Categories;
        }

        public void AddNewCategory(Category catInfo)
        {
            Database.Categories.Add(catInfo);
            Database.SaveChanges();
        }

        public void UpdateCategoryName(string text)
        {
            Database.SaveChanges();
        }

        public string GetCategoryNameByID(long ID)
        {
            string res = (from c in Database.Categories
                          where c.ID == ID
                          select c.Name).SingleOrDefault();
            return res;
        }
        #endregion Category


        #region  Reader
        public List<Reader> GetReaderList()
        {
            var readerlist = Database.Readers.ToList();
            return readerlist;
        }

        public Reader GetReaderInfoById(long Id)
        {
            var reader = (from r in Database.Readers
                          where r.ID == Id
                          select r).SingleOrDefault();
            return reader;
        }

        public List<Reader> SearchReaderName(string text)
        {
            var query = Database.Readers.Where(r => r.Name.Contains(text));
            List<Reader> readerlist = query.ToList();
            return readerlist;
        }

        public void ExtendExpiryDate(long Id, long TimeInterval)
        {

        }

        public bool UpdateReaderInfo(Reader info, long ID)
        {
            bool check = true;
            var cur = Database.Readers.Where(r=>r.ID==ID).SingleOrDefault();
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
            var reader = Database.Readers;
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
