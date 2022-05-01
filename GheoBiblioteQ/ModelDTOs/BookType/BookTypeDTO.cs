using GheoBiblioteQ._Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheoBiblioteQ.ModelDTOs.BookType
{
    public class BookTypeDTO: ViewModelBase

    {

        #region BookType ID
        private int bookTypeId;
        public int BookTypeId
        {
            get { return bookTypeId; }
            set { bookTypeId = value; OnPropertyChanged("BookTypeId"); }
        }
        #endregion

        #region BookType Name
        private string bookTypeName;

        public string BookTypeName
        {
            get { return bookTypeName; }
            set { bookTypeName = value; OnPropertyChanged("BookTypeName"); }
        }
        #endregion

        #region BookType Active
        private bool bookTypeActive;
        public bool BookTypeActive

        {
            get { return bookTypeActive; }
            set { bookTypeActive = value; OnPropertyChanged("BookTypeActive"); }
        }
        #endregion

    }
}
