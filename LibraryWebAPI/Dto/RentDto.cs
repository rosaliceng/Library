using System;

namespace LibraryWebAPI.Dto
{
    public class RentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public int BookId { get; set; }
        public BookDto Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ForecastDate { get; set; }
        public DateTime DevolutionDate { get; set; }
    }
}
