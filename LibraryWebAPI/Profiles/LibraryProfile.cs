using AutoMapper;
using LibraryWebAPI.Dto.Books;
using LibraryWebAPI.Dto.Publishers;
using LibraryWebAPI.Dto.Rents;
using LibraryWebAPI.Dto.Users;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.NewFolder
{
    public class LibraryProfile : Profile
    {
        public LibraryProfile()
        {
            CreateMap<User, UserRequestDto>().ReverseMap(); 
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<Book, BookRequestDto>().ReverseMap();
            CreateMap<Book, BookResponseDto>().ReverseMap();
            CreateMap<Publisher, PublisherRequestDto>().ReverseMap();
            CreateMap<Publisher, PublisherResponseDto>().ReverseMap();
            CreateMap<Rent, RentRequestDto>().ReverseMap();
            CreateMap<Rent, RentResponseDto>().ReverseMap();
            CreateMap<Rent, RentDevolutionDto>().ReverseMap();

        }
    }
}
