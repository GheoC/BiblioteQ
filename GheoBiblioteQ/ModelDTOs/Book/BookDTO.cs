using GheoBiblioteQ._Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheoBiblioteQ.ModelDTOs.Book
{
    public class BookDTO:ViewModelBase
    {

        #region Book ID
        private int bookId;
        public int BookId
        {
            get { return bookId; }
            set { bookId = value; OnPropertyChanged("BookId"); }
        }
        #endregion

        #region BookTypeId
        private string bookType;
        public string BookType
        {
            get { return bookType; }
            set { bookType = value; OnPropertyChanged("BookType"); }
        }
        #endregion

        #region Publisher Id
        private string publisher;
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; OnPropertyChanged("Publisher"); }
        }
        #endregion

        #region Title
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged("Title"); }
        }
        #endregion

        #region Stock
        private int stock;
        public int Stock
        {
            get { return stock; }
            set { stock = value; OnPropertyChanged("Stock");}
        }
        #endregion

        #region Book Active
        private bool bookActive;
        public bool BookActive  
        {
            get { return bookActive; }
            set { bookActive = value; OnPropertyChanged("BookActive"); }
        }
        #endregion

        #region
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; OnPropertyChanged("Author"); }
        }

        #endregion

    }
}
