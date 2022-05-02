using GheoBiblioteQ._Service;
using GheoBiblioteQ._Service.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using GheoBiblioteQ.ModelDTOs.Book;
using GheoBiblioteQ.ModelDTOs.Author;
using GheoBiblioteQ._Service.Author;

namespace GheoBiblioteQ.ViewModels
{
    public class BookViewModel : ViewModelBase
    {

        private BookService bookService;
        private AuthorService authorService;

        public BookViewModel() 
        {
            bookService = new BookService();
            authorService = new AuthorService();
            loadData();
        }

        #region Get Books
        private ObservableCollection<BookDTO> bookDTOs;
        public ObservableCollection<BookDTO> BookDTOs
        {
            get { return bookDTOs; }
            set { bookDTOs = value; OnPropertyChanged("BookDTOs");}
        }
        #endregion

        #region Get Authors
        private ObservableCollection<string> authorDTOs;

        public ObservableCollection<string> AuthorDTOs
        {
            get { return authorDTOs; }
            set { authorDTOs = value; OnPropertyChanged("AuthorDTOs"); }
        }


        #endregion

        public void loadData()
        {
            BookDTOs = new ObservableCollection<BookDTO>(bookService.getAllBooks());
            List<AuthorDTO> authors = authorService.getAuthors();

            List<string> tempAuthorsName = new List<string>();

            for (int i = 0; i < authors.Count; i++)
            {
                string name = authors[i].FirstName + " " + authors[i].LastName;
                tempAuthorsName.Add(name);
            }
            AuthorDTOs = new ObservableCollection<string>(tempAuthorsName);
        }
    }
}
