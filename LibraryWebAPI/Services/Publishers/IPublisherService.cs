using LibraryWebAPI.Models;

namespace LibraryWebAPI.Services.Publishers
{
    public interface IPublisherService
    {
        Publisher PublisherCreate(Publisher model);
        Publisher PublisherUpdate(int publisherId, Publisher model);
        Publisher PublisherDelete(int publisherId);
    }
}
