using boo.Models;
using System.Collections.Generic;

namespace boo.Repos
{
    public interface IAuthorRepo
    {
       
        List<Author> List();
        Author GetbyId(int id);
        void ModifyContext(Author author);
        void AddContext(Author author);
        void Remove(Author author);
        Author AuthorToDelete(int id);
    }
}
