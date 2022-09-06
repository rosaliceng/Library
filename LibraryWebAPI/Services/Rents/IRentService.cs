using LibraryWebAPI.Models;

namespace LibraryWebAPI.Services.Rents
{
    public interface IRentService
    {
        Rent RentCreate(Rent model);
        Rent RentUpdate(int rentalId, Rent model);
        Rent RentDelete(int rentalId);

    }
}
