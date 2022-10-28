using LibraryWebAPI.Helpers;
using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return (_context.SaveChanges() > 0);
        }

        public User[] GetAllUsers()
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            return query.ToArray();

        }

        public async Task<PageList<User>> GetAllUsersAsync(PageParams pageParams)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking().OrderBy(u => u.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(user => user.Name.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.City))
            {
                query = query.Where(user => user.City.ToUpper().Contains(pageParams.City.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Address))
            {
                query = query.Where(user => user.Address.ToUpper().Contains(pageParams.Address.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Email))
            {
                query = query.Where(user => user.Email.ToUpper().Contains(pageParams.Email.ToUpper()));
            }

            //return await query.ToListAsync();
            return await PageList<User>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public User GetUserByEmail(string email)
        {
            IQueryable<User> query = _context.Users;

            query = query.AsNoTracking()
                .OrderBy(u => u.Email)
                .Where(user => user.Email == email);

            return query.FirstOrDefault();
        }
        public User GetUserById(int userId)
        {
            IQueryable<User> query = _context.Users;

            query = query
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

        public async Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams)
        {
            IQueryable<Book> query = _context.Books;

            query = query.Include(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(b => b.Id);


            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(book => book.Name.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.Author))
            {
                query = query.Where(book => book.Author.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (pageParams.Launch != null)
            {
                query = query.Where(book => book.Launch == pageParams.Launch);
            }

            if (pageParams.Quantity != null)
            {
                query = query.Where(book => book.Quantity == pageParams.Quantity);
            }

            if (pageParams.TotalRented != null)
            {
                query = query.Where(book => book.TotalRented == pageParams.TotalRented);
            }


            //return await query.ToListAsync();
            return await PageList<Book>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }


        public Book GetAllBooksByPublisherId(int publisherId)
        {
            IQueryable<Book> query = _context.Books;

            query = query.Include(b => b.Publisher);

            query = query.AsNoTracking()
                .OrderBy(b => b.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.FirstOrDefault();
        }

        public Book[] GetBooksByMaxRented()
        {
            IQueryable<Book> query = _context.Books;

            query = query.Include(b => b.Publisher);

            query = query.AsNoTracking().OrderByDescending(b => b.MaxRented);

            return query.ToArray();
        }

        public Book GetBookById(int bookId)
        {
            IQueryable<Book> query = _context.Books;

            query = query.Include(b => b.Publisher);

            query = query 
             .OrderBy(b => b.Id)
              .Where(publisher => publisher.Id == bookId);

            return query.FirstOrDefault();
        }

        public Publisher[] GetAllPublishers()
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }

        public async Task<PageList<Publisher>> GetAllPublishersAsync(PageParams pageParams)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking().OrderBy(p => p.Id);


            if (!string.IsNullOrEmpty(pageParams.Name))
            {
                query = query.Where(publisher => publisher.Name.ToUpper().Contains(pageParams.Name.ToUpper()));
            }

            if (!string.IsNullOrEmpty(pageParams.City))
            {
                query = query.Where(publisher => publisher.City.ToUpper().Contains(pageParams.Name.ToUpper()));
            }


            return await PageList<Publisher>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
        public Publisher GetPublisherByName(string name)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query.AsNoTracking()
                .OrderBy(p => p.Name)
                .Where(publisher => publisher.Name == name);

            return query.FirstOrDefault();
        }
        public Publisher GetPublisherById(int publisherId)
        {
            IQueryable<Publisher> query = _context.Publishers;

            query = query
                .OrderBy(p => p.Id)
                .Where(publisher => publisher.Id == publisherId);

            return query.FirstOrDefault();
        }

        public Rent[] GetAllRents()
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.User);
            query = query.Include(r => r.Book).ThenInclude(r => r.Publisher);

            query = query.AsNoTracking().OrderBy(r => r.Id);

            return query.ToArray();
        }

        public async Task<PageList<Rent>> GetAllRentsAsync(PageParams pageParams)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.User);
            query = query.Include(r => r.Book).ThenInclude(b => b.Publisher);

            query = query.AsNoTracking().OrderBy(r => r.Id);

            if (pageParams.Quantity != null)
            {
                query = query.Where(book => book.RentDate == pageParams.RentDate);
            }

            if (pageParams.TotalRented != null)
            {
                query = query.Where(book => book.ForecastDate == pageParams.ForecastDate);
            }

            if (pageParams.TotalRented != null)
            {
                query = query.Where(book => book.RentDate == pageParams.RentDate);
            }

            return await PageList<Rent>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }


        public Rent GetAllRentsByUserId(int userId)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.User);

            query = query.AsNoTracking()
                  .OrderBy(r => r.Id)
                  .Where(user => user.User.Id == userId);

            return query.FirstOrDefault();
        }

        public Rent GetAllRentsByBookId(int bookId)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.Book);

            query = query.AsNoTracking()
                  .OrderBy(r => r.BookId)
                  .Where(book => book.BookId == bookId);

            return query.FirstOrDefault();
        }

        public Rent GetRentById(int rentId)
        {
            IQueryable<Rent> query = _context.Rents;

            query = query.Include(r => r.User);
            query = query.Include(r => r.Book).ThenInclude(r => r.Publisher);

            query = query
                 .OrderBy(a => a.Id)
                 .Where(user => user.Id == rentId)
                 .Where(book => book.Id == rentId);

            return query.FirstOrDefault();
        }

       }

 }

   
