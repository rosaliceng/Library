namespace LibraryWebAPI.Models
{
    public class Book
    {
        public Book(int id, string name, string author, int publisherId, int launch, int quantity, int totalRented)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.PublisherId = publisherId;
            this.Launch = launch;
            this.Quantity = quantity;
            this.TotalRented = totalRented;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int Launch { get; set;}
        public int Quantity { get; set; }
        public int TotalRented { get; set; }




    }
}
