using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ._Commands;
using GheoBiblioteQ._Service;

namespace GheoBiblioteQ.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private ViewModelBase selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged("SelectedViewModel"); }
        }

        public MainViewModel() 
        {
            selectedViewModel = new WelcomeViewModel();
            updateViewUsers = new CustomCommand(viewUsers);
            updateViewAuthors = new CustomCommand(viewAuthors);
            updateViewPublishers = new CustomCommand(viewPublishers);
            updateViewBookTypes = new CustomCommand(viewBookTypes);
            updateViewBooks = new CustomCommand(viewBooks);
        }


        #region Switch to User View
        private CustomCommand updateViewUsers;
        public CustomCommand UpdateViewUsers
        {
            get { return updateViewUsers; }
        }

        public void viewUsers() 
        {
            SelectedViewModel = new UserViewModel();
        }
        #endregion

        #region Switch to Author View
        private CustomCommand updateViewAuthors;
        public CustomCommand UpdateViewAuthors
        {
            get { return updateViewAuthors; }
            
        }

        public void viewAuthors() 
        {
            SelectedViewModel = new AuthorViewModel();
        }
        #endregion

        #region Switch to Publisher View
        private CustomCommand updateViewPublishers;
        public CustomCommand UpdateViewPublishers
        {
            get { return updateViewPublishers; }
        }

        public void viewPublishers() 
        {
            SelectedViewModel = new PublisherViewModel();
        }
        #endregion

        #region Switch to Book Type View
        private CustomCommand updateViewBookTypes;
        public CustomCommand UpdateViewBookTypes
        {
            get { return updateViewBookTypes; }
        }
        public void viewBookTypes() 
        {
            SelectedViewModel = new BookTypeViewModel();
        }
        #endregion


        #region Switch to Books View
        private CustomCommand updateViewBooks;

        public CustomCommand UpdateViewBooks
        {
            get { return updateViewBooks; }
        }

        public void viewBooks() 
        {
            SelectedViewModel = new BookViewModel();
        }

        #endregion


    }
}
