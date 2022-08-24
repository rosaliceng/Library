using AutoMapper;
using LibraryWebAPI.Dto;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.Helpers
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Rent, RentDto>().ReverseMap();

        }
    }
}
