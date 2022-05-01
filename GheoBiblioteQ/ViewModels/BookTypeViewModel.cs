using GheoBiblioteQ._Commands;
using GheoBiblioteQ._Service;
using GheoBiblioteQ._Service.BookType;
using GheoBiblioteQ.ModelDTOs.BookType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheoBiblioteQ.ViewModels
{
    public class BookTypeViewModel : ViewModelBase
    {

        private BookTypeService bookTypeService;

        public BookTypeViewModel()
        {
            bookTypeService = new BookTypeService();
            loadData();
            currentBookType = new BookTypeDTO();
            saveCommand = new CustomCommand(save);
            deleteCommand = new CustomCommand(delete);
            updateCommand = new CustomCommand(update);
            switchActiveCommand = new CustomCommand(switchActive);
        }

        #region Current Book Type
        private BookTypeDTO currentBookType;
        public BookTypeDTO CurrentBookType
        {
            get { return currentBookType; }
            set { currentBookType = value; OnPropertyChanged("CurrentBookType"); }
        }
        #endregion

        #region Selected Book Type
        private BookTypeDTO selectedBookType;
        public BookTypeDTO SelectedBookType
        {
            get { return selectedBookType; }
            set { selectedBookType = value;
                if (selectedBookType != null)
                {
                    CurrentBookType.BookTypeId = selectedBookType.BookTypeId;
                    CurrentBookType.BookTypeName = selectedBookType.BookTypeName;
                    CurrentBookType.BookTypeActive = selectedBookType.BookTypeActive;
                }
                OnPropertyChanged("SelectedBookType"); }
        }
        #endregion

        #region Display Book Types
        private ObservableCollection<BookTypeDTO> bookTypeDTOs;
        public ObservableCollection<BookTypeDTO> BookTypeDTOs
        {
            get { return bookTypeDTOs; }
            set { bookTypeDTOs = value; OnPropertyChanged("BookTypeDTOs"); }
        }
        public void loadData()
        {
            BookTypeDTOs = new ObservableCollection<BookTypeDTO>(bookTypeService.getAll());
        }
        #endregion

        #region Save Book Type
        private CustomCommand saveCommand;

        public CustomCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void save()
        {
            bookTypeService.saveBookType(currentBookType);
            loadData();
        }
        #endregion

        #region Delete Book Type
        private CustomCommand deleteCommand;
        public CustomCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void delete()
        {
            bookTypeService.deleteBookType(currentBookType);
            loadData();
        }


        #endregion

        #region Update Book Type

        private CustomCommand updateCommand;

        public CustomCommand UpdateCommand
        {
            get { return updateCommand; }
        }
        public void update()
        {
            bookTypeService.updateBookType(currentBookType);
            loadData();
        }

        #endregion

        #region Switch Active/Inactive
        private CustomCommand switchActiveCommand;

        public CustomCommand SwitchActiveCommand
        {
            get { return switchActiveCommand; }
        }

        public void switchActive()
        {
            bookTypeService.switchBookType(currentBookType);
            loadData();

        }


        #endregion
    }

}
