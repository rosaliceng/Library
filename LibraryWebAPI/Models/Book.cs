using System;

namespace LibraryWebAPI.Models
{
    public class Book
    {
        public Book() { }
        public Book(int id,
                    string name,
                    string author,
                    int publisherId, 
                    DateTime launch, 
                    int quantity,
                    int totalRented,
                    int maxRented)
        {
            this.Id = id;
            this.Name = name;
            this.Author = author;
            this.PublisherId = publisherId;
            this.Launch = launch;
            this.Quantity = quantity;
            this.TotalRented = totalRented;
            this.MaxRented = maxRented;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public DateTime Launch { get; set;}
        public int Quantity { get; set; }
        public int TotalRented { get; set; }
        public int MaxRented { get; internal set; }
    }
}
