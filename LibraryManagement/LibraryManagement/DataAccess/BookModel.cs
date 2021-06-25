using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess
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
        public string Image { get; set; }
        public string CatName { get; set; }
    }
}
