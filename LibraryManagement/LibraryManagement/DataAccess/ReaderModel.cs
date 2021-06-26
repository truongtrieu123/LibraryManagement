using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess
{
    class ReaderModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<long> CatID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public string Image { get; set; }
    }
}
