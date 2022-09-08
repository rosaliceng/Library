using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Models;
using System;

namespace LibraryWebAPI.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public RentService(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Rent RentCreate(Rent model)
        {
            var checkUser = _repo.GetUserById(model.UserId);
            if (checkUser == null)
            {
                return null;
            }

            var updateBook = _repo.GetBookById(model.BookId);
            if (updateBook.Quantity < 1)
            {
                return null;
            }
            else
            {
                updateBook.Quantity--;
                updateBook.TotalRented++;
            }

            DateTime currentDate = DateTime.Now;
            if (model.RentDate.Date < currentDate.Date)
            {
                return null;
            }

            if (model.ForecastDate.Date < model.RentDate.Date)
            {
                return null;
            }

            _repo.Update<Book>(updateBook);
            if (_repo.SaveChanges())
            {
                _repo.Add<Rent>(model);
                if (_repo.SaveChanges())
                {
                    return model;
                }
                return null;
            }

            return null;
        }

        public Rent RentUpdate(int rentId, Rent model)
        {
            var rent = _repo.GetRentById(rentId);
            if (rent == null)
            {
                return null;
            }

            model.Id = rent.Id;
            model.UserId = rent.UserId;
            model.BookId = rent.BookId;
            model.RentDate = rent.RentDate;
            model.ForecastDate = rent.ForecastDate;

            if (model.Id != rentId)
            {
                return null;
            }

            var updateBook = _repo.GetBookById(model.BookId);
            if (updateBook.TotalRented < 1)
            {
                return null;
            }
            else
            {
                updateBook.TotalRented--;
                updateBook.Quantity++;
            }

            if (model.DevolutionDate.Date < model.RentDate.Date)
            {
                return null;
            }

            if (model.ReturnedBook != true)
            {
                return null;
            }


            _repo.Update<Book>(updateBook);
            if (_repo.SaveChanges())
            {
                _repo.Update<Rent>(model);
                if (_repo.SaveChanges())
                {
                    return model;
                }
                return null;
            }
            return null;
        }

        public Rent RentDelete(int rentId)
        {
            var rent = _repo.GetRentById(rentId);
            if (rent == null)
            {
                return null;
            }

            if (rent.ReturnedBook != true)
            {
                return null;
            }

            _repo.Delete(rent);
            if (_repo.SaveChanges())
            {
                return rent;
            }

            return null;
        }


    }
}

