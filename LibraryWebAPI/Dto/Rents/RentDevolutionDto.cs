using System;

namespace LibraryWebAPI.Dto.Rents
{
    public class RentDevolutionDto
    {
        public DateTime ReturnDate { get; set; }
        public bool ReturnedBook { get; set; }
    }
}
