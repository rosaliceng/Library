namespace LibraryWebAPI.Models
{
    public class Rent
    {
        public Rent() { }
      
        public Rent(int id, string userId, string userName, string bookId, string bookName, string rentDate, string forecastDate, string devolutionDate)
        {
            Id = id;
            UserId = userId;
            UserName = userName;
            BookId = bookId;
            BookName = bookName;
            RentDate = rentDate;
            ForecastDate = forecastDate;
            DevolutionDate = devolutionDate;
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string BookId { get; set; }
        public string BookName { get; set; }
        public string RentDate { get; set;}
        public string ForecastDate { get; set; }
        public string DevolutionDate { get; set; }




    }
}
