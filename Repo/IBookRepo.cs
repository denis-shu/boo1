using boo.Models;
using System.Collections.Generic;

namespace boo.Repos
{
    public  interface IBookRepo
    {
        List<Genre> Genres();
         List<Book> List();
        Book GetbookId(int id);
        void ModifyContext(Book book);
        Book Delete(int id);
        void AddContext(Book book);
        void RemoveContext(Book book);
        Genre GenreType(Book book);

        
    }
}
