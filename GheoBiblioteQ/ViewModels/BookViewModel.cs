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
using GheoBiblioteQ._Service.Publisher;
using GheoBiblioteQ._Commands;

namespace GheoBiblioteQ.ViewModels
{
    public class BookViewModel : ViewModelBase
    {

        private BookService bookService;

        public BookViewModel() 
        {
            bookService = new BookService();
            loadData();
            saveCommand = new CustomCommand(save);
        }

        #region Message
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        #endregion

        #region BookTitle
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
            set { stock = value; OnPropertyChanged("Stock"); }
        }
        #endregion

        #region Selected Author (full name)
        private string selectedAuthor;
        public string SelectedAuthor
        {
            get { return selectedAuthor; }
            set { selectedAuthor = value; OnPropertyChanged("SelectedAuthor"); }
        }
        #endregion

        #region Selected Publisher (name)
        private string selectedPublisher;
        public string SelectedPublisher
        {
            get { return selectedPublisher; }
            set { selectedPublisher = value; OnPropertyChanged("SelectedPublisher"); }
        }
        #endregion

        #region Selected BookType (name)
        private string selectedBookType;
        public string SelectedBookType
        {
            get { return selectedBookType; }
            set { selectedBookType = value; OnPropertyChanged("SelectedBookType"); }
        }
        #endregion

        #region Get Books
        private ObservableCollection<BookDTO> bookDTOs;
        public ObservableCollection<BookDTO> BookDTOs
        {
            get { return bookDTOs; }
            set { bookDTOs = value; OnPropertyChanged("BookDTOs");}
        }
        #endregion

        #region Get Authors Name
        private ObservableCollection<string> authorsName;

        public ObservableCollection<string> AuthorsName
        {
            get { return authorsName; }
            set { authorsName = value; OnPropertyChanged("AuthorsName"); }
        }
        #endregion

        #region Get Publishers Name
        private ObservableCollection<string> publishersName;

        public ObservableCollection<string> PublishersName
        {
            get { return publishersName; }
            set { publishersName = value; OnPropertyChanged("PublishersName"); }
        }
        #endregion

        #region Get BookTypes Name
        private ObservableCollection<string> bookTypesName;
        public ObservableCollection<string> BookTypesName
        {
            get { return bookTypesName; }
            set { bookTypesName = value; OnPropertyChanged("BookTypesName"); }
        }
        #endregion

        #region SAVE Book
        private CustomCommand saveCommand;
        public CustomCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void save()
        {

            try
            {
                bookService.addBook(title, selectedPublisher, selectedBookType, stock, selectedAuthor);
                loadData();
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
           
        }
        #endregion

        public void loadData()
        {
            BookDTOs = new ObservableCollection<BookDTO>(bookService.getAllBooks());
            AuthorsName = new ObservableCollection<string>(bookService.getAuthorsName());
            PublishersName = new ObservableCollection<string>(bookService.getPublishersName());
            BookTypesName = new ObservableCollection<string>(bookService.getBookTypesName());

        }
    }
}
