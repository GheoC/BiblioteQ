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

        #region

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
                    bookDTO.Author = bookDTO.Author + authorBooks.ElementAt(j).Author.first_name +" "+ authorBooks.ElementAt(j).Author.last_name + "; ";
                }

                bookDTO.BookActive = booksFromDB[i].active;
                
                books.Add(bookDTO);
            }




            return books;

        }
        

        #endregion




    }
}
