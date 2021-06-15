using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    class DAO
    {
        public LibraryMangementEntities Database;
        
        public DAO()
        {
            Database = new LibraryMangementEntities();
        }


    }
}
