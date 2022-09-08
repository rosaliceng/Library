
using LibraryWebAPI.Helpers;
using LibraryWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryWebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Usuários
        Task<PageList<User>> GetAllUsersAsync(PageParams pageParams);
        User[] GetAllUsers();
        User GetUserByEmail(string email);
        User GetUserById(int userId);

        //Livros
        Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams);
        Book[] GetAllBooks();
        Book GetAllBooksByPublisherId(int publisherId);
        Book GetBookById(int BookId);

        //Editoras
        Task<PageList<Publisher>> GetAllPublishersAsync(PageParams pageParams);
        Publisher[] GetAllPublishers();
        Publisher GetPublisherByName(string name);
        Publisher GetPublisherById(int publisherId);

        //Alugueis
        Task<PageList<Rent>> GetAllRentsAsync(PageParams pageParams);
        Rent[] GetAllRents();
        Rent GetAllRentsByUserId(int userId);
        Rent GetAllRentsByBookId(int bookId); 
        Rent GetRentById(int rentId);
    }
}

﻿
