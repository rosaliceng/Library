namespace LibraryWebAPI.Models
{
    public class Rent
    {
        public Rent() { }
      
        public Rent(int id, int userId, int bookId, int rentDate, int forecastDate, int devolutionDate)
        {
            this.Id = id;
            this.UserId = userId;
            this.BookId = bookId;
            this.RentDate = rentDate;
            this.ForecastDate = forecastDate;
            this.DevolutionDate = devolutionDate;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public  Book Book { get; set; }
        public int RentDate { get; set;}
        public int ForecastDate { get; set; }
        public int DevolutionDate { get; set; }




    }
}
