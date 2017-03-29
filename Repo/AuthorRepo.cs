using boo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace boo.Repos
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddContext(Author author)
        {
            _context.Authors.Add(author);
        }


        public void ModifyContext(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            
        }


        public Author GetbyId(int id)
        {
             var book = _context.Books.Include(b => b.Genre).ToList();
            var author = _context.Authors.Include(a=>a.Books).SingleOrDefault(a=>a.Id==id);
                        
            return author;
        }


        public List<Author> List()
        {
            var a = _context.Authors.ToList();
            
            return a;
        }

        public Author AuthorToDelete(int id)
        {
            return _context.Authors.SingleOrDefault(au => au.Id == id);
        }

        public void Remove(Author author)
        {
            _context.Authors.Remove(author);
        }

       
    }
}