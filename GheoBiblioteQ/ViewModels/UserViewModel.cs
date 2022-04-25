using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GheoBiblioteQ._Service.User;
using GheoBiblioteQ.ModelDTOs.User;
using GheoBiblioteQ._Commands;
using System.Collections.ObjectModel;
using GheoBiblioteQ._Service;

namespace GheoBiblioteQ.ViewModels
{
    public class UserViewModel:ViewModelBase
    {

        private UserService userService;

        public UserViewModel()
        {
            userService = new UserService();
            loadData();
            currentUser = new UserDTO();
            saveCommand = new CustomCommand(save);
            searchType = "Email";
            updateCommand = new CustomCommand(update);
            deleteCommand = new CustomCommand(delete);
            searchCommand = new CustomCommand(search);
            switchActiveCommand = new CustomCommand(switchStatus);
        }

        #region Current User Property
        private UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; OnPropertyChanged("CurrentUser"); }
        }
        #endregion

        #region Selected User Property
        private UserDTO selectedUser;
        public UserDTO SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value;
                if (selectedUser != null)
                {
                    CurrentUser.UserId = selectedUser.UserId;
                    CurrentUser.FirstName = selectedUser.FirstName;
                    CurrentUser.LastName = selectedUser.LastName;
                    CurrentUser.Email = selectedUser.Email;
                    CurrentUser.Phone = selectedUser.Phone;
                    CurrentUser.Active = selectedUser.Active;
                }
                OnPropertyChanged("SelectedUser"); }
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

        #region Searched User Property
        private string searchedUser;
        public string  SearchedUser
        {
            get 
            { 
                return searchedUser;
               
                
            }
            set {
                searchedUser = value; 
                if (searchedUser == null)
                {
                    loadData();
                }
                else
                {
                    search();
                }
                OnPropertyChanged("SearchedUser");
            }
        }
        #endregion

        #region Message Property
        private string message;
        public string  Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        #endregion

        #region DISPLAY Users
        private ObservableCollection<UserDTO> userDTOs;
        public ObservableCollection<UserDTO> UserDTOs
        {
            get { return userDTOs; }
            set { userDTOs = value; OnPropertyChanged("UserDTOs"); }
        }
        #endregion

        #region SAVE User
        private CustomCommand saveCommand;
        public CustomCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void save()
        {
            userService.addUser(currentUser);
            loadData();
        }
        #endregion

        #region UPDATE User
        private CustomCommand updateCommand;
        public CustomCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void update() 
        {
            try
            {
                string username = currentUser.Email;
                bool isUpdated = userService.update(currentUser);
                if (isUpdated)
                {
                    Message = "User" + username + " updated succesfully";
                }
                else
                {
                    Message = "Update operation for user "+ username+" failed!";
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
                string username = currentUser.Email;
                bool isDeleted = userService.delete(currentUser);
                loadData();

                if (isDeleted)
                {
                    Message = "User " + username + " deleted succesfully";
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

        #region SEARCH User
        private CustomCommand searchCommand;
        public CustomCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void search() 
        {

            UserDTOs = new ObservableCollection<UserDTO>(userService.searchUsers(searchedUser, searchType));
            
        }
        #endregion

        #region SWITCH ACTIVE/INACTIVE
        private CustomCommand switchActiveCommand;
        public CustomCommand SwitchActiveCommand
        {
            get { return switchActiveCommand; }
        }

        public void switchStatus() 
        {
            userService.switchUserStatus(currentUser);
            loadData();
        }


        #endregion

        private void loadData()
        {
            UserDTOs = new ObservableCollection<UserDTO>(userService.getUsers());
        }

    }
}
