using LibraryWebAPI.Dto.Books;
using LibraryWebAPI.Dto.Users;
using System;

namespace LibraryWebAPI.Dto.Rents
{
    public class RentDevolutionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       
        public int BookId { get; set; }
    
        public DateTime RentDate { get; set; }
        public DateTime ForecastDate { get; set; }
        public DateTime DevolutionDate { get; set; }

    }
}
