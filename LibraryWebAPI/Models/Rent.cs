using System;

namespace LibraryWebAPI.Models
{
    public class Rent
    {
        public Rent() { }

        public Rent(int id, int userId, int bookId, DateTime rentDate, DateTime forecastDate, DateTime devolutionDate, string statusRents)
        {
            Id = id;
            UserId = userId;
            BookId = bookId;
            RentDate = rentDate;
            ForecastDate = forecastDate;
            DevolutionDate = devolutionDate;
            StatusRents = statusRents;
          
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ForecastDate { get; set; }
        public DateTime? DevolutionDate { get; set; }
        public string StatusRents { get; set; }
    }
}
