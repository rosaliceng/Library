using LibraryWebAPI.Models;

namespace LibraryWebAPI.Services.Rents
{
    public interface IRentService
    {
        Rent RentCreate(Rent model);
        Rent RentUpdate(Rent model);
        Rent RentDelete(int rentId);

    }
}
