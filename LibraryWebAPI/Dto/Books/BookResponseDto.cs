using LibraryWebAPI.Dto.Publishers;
using System;

namespace LibraryWebAPI.Dto.Books
{
    public class BookResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public PublisherResponseDto Publisher { get; set; }
        public DateTime Launch { get; set; }
        public int Quantity { get; set; }
        public int TotalRented { get; set; }
    }
}
