using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryWebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly LibraryContext _context;

        public Repository(LibraryContext context)
        {
            _context = context;
        }


        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }


        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }


        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

      
        public bool SaveChanges()
        {
           return (_context.SaveChanges()>0);
        }

        public User[] GetAllUsers()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return query.ToArray();

        }

        public User GetUserById(int userId)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                  .OrderBy(u => u.Id)
                  .Where(user => user.Id == userId);

            return query.FirstOrDefault();
        }

        public Book[] GetAllBooks()
        {
            IQueryable<Book> query = _context.Books;
           
                query = query.Include(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(b => b.Id);

            return query.ToArray();
        }

        public Book[] GetAllBooksByPublisherId(int publisherId, bool includePublisher = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includePublisher)
            {
                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking()
                .OrderBy(b => b.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.ToArray();
        }


        public Book GetBookById(int publisherId, bool includePublisher = false)
        {
            IQueryable<Book> query = _context.Books;

            if (includePublisher)
            {
                query = query.Include(b => b.Publisher);
            }

            query = query.AsNoTracking()
                .OrderBy(b => b.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.FirstOrDefault();
        }

        public Publisher[] GetAllPublishers()
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public Publisher GetPublisherById(int publsiherId)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(publisher => publisher.Id == publsiherId);

            return query.FirstOrDefault();
        }

        public Rent[] GetAllRents()
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.User);
            query = query.Include(r => r.Book).ThenInclude(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(r => r.Id);

            return query.ToArray();
        }

        public Rent[] GetAllRentsByUserId(int userId)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.User);

            query = query.AsNoTracking()
                  .OrderBy(r => r.Id)
                  .Where(user => user.Id == userId);

            return query.ToArray();
        }

        public Rent[] GetAllRentsByBookId(int bookId)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.AsNoTracking()
                  .OrderBy(r => r.Id)
                  .Where(book => book.Id == bookId);

            return query.ToArray();
        }

        public Rent GetRentById(int userId, int bookId)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(l => l.User);
            query = query.Include(l => l.Book);

            query = query.AsNoTracking()
                 .OrderBy(a => a.Id)
                 .Where(usuario => usuario.Id == userId)
                 .Where(livro => livro.Id == bookId);

            return query.FirstOrDefault();
        }

    }
}
