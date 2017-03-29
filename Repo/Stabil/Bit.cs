using boo.Repos;
using boo.Models;

namespace boo.Stabil
{
    public class Bit : IBit
    {
        private readonly ApplicationDbContext _context;

        public IAuthorRepo Authors { get; }
        public IBookRepo Books { get; }


        public Bit(ApplicationDbContext context)
        {
           _context = context;
            Authors = new AuthorRepo(context);
            Books = new BookRepo(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}