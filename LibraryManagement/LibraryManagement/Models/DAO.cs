using LibraryManagement.ViewModels;
using LibraryManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagement.Helper;
using System.ComponentModel;

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


        #region Book Services
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
                cur.Image = updateInfo.Image;
                cur.StorageState = updateInfo.StorageState;
                cur.StoredBook = updateInfo.StoredBook;
            }
            catch (Exception ex)
            {
                check = false;
            }
            Database.SaveChanges();
            return check;
        }

        public long AddNewBook(Book bookInfo)//without book id
        {
            var books = Database.Books;
            long ID = Database.Books.Max(b => b.ID);
            ID += 1;
            bookInfo.ID = ID;
            books.Add(bookInfo);
            Database.SaveChanges();
            return ID;
        }

        /// <summary>
        /// Get all books and convert to BookModel type
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get BookList with StorageState=True
        /// </summary>
        /// <returns></returns>
        public List<Book> GetNativeBooks()
        {
            return Database.Books.Where(r=>r.StorageState==true).ToList();
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
                CatName = catName,
                Author = bookinfo.Author,
                PublicationDate = bookinfo.PublicationDate,
                PublishingCompany = bookinfo.PublishingCompany,
                StorageState = bookinfo.StorageState,
                Location = bookinfo.Location,
                ImportDate = bookinfo.ImportDate,
                Image = bookinfo.Image,
            };
            return res;
        }

        public List<BookModel> SearchBookName(string text)
        {
            string normalizedText = HelperFunctions.RemovedUTF(text.ToLower());
            List<Book> booksList = Database.Books.Where(delegate (Book b)
            {
                if (HelperFunctions.RemovedUTF(b.Name.ToLower()).Contains(normalizedText))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }).ToList();

            List<BookModel> res = new List<BookModel>();
            foreach (var i in booksList)
            {
                BookModel cur = new BookModel
                {
                    ID = i.ID,
                    Name = i.Name,
                    Author = i.Author,
                    CatID = i.CatID,
                    PublicationDate = i.PublicationDate,
                    PublishingCompany = i.PublishingCompany,
                    Image = i.Image,
                    ImportDate = i.ImportDate,
                    StorageState = i.StorageState,
                    Location = i.Location,
                    CatName = Database.Categories.Where(c => c.ID == i.CatID).SingleOrDefault().Name.ToString(),
                };
                res.Add(cur);
            }

            return res;
        }

        public void SetStorageStateInBook(List<Book > bookList, bool state)
        {
            foreach(var i in bookList)
            {
                var cur = Database.Books.Where(r => r.ID == i.ID).SingleOrDefault();
                cur.StorageState = state;
                Database.SaveChanges();
            }
            Database.SaveChanges();
        }

        /// <summary>
        /// Set storage state
        /// Applied for AddBookRental ViewModel
        /// </summary>
        /// <param name="bookList"></param>
        /// <param name="state"></param>
        public void SetStorageStateInBook(BindingList<Book> bookList, bool state)
        {
            foreach(var i in bookList)
            {
                Book cur = Database.Books.Where(r => r.ID == i.ID).SingleOrDefault();
                cur.StorageState = state;
            }
            Database.SaveChanges();
        }

        #endregion Book


        #region Category Services
        public List<Category> GetCategories()
        {
            var Categories = Database.Categories.ToList();
            return Categories;
        }


        /// <summary>
        /// Get Category Model List
        /// Applied for CategoryList ViewModel 
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetCategoriesModel()
        {
            List<Category> categories = Database.Categories.ToList();
            List<CategoryModel> res = new List<CategoryModel>();
            foreach(var i in categories)
            {
                CategoryModel cur = new CategoryModel
                {
                    ID = i.ID,
                    Name = i.Name,
                    Count = Database.Books.Where(r => r.CatID == i.ID).Count(),
                };
                res.Add(cur);
            }
            return res;
        }

        public void AddNewCategory(Category catInfo)
        {
            long ID = Database.Categories.Max(r => r.ID)+1;
            catInfo.ID = ID;
            Database.Categories.Add(catInfo);
            Database.SaveChanges();
        }

        public void UpdateCategoryName(long catID, string text)
        {
            Category cur = Database.Categories.Where(r => r.ID == catID).SingleOrDefault();
            cur.Name = text;
            
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


        #region  Reader Services
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


        #region BookRentalHistory Services
        public List<BookRentalHitoryModel> GetBookRentalHitories()
        {
            List<BookRentalHitoryModel> BookRentalHitoryList = Database.BookRentalHitories.Join
                (
                    Database.Readers,
                    b => b.ReaderID,
                    r => r.ID,
                    (b, r) => new BookRentalHitoryModel 
                    {
                        ReaderID=b.ReaderID,
                        ReaderName=r.Name,
                        CreatedDate=b.CreatedDate,
                        ReturnDate=b.ReturnDate,
                        ID=b.ID,
                        State=b.State,

                    }
                ).ToList();

            return BookRentalHitoryList;
        }

        public List<BookRentalHitoryModel> SearchBookRentalHistories(string text, string stateName = "Tất cả")
        {
            //Eliminate punctuation and toLower text
            string normalizedText = "";
            if (text != null)
                normalizedText = HelperFunctions.RemovedUTF(text.ToLower());

            //Get all items list
            IQueryable<BookRentalHitoryModel> bookRentalList = (from r in Database.Readers
                                                                join b in Database.BookRentalHitories
                                                                on r.ID equals b.ReaderID
                                                                select new BookRentalHitoryModel
                                                                {
                                                                    ReaderID = b.ReaderID,
                                                                    ReaderName = r.Name,
                                                                    CreatedDate = b.CreatedDate,
                                                                    ReturnDate = b.ReturnDate,
                                                                    ID = b.ID,
                                                                    State = b.State
                                                                });

            //Search text name 
            IQueryable<BookRentalHitoryModel> searchedList = bookRentalList;
            if (normalizedText != null || normalizedText != "") {
                searchedList = bookRentalList.Where(delegate (BookRentalHitoryModel r)
                {
                    if (HelperFunctions.RemovedUTF(r.ReaderName.ToLower()).Contains(normalizedText)
                    || (r.ID.ToString().Contains(normalizedText)))
                        return true;
                    else return false;
                }).AsQueryable();
            }

            //Categorize items
            DateTime Noww = System.DateTime.Now;
            int BookBorrowTimeInterval=int.Parse(Database.Configs.Where(r=>r.Name== "SoNgayMuonToiDa").SingleOrDefault().Value);
            IQueryable<BookRentalHitoryModel> categorizedList = searchedList;
            if (stateName == "Đang mượn")
                categorizedList = searchedList.Where(r => r.State == false);
            else if (stateName == "Đã trả")
                categorizedList = searchedList.Where(r => r.State == true);
            else if (stateName == "Quá hạn")
                categorizedList = searchedList.Where(r => ((Noww-r.CreatedDate).Days > BookBorrowTimeInterval) && (r.State==false) );

            //Add items into return result;
            List <BookRentalHitoryModel> res = new List<BookRentalHitoryModel>();

            foreach (var i in categorizedList.ToList())
                res.Add(i);


            return res;
        }

        public Reader GetReaderInfoByBookRentalID(long bookRentalId)
        {
            var cur = (from brh in Database.BookRentalHitories
                          join r in Database.Readers
                          on brh.ReaderID equals r.ID
                          select new { ReaderID = r.ID, ID = brh.ID })
                             .Where(r => r.ID == bookRentalId)
                            .SingleOrDefault();
            Reader res = GetReaderInfoById(cur.ReaderID);
            return res;
        }

        public BookRentalHitory GetBookRentalHistoryByID(long BookRentalID)
        {
            BookRentalHitory res = Database.BookRentalHitories.Where(r => r.ID == BookRentalID).SingleOrDefault();
            return res;
        }

        public void SetStateInBookRental(long BookRentalID, bool state)
        {
            var cur = Database.BookRentalHitories.Where(r => r.ID == BookRentalID).SingleOrDefault();
            cur.State = state;
            Database.SaveChanges();
        }
        /// <summary>
        /// Add BookRentalHitory
        /// Applied for AddBookRental ViewModel
        /// </summary>
        /// <param name="curBookList"></param>
        /// <returns>ID</returns>
        public long AddBookRentalHitory(BookRentalHitory curBookList)
        {
            long ID = Database.BookRentalHitories.Max(r => r.ID)+1;
            
            curBookList.ID = ID;
            Database.BookRentalHitories.Add(curBookList);
            Database.SaveChanges();

            return ID;
        }

        public void SetReturnDateInBookRental(long bookRentalID, DateTime dateTime)
        {
            BookRentalHitory cur = Database.BookRentalHitories.Where(r => r.ID == bookRentalID).SingleOrDefault();
            cur.ReturnDate = dateTime;
            Database.SaveChanges();
        }
        #endregion BookRentalHistory


        #region BookRentalList Services
        /// <summary>
        /// Add bookList with specified bookRentalID
        /// Applied for AddBookRental ViewModel
        /// </summary>
        /// <param name="bookRentalID"></param>
        /// <param name="bookList"></param>
        public void AddBookRentalList(long bookRentalID, BindingList<Book> bookList)
        {
            foreach (var i in bookList)
            {
                BookRentalList cur = new BookRentalList
                {
                    BookID = i.ID,
                    BookRentalID = bookRentalID,
                };
                Database.BookRentalLists.Add(cur);
            }
            Database.SaveChanges();
        }

        public List<Book> GetBookRentalList(long BookRentalID)
        {
            List<Book> res = new List<Book>();
            var bookIDList = Database.BookRentalLists
                              .Where (o=>o.BookRentalID == BookRentalID)
                              .ToList();
            foreach(var i in bookIDList)
            {
                Book cur = Database.Books.Where(b => b.ID == i.BookID).SingleOrDefault();
                res.Add(cur);
            }
            return res;
        }

        public int CurBorrowingBookCountByReaderID(long ReaderID)
        {
            int count = 0;
            List<BookRentalHitory> bookRentalList = Database.BookRentalHitories.Where(r => (r.ReaderID == ReaderID) && (r.State == false)).ToList();
            foreach(var i in bookRentalList)
            {
                int cur = Database.BookRentalLists.Where(r => r.BookRentalID == i.ID).Count();
                count = count + cur;
            }
            return count;
        }
        #endregion

        #region Config Services
        public void GetConfigList()
        {

        }

        public int PublicationDateTimeInterval()
        {
            Config cur = Database.Configs.Where(c => c.Name == "KhoangCachNamXuatBan").SingleOrDefault();

            return int.Parse(cur.Value);
        }

        public int MaxBrowwedBookCount()
        {
            Config cur = Database.Configs.Where(c => c.Name == "SoLuongSachDuocMuonToiDa").SingleOrDefault();

            return int.Parse(cur.Value);
        }

        public void UpdateConfig()
        {

        }

        public void AddNewCondif()
        {

        }
        #endregion Config


        #region StoredBook Services
        #endregion StoredBook
    }
}
