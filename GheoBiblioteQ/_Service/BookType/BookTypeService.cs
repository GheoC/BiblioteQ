using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ.ModelDTOs.BookType;
using GheoBiblioteQ.Model;

namespace GheoBiblioteQ._Service.BookType
{
    public class BookTypeService
    {
        private biblioteqEntities biblioteqEntities;
        public BookTypeService() 
        {
            biblioteqEntities = new biblioteqEntities();
        }

        #region Get All Book Types
        public List<BookTypeDTO> getAll()
        {
            List<Model.BookType> bookTypesFromDB = biblioteqEntities.BookTypes.ToList();
            List<BookTypeDTO> bookTypeDTOs = new List<BookTypeDTO>();

            for (int i = 0; i < bookTypesFromDB.Count; i++)
            {
                BookTypeDTO bookTypeDTO = new BookTypeDTO();
                bookTypeDTO.BookTypeId = bookTypesFromDB[i].booktype_id;
                bookTypeDTO.BookTypeName = bookTypesFromDB[i].name;
                bookTypeDTO.BookTypeActive = bookTypesFromDB[i].active;

                bookTypeDTOs.Add(bookTypeDTO);
            }
            return bookTypeDTOs;
        }
        #endregion

        #region Save Book Type
        internal void saveBookType(BookTypeDTO currentBookType)
        {
            Model.BookType bookType = new Model.BookType();

            bookType.name = currentBookType.BookTypeName;
            bookType.active = true;

            biblioteqEntities.BookTypes.Add(bookType);
            biblioteqEntities.SaveChanges();
        }
        #endregion

        #region Delete Book Type
        public void deleteBookType(BookTypeDTO currentBookType)
        {
            Model.BookType bookTypeToDelete = biblioteqEntities.BookTypes.Where(b => b.booktype_id == currentBookType.BookTypeId).FirstOrDefault();

            biblioteqEntities.BookTypes.Remove(bookTypeToDelete);
            biblioteqEntities.SaveChanges();
        }

        public void updateBookType(BookTypeDTO currentBookType)
        {
            Model.BookType bookTypeToUpdate = biblioteqEntities.BookTypes.Where(b=> b.booktype_id==currentBookType.BookTypeId).FirstOrDefault();

            bookTypeToUpdate.name = currentBookType.BookTypeName;
            bookTypeToUpdate.active = currentBookType.BookTypeActive;
            biblioteqEntities.SaveChanges();
        }
        #endregion

        #region Switch Active/Inactive
        public void switchBookType(BookTypeDTO currentBookType)
        {
            Model.BookType bookTypeFromDB = biblioteqEntities.BookTypes.Where(b => b.booktype_id == currentBookType.BookTypeId).FirstOrDefault();

            if (bookTypeFromDB.active)
            {
                bookTypeFromDB.active = false;
            }
            else 
            {
                bookTypeFromDB.active=true;
            }
            biblioteqEntities.SaveChanges();
        }
        #endregion



    }
}
