using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using GheoBiblioteQ._Service;

namespace GheoBiblioteQ.ModelDTOs.User
{
    public class UserDTO : ViewModelBase
    {
        #region UserID
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; OnPropertyChanged("UserId"); }
        }
        #endregion

        #region FirstName
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }
        #endregion

        #region LastName
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        #endregion

        #region Email
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }
        #endregion

        #region Phone
        private string phone;
        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }
        #endregion

        #region Active
        private bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; OnPropertyChanged("Active"); }
        }
        #endregion

        public override string ToString()
        {
            return firstName + " " + lastName;
        }

    }
}
