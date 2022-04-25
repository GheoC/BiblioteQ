using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ._Service;

namespace GheoBiblioteQ.ModelDTOs.Publisher
{
    public class PublisherDTO:ViewModelBase
    {

        #region Publisher Id
        private int publisherId;
        public int PublisherId
        {
            get { return publisherId; }
            set { publisherId = value; OnPropertyChanged("PublisherId"); }
        }
        #endregion

        #region Publisher Name
        private string publisherName;
        public string PublisherName
        {
            get { return publisherName; }
            set { publisherName = value; OnPropertyChanged("PublisherName"); }
        }
        #endregion

        #region Active Publisher
        private bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }
        #endregion


    }
}
