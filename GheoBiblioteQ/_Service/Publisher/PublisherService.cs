using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ.ModelDTOs.Publisher;
using GheoBiblioteQ.Model;

namespace GheoBiblioteQ._Service.Publisher
{
    public class PublisherService
    {

        private biblioteqEntities biblioteqEntities;

        public PublisherService()
        {
            biblioteqEntities = new biblioteqEntities();
        }

        #region Get ALL Publishers
        public List<PublisherDTO> getPublishers() 
        {
            List<Model.Publisher> publishersFromDB = biblioteqEntities.Publishers.ToList();
            List<PublisherDTO> publishersDTO = new List<PublisherDTO>();
            for (int i = 0; i < publishersFromDB.Count; i++)
            {
                PublisherDTO publisherDTO = new PublisherDTO();
                publisherDTO.PublisherId = publishersFromDB[i].publisher_id;
                publisherDTO.PublisherName = publishersFromDB[i].name;
                publisherDTO.Active = publishersFromDB[i].active;

                publishersDTO.Add(publisherDTO);
            }
            return publishersDTO;
        }
        #endregion

        #region SAVE Publisher Service
        public bool addPublisher(PublisherDTO currentPublisher)
        {
            Model.Publisher publisher = new Model.Publisher();
            publisher.name = currentPublisher.PublisherName;
            publisher.active = true;

            biblioteqEntities.Publishers.Add(publisher);
            biblioteqEntities.SaveChanges();
            return true;
        }
        #endregion

        #region UPDATE Publisher Service
        public bool updatePublisher(PublisherDTO currentPublisher)
        {

            Model.Publisher publisherToUpdate = biblioteqEntities
                                            .Publishers
                                            .Where(p=>p.publisher_id==currentPublisher
                                            .PublisherId)
                                            .FirstOrDefault();

            if (publisherToUpdate != null) 
            {
                publisherToUpdate.name = currentPublisher.PublisherName;
                publisherToUpdate.active = currentPublisher.Active;
                biblioteqEntities.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Publisher not found!");
            }
        }
        #endregion

        #region DELETE Publisher Service
        internal bool deletePublisher(PublisherDTO currentPublisher)
        {
            Model.Publisher publisherToDelete =
                biblioteqEntities.Publishers.Where(p => p.publisher_id == currentPublisher.PublisherId).FirstOrDefault();

            if (publisherToDelete != null) 
            {
                biblioteqEntities.Publishers.Remove(publisherToDelete);
                biblioteqEntities.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Publisher not found!");
            }
        }
        #endregion

        #region SEARCH Publisher Service
        internal List<PublisherDTO> searchPublisher(string searchedName)
        {
            List<Model.Publisher> publishersFromDB =
                biblioteqEntities.Publishers.Where(p => p.name.Contains(searchedName)).ToList();

            List<PublisherDTO> publisherDTOs = new List<PublisherDTO>();

            for (int i = 0; i < publishersFromDB.Count; i++)
            {
                PublisherDTO publisherDTO = new PublisherDTO();
                publisherDTO.PublisherId = publishersFromDB[i].publisher_id;
                publisherDTO.PublisherName = publishersFromDB[i].name;
                publisherDTO.Active = publishersFromDB[i].active;
                
                publisherDTOs.Add(publisherDTO);
            }
            return publisherDTOs;
        }
        #endregion

        #region SWITCH ACTIVE/INACTIVE Service
        internal void switchPublisher(PublisherDTO publisherDTO)
        {
            Model.Publisher publisherToUpdate = biblioteqEntities
                .Publishers
                .Where(p => p.publisher_id == publisherDTO.PublisherId).FirstOrDefault();

            try
            {
                if (publisherDTO.Active)
                {
                    publisherToUpdate.active = false;
                }
                else
                {
                    publisherToUpdate.active = true;
                }
                biblioteqEntities.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception("Operation Failed!");
            }
           
        }
        #endregion
    }
}
