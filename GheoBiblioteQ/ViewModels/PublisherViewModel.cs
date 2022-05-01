using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ._Service;
using GheoBiblioteQ._Service.Publisher;
using GheoBiblioteQ.ModelDTOs.Publisher;
using System.Collections.ObjectModel;
using GheoBiblioteQ._Commands;

namespace GheoBiblioteQ.ViewModels
{
    public class PublisherViewModel : ViewModelBase
    {
        private PublisherService publisherService;

        public PublisherViewModel() 
        {
            publisherService = new PublisherService();
            loadData();
            currentPublisher = new PublisherDTO();
            saveCommand= new CustomCommand(save);
            updateCommand= new CustomCommand(update);
            deleteCommand = new CustomCommand(delete);
            searchCommand = new CustomCommand(search);
            switchCommand = new CustomCommand(switchPublisher);

        }

        #region Current Publisher
        private PublisherDTO currentPublisher;
        public PublisherDTO CurrentPublisher
        {
            get { return currentPublisher; }
            set { currentPublisher = value; OnPropertyChanged("CurrentPublisher"); }
        }
        #endregion

        #region Message to User
        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }
        #endregion

        #region Selected Publisher
        private PublisherDTO selectedPublisher;
        public PublisherDTO SelectedPublisher
        {
            get { return selectedPublisher; }
            set { selectedPublisher = value;
                if (selectedPublisher != null)
                {
                    CurrentPublisher.PublisherId = selectedPublisher.PublisherId;
                    CurrentPublisher.PublisherName = selectedPublisher.PublisherName;
                    CurrentPublisher.Active = selectedPublisher.Active;
                }
                OnPropertyChanged("SelectedPublisher"); }
        }
        #endregion

        #region Display Publishers

        private ObservableCollection<PublisherDTO> publisherDTOs;

        public ObservableCollection<PublisherDTO> PublisherDTOs
        {
            get { return publisherDTOs; }
            set { publisherDTOs = value; OnPropertyChanged("PublisherDTOs"); }
        }

        private void loadData() 
        {
            PublisherDTOs = new ObservableCollection<PublisherDTO> (publisherService.getPublishers());
        }
        #endregion

        #region SAVE Publisher
        private CustomCommand saveCommand;
        public CustomCommand SaveCommand
        {
            get { return saveCommand; }
        }
        public void save()
        {
            try
            {
                string publisherName = currentPublisher.PublisherName;
                bool isSaved = publisherService.addPublisher(currentPublisher);
                if (isSaved)
                {
                    Message = "Publisher " + publisherName + " is saved successfully";
                }
                else 
                {
                    Message = "Saving publisher failed!";
                }
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
            loadData();
        }
        #endregion

        #region UPDATE Publisher
        private CustomCommand updateCommand;
        public CustomCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void update() 
        {
            try
            {
                string publisherName = currentPublisher.PublisherName;
                bool isUpdated = publisherService.updatePublisher(currentPublisher);
                if (isUpdated)
                {
                    Message = "Publisher " + publisherName + " updated succesfully";
                }

            }
            catch (Exception e)
            {

                Message = e.Message;
            }
            loadData();
        }


        #endregion

        #region DELETE Publisher
        private CustomCommand deleteCommand;
        public CustomCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void delete() 
        {

            try
            {
                string username = currentPublisher.PublisherName;
                bool isDeleted = publisherService.deletePublisher(currentPublisher);
                loadData();

                if (isDeleted)
                {
                    Message = "Publisher " + username + " deleted succesfully";
                }
            }
            catch (Exception e)
            {

                Message = e.Message;
            }

        }
        #endregion

        #region SEARCH Publisher
        private CustomCommand searchCommand;
        public CustomCommand SearchCommand
        {
            get { return searchCommand; }
        }

        private string searchedPublisher;
        public string SearchedPublisher
        {
            get { return searchedPublisher; }
            set { searchedPublisher = value;
                if (searchedPublisher == null)
                {
                    loadData();
                }
                else
                {
                    search();
                }
                OnPropertyChanged("SearchedPublisher"); }
        }

        public void search() 
        {
            PublisherDTOs = new ObservableCollection<PublisherDTO>(publisherService.searchPublisher(searchedPublisher));
        }


        #endregion

        #region SWITCH ACTIVE / INACTIVE
        private CustomCommand switchCommand;
        public CustomCommand SwitchCommand

        {
            get { return switchCommand; }
        }
        public void switchPublisher() 
        {
            publisherService.switchPublisher(currentPublisher);
            loadData();
        }
        #endregion
    }
}
