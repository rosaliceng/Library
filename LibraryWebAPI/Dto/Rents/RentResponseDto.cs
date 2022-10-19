using LibraryWebAPI.Dto.Books;
using LibraryWebAPI.Dto.Users;
using System;

namespace LibraryWebAPI.Dto.Rents
{
   
        public class RentResponseDto
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public UserResponseDto User { get; set; }
            public int BookId { get; set; }
            public BookResponseDto Book { get; set; }
            public DateTime RentDate { get; set; }
            public DateTime ForecastDate { get; set; }
            public DateTime? DevolutionDate { get; set; }

        }

    }



