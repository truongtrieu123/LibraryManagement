using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess
{
    public class State
    {
        public int ID { get; set; }
        public string StateName { get; set; }
    }

    public class BookRentalHitoryModel
    {
        public long ID { get; set; }
        public long ReaderID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<bool> State { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
        public string ReaderName { get; set; }
    }
}
