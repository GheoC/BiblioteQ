using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ.Model;
using GheoBiblioteQ.ModelDTOs.Book;

namespace GheoBiblioteQ._Service.Book
{
    public class BookService
    {
        private biblioteqEntities biblioteqEntities;

        public BookService() 
        {
            biblioteqEntities = new biblioteqEntities();
        }

        #region Get All Books
        public List<BookDTO> getAllBooks() 
        {
            List<BookDTO> books = new List<BookDTO>();

            List<Model.Book> booksFromDB = biblioteqEntities.Books.ToList();
           

            for (int i = 0; i < booksFromDB.Count; i++)
            {
                BookDTO bookDTO = new BookDTO();

                bookDTO.BookId = booksFromDB[i].book_id;

                bookDTO.Title = booksFromDB[i].title;

                bookDTO.Publisher = booksFromDB[i].Publisher.name;

                bookDTO.BookType = booksFromDB[i].BookType.name;

                bookDTO.Stock = booksFromDB[i].stock;

                List<AuthorBook> authorBooks = biblioteqEntities.AuthorBooks.ToList();

                bookDTO.Author = "";
                for (int j = 0; j < authorBooks.Count; j++)
                {
                    if (bookDTO.BookId == authorBooks[j].book_id)
                    {
                        bookDTO.Author = bookDTO.Author + authorBooks.ElementAt(j).Author.first_name + " " + authorBooks.ElementAt(j).Author.last_name;
                    }
                }

                bookDTO.BookActive = booksFromDB[i].active;
                
                books.Add(bookDTO);
            }




            return books;

        }
        #endregion

        #region Get Authors Name
        public List<string> getAuthorsName()
        {
            List<Model.Author> authors = biblioteqEntities.Authors.ToList();

            List<string> authorsName = new List<string>();

            for (int i = 0; i < authors.Count; i++)
            {

                authorsName.Add(authors[i].first_name + " " + authors[i].last_name);
            }
            return authorsName;

        }
        #endregion

        #region GET Publishers Name
        public List<string> getPublishersName()
        {
            List<Model.Publisher> publishersFromDB = biblioteqEntities.Publishers.ToList();
            List<string> publishersName = new List<string>();

            for (int i = 0; i < publishersFromDB.Count; i++)
            {
                publishersName.Add(publishersFromDB[i].name);
            }
            return publishersName;
        }
        #endregion

        #region GET BookTypes Name
        public List<string> getBookTypesName()
        {
            List<Model.BookType> bookTypesFromDB = biblioteqEntities.BookTypes.ToList();
            List<string> bookTypesName = new List<string>();
            for (int i = 0; i < bookTypesFromDB.Count; i++)
            {
                bookTypesName.Add(bookTypesFromDB[i].name);
            }

            return bookTypesName;
        }
        #endregion


        #region SAVE Book Service
        public void addBook(string title, string selectedPublisher, string selectedBookType, int stock, string selectedAuthor)
        {
            if (stock<=0)
            {
                throw new Exception("Stock must be a positive number");
            }

            Model.Book bookToSave = new Model.Book();
            bookToSave.title = title;
            bookToSave.stock = stock;

            Model.Publisher publisher = biblioteqEntities.Publishers.Where(p => p.name.Equals(selectedPublisher)).FirstOrDefault();
            Model.BookType bookType = biblioteqEntities.BookTypes.Where(p => p.name.Equals(selectedBookType)).FirstOrDefault();
            Model.Author author = biblioteqEntities.Authors.Where(p => selectedAuthor.Equals(p.first_name + " " + p.last_name)).FirstOrDefault();

            bookToSave.Publisher = publisher;
            bookToSave.BookType = bookType;
            bookToSave.active = true;
            
            biblioteqEntities.Books.Add(bookToSave);

            Model.AuthorBook authorBook = new Model.AuthorBook();

            authorBook.Author = author;
            authorBook.Book = bookToSave;

            biblioteqEntities.AuthorBooks.Add(authorBook);

            
            biblioteqEntities.SaveChanges();

        }
        #endregion
    }
}
