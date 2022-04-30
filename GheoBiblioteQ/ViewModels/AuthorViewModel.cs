using GheoBiblioteQ._Commands;
using GheoBiblioteQ._Service;
using GheoBiblioteQ._Service.Author;
using GheoBiblioteQ.ModelDTOs.Author;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheoBiblioteQ.ViewModels
{
    public class AuthorViewModel: ViewModelBase
    {
        private AuthorService authorService;
        public AuthorViewModel()
        {
            authorService = new AuthorService();
            loadData();
            currentAuthor = new AuthorDTO();
            saveCommand = new CustomCommand(save);
            //searchType = "LastName";
            updateCommand = new CustomCommand(update);
            deleteCommand = new CustomCommand(delete);
            //searchCommand = new CustomCommand(search);
            //switchActiveCommand = new CustomCommand(switchStatus);
        }

        #region Current Author Property
        private AuthorDTO currentAuthor;
        public AuthorDTO CurrentAuthor
        {
            get { return currentAuthor; }
            set { currentAuthor = value; OnPropertyChanged("CurrentAuthor"); }
        }
        #endregion

        #region Selected Author Property
        private AuthorDTO selectedAuthor;
        public AuthorDTO SelectedAuthor
        {
            get { return selectedAuthor; }
            set
            {
                selectedAuthor = value;
                if (selectedAuthor != null)
                {
                    CurrentAuthor.AuthorId = selectedAuthor.AuthorId;
                    CurrentAuthor.FirstName = selectedAuthor.FirstName;
                    CurrentAuthor.LastName = selectedAuthor.LastName;
                    CurrentAuthor.BirthDate = selectedAuthor.BirthDate;
                    CurrentAuthor.Active = selectedAuthor.Active;
                }
                OnPropertyChanged("selectedAuthor");
            }
        }

        #endregion

        #region Search Type
        private string searchType;
        public string SearchType
        {
            get { return searchType; }
            set { searchType = value; OnPropertyChanged("SearchType"); }
        }
        #endregion

        //#region Searched User Property
        //private string searchedUser;
        //public string SearchedUser
        //{
        //    get
        //    {
        //        return searchedUser;


        //    }
        //    set
        //    {
        //        searchedUser = value;
        //        if (searchedUser == null)
        //        {
        //            loadData();
        //        }
        //        else
        //        {
        //            search();
        //        }
        //        OnPropertyChanged("SearchedUser");
        //    }
        //}
        //#endregion

        #region Message Property
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        #endregion

        #region DISPLAY Authors
        private ObservableCollection<AuthorDTO> authorDTOs;
        public ObservableCollection<AuthorDTO> AuthorDTOs
        {
            get { return authorDTOs; }
            set { authorDTOs = value; OnPropertyChanged("AuthorDTOs"); }
        }
        #endregion

        #region SAVE Author
        private CustomCommand saveCommand;
        public CustomCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void save()
        {
            authorService.addAuthor(currentAuthor);
            loadData();
        }
        #endregion

        #region UPDATE Author
        private CustomCommand updateCommand;
        public CustomCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void update()
        {
            try
            {
                string username = currentAuthor.FirstName +" "+ currentAuthor.LastName;
                bool isUpdated = authorService.update(currentAuthor);
                if (isUpdated)
                {
                    Message = "Author " + username + " updated succesfully";
                }
                else
                {
                    Message = "Update operation for author " + username + " failed!";
                }

            }
            catch (Exception e)
            {

                Message = e.Message;
            }
            loadData();
        }
        #endregion

        #region DELETE User
        private CustomCommand deleteCommand;
        public CustomCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void delete()
        {
            try
            {
                string username = currentAuthor.FirstName + " " + currentAuthor.LastName;
                bool isDeleted = authorService.delete(currentAuthor);
                loadData();

                if (isDeleted)
                {
                    Message = "Author " + username + " deleted succesfully";
                }
                else
                {
                    Message = "Delete operation failed";
                }

            }
            catch (Exception e)
            {

                Message = e.Message;
            }

        }
        #endregion

        //#region SEARCH User
        //private CustomCommand searchCommand;
        //public CustomCommand SearchCommand
        //{
        //    get { return searchCommand; }
        //}

        //public void search()
        //{

        //    UserDTOs = new ObservableCollection<UserDTO>(userService.searchUsers(searchedUser, searchType));

        //}
        //#endregion

        //#region SWITCH ACTIVE/INACTIVE
        //private CustomCommand switchActiveCommand;
        //public CustomCommand SwitchActiveCommand
        //{
        //    get { return switchActiveCommand; }
        //}

        //public void switchStatus()
        //{
        //    userService.switchUserStatus(currentUser);
        //    loadData();
        //}


        //#endregion

        private void loadData()
        {
            AuthorDTOs = new ObservableCollection<AuthorDTO>(authorService.getAuthors());
        }


    }
}
