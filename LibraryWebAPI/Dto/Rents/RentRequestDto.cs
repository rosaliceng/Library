using System;

namespace LibraryWebAPI.Dto.Rents
{
    public class RentRequestDto
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ForecastDate { get; set; }
    }
}
