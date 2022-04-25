using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ.Model;
using GheoBiblioteQ.ModelDTOs.User;

namespace GheoBiblioteQ._Service.User
{
    public class UserService
    {

        private  biblioteqEntities biblioteQEntities;
        public UserService()
        {
            biblioteQEntities = new biblioteqEntities();
        }

        #region Get Users Service
        public List<UserDTO> getUsers()
        {

            List<UserDTO> usersList = new List<UserDTO>();

            List<Model.User> usersFromDB = biblioteQEntities.Users.ToList();

            for (int i = 0; i < usersFromDB.Count; i++)
            {
                UserDTO userDTO = new UserDTO();

                userDTO.UserId = usersFromDB[i].user_id;
                userDTO.FirstName = usersFromDB[i].firstname;
                userDTO.LastName = usersFromDB[i].lastname;
                userDTO.Email = usersFromDB[i].email;
                userDTO.Phone = usersFromDB[i].phone;
                userDTO.Active = usersFromDB[i].active;

                usersList.Add(userDTO);
            }


            return usersList;
        }
        #endregion

        #region ADD User Service
        public bool addUser(UserDTO userDTO)
        {
            Model.User user = transferFromDTO(userDTO);
            user.active = true;

            biblioteQEntities.Users.Add(user);
            biblioteQEntities.SaveChanges();

            return true;
        }
        #endregion

        #region UPDATE User Service
        public bool update(UserDTO userDTO)
        {
            
            Model.User userForUpdateOperation = biblioteQEntities.Users.Where(u => u.user_id == userDTO.UserId).FirstOrDefault();

            if (userForUpdateOperation != null)
            {
                userForUpdateOperation.firstname = userDTO.FirstName;
                userForUpdateOperation.lastname = userDTO.LastName;
                userForUpdateOperation.email = userDTO.Email;
                userForUpdateOperation.phone = userDTO.Phone;
                userForUpdateOperation.active = userDTO.Active;
                
                biblioteQEntities.SaveChanges();
                return true;
            }
            else 
            {
               throw new Exception("User not found!");
            }
        }
        #endregion

        #region DELETE User Service
        public bool delete(UserDTO userDTO) 
        {
            Model.User userToDelete = biblioteQEntities.Users.Where(u=> u.user_id == userDTO.UserId).FirstOrDefault();

            if (userToDelete != null)
            {
                biblioteQEntities.Users.Remove(userToDelete);
                biblioteQEntities.SaveChanges();
                return true;
            }
            else { return false; }
        }

        #endregion

        #region SEARCH Users Service
        public List<UserDTO> searchUsers(string searchedUser, string searchType)
        {
            List<UserDTO> usersList = new List<UserDTO>();

            List<Model.User> usersFromDB = new List<Model.User> { new Model.User() };

            if (searchType.Equals("Email"))
            {
                usersFromDB = biblioteQEntities.Users.Where(u => u.email.Contains(searchedUser)).ToList();
            }

            if (searchType.Equals("FirstName")) 
            {
                usersFromDB = biblioteQEntities.Users.Where(u => u.firstname.Contains(searchedUser)).ToList();
            }

            if (searchType.Equals("LastName"))
            {
                usersFromDB = biblioteQEntities.Users.Where(u => u.lastname.Contains(searchedUser)).ToList();
            }

            for (int i = 0; i < usersFromDB.Count; i++)
            {
                UserDTO userDTO = new UserDTO();

                userDTO.UserId = usersFromDB[i].user_id;
                userDTO.FirstName = usersFromDB[i].firstname;
                userDTO.LastName = usersFromDB[i].lastname;
                userDTO.Email = usersFromDB[i].email;
                userDTO.Phone = usersFromDB[i].phone;
                userDTO.Active = usersFromDB[i].active;

                usersList.Add(userDTO);
            }

            return usersList;
        }
        #endregion

        #region UserDTO to User
        private Model.User transferFromDTO(UserDTO userDTO) 
        {
            Model.User user = new Model.User();
            user.firstname = userDTO.FirstName;
            user.lastname = userDTO.LastName;
            user.email = userDTO.Email;
            user.phone = userDTO.Phone;
            user.active = userDTO.Active;

            return user;
        }
        #endregion

        #region SWITCH ACTIVE/INACTIVE Service
        internal void switchUserStatus(UserDTO userDTO)
        {
            Model.User userForUpdateOperation = biblioteQEntities.Users.Where(u => u.user_id == userDTO.UserId).FirstOrDefault();

            if (userForUpdateOperation.active)
            {
                userForUpdateOperation.active = false;
            }
            else
            {
                userForUpdateOperation.active = true;
            }

            biblioteQEntities.SaveChanges();
        }
        #endregion

    }
}
