using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GheoBiblioteQ.Model;
using GheoBiblioteQ.ModelDTOs.Author;

namespace GheoBiblioteQ._Service.Author
{
    public class AuthorService
    {
        private biblioteqEntities biblioteqEntities;

        public AuthorService() 
        {
            biblioteqEntities = new biblioteqEntities();
        }

        #region GET Authors
        public List<AuthorDTO> getAuthors() 
        {
            List<Model.Author> authors = biblioteqEntities.Authors.ToList();

            List<AuthorDTO> authorDTOs = new List<AuthorDTO>();

            for (int i = 0; i < authors.Count; i++)
            {
                AuthorDTO authorDTO = new AuthorDTO();

                authorDTO.AuthorId = authors[i].author_id;
                authorDTO.FirstName = authors[i].first_name;
                authorDTO.LastName = authors[i].last_name;
                authorDTO.BirthDate = authors[i].birthdate.Date;
                authorDTO.Active = authors[i].active;

                authorDTOs.Add(authorDTO);
            }
            return authorDTOs;
        }
        #endregion

        #region ADD AUthor Service
        public void addAuthor(AuthorDTO authorDTO)
        {
            Model.Author author = new Model.Author();

            author.first_name = authorDTO.FirstName;
            author.last_name = authorDTO.LastName;
            author.birthdate = authorDTO.BirthDate;
            author.active = true;

            biblioteqEntities.Authors.Add(author);
            biblioteqEntities.SaveChanges();
            
        }
        #endregion

        #region UPDATE Author Service
        public bool update(AuthorDTO authorDTO)
        {
            Model.Author authorToUpdate = biblioteqEntities.Authors.Where(a => a.author_id == authorDTO.AuthorId).FirstOrDefault();

            if (authorToUpdate!=null)
            {
                authorToUpdate.first_name = authorDTO.FirstName;
                authorToUpdate.last_name = authorDTO.LastName;
                authorToUpdate.birthdate = authorDTO.BirthDate.Date;

                biblioteqEntities.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Author not found!");
            }
        }
        #endregion

        #region DELETE Author
        public bool delete(AuthorDTO authorDTO)
        {
            Model.Author authorToDelete = biblioteqEntities.Authors.Where(a => a.author_id == authorDTO.AuthorId).FirstOrDefault();

            if (authorToDelete != null)
            {
                biblioteqEntities.Authors.Remove(authorToDelete);
                biblioteqEntities.SaveChanges();
                return true;
            }
            else { return false; };
        }
        #endregion



    }
}
