using GheoBiblioteQ._Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GheoBiblioteQ.ModelDTOs.Author
{
    public class AuthorDTO: ViewModelBase

    {
        #region Author ID
        private int authorId;
        public int AuthorId
        {
            get { return authorId; }
            set { authorId = value; OnPropertyChanged("AuthorId"); }
        }
        #endregion

        #region First Name
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }
        #endregion

        #region Last Name
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }
        #endregion

        #region BirthDay
        private DateTime birthdate;
        public DateTime BirthDate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        #endregion

        #region Active
        private bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        #endregion

    }
}
