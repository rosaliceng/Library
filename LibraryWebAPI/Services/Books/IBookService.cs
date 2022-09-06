using LibraryWebAPI.Models;

namespace LibraryWebAPI.Services.Books
{
    public interface IBookService
    {
        Book BookCreate(Book model);
        Book BookUpdate(int bookId, Book model);
        Book BookDelete(int bookId);
    }
}
