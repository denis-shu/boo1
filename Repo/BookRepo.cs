using System.Collections.Generic;
using System.Linq;
using boo.Models;
using System.Data.Entity;

namespace boo.Repos
{
    public class BookRepo : IBookRepo
    {
        private readonly ApplicationDbContext _context;

        public BookRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        


        public Book Delete(int id)
        {
            return _context.Books.SingleOrDefault(bo => bo.Id == id);

        }


        public List<Genre> Genres()
        {
             return _context.Genre.ToList();
            
        }


        public Book GetbookId(int id)
        {
            return _context.Books.Where(b => b.Id == id)
               .Include(b => b.Genre).SingleOrDefault();
        }


        public List<Book> List()
        {
            return _context.Books.Include("Genre").ToList();

        }


        public void RemoveContext(Book book)
        {
            _context.Books.Remove(book);
        }


        public Genre GenreType(Book book)
        {
            return _context.Genre.SingleOrDefault(g => g.Name == book.Genre.Name);
            //_context.Genre.SingleOrDefault(g => g.Name == book.Genre.Name);


        }


        public void AddContext(Book book)
        {
            _context.Entry(book).State = EntityState.Added;

        }

        public void ModifyContext(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

    }
}