using LibraryWebAPI.Models;

namespace LibraryWebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //Usuários
        User[] GetAllUsers();
        User GetUserById(int userId);

        //Livros
        Book[] GetAllBooks();
        Book[] GetAllBooksByPublisherId(int publsiherId, bool includePublsiher = false);
        Book GetBookById(int publsiherId, bool includePublsiher = false);
        
        //Editoras
        Publisher[] GetAllPublishers();
        Publisher GetPublisherById(int publsiherId);

        //Alugueis
        Rent[] GetAllRents();
        Rent[] GetAllRentsByUserId(int userId);
        Rent[] GetAllRentsByBookId(int bookId); 
        Rent GetRentById(int userId,int bookId);
    }
}
