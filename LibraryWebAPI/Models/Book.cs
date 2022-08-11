namespace LibraryWebAPI.Models
{
    public class Book
    {
        public Book(int id, string name, string author, string publisherId, string publisherName, string launch, string quantity, string totalRented)
        {
            Id = id;
            Name = name;
            Author = author;
            PublisherId = publisherId;
            PublisherName = publisherName;
            Launch = launch;
            Quantity = quantity;
            TotalRented = totalRented;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Launch { get; set;}
        public string Quantity { get; set; }
        public string TotalRented { get; set; }




    }
}
