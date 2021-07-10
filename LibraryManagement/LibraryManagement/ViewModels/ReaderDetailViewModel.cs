using LibraryManagement.DataAccess;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.ViewModels
{
    class ReaderDetailViewModel
    {
        public ReaderModel ReaderInfo { get; set; }
        public DAO DAO { get; set; }
        public ReaderDetailViewModel(long ID)
        {
            DAO = new DAO();

            ReaderInfo = DAO.GetDetailReaderById(ID);
        }
    }
}
