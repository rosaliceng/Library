using AutoMapper;
using LibraryWebAPI.Data;
using LibraryWebAPI.Models;
using System;

namespace LibraryWebAPI.Services.Rents
{
    public class RentService : IRentService
    {
        private readonly IRepository _repo;
       
        public RentService(IRepository repo)
        {
            _repo = repo;

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
                updateBook.MaxRented++;
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

            if (string.IsNullOrEmpty(model.StatusRents))
            {
                model.StatusRents = "Pendente";
            }
            else
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

        public Rent RentUpdate( Rent model)
        {
            
            if (model.DevolutionDate> model.ForecastDate.Date)
            {
                model.StatusRents = "Com atraso";
            }
            else if (model.DevolutionDate<= model.ForecastDate.Date)
            {
                model.StatusRents = "No prazo";
            }
            else
            {
                return null;
            }
            if (model.DevolutionDate < model.RentDate.Date)
            {
                return null;
            }
            else
            {
                var book = _repo.GetBookById(model.BookId);
                book.Quantity += 1;
                book.TotalRented -= 1;
                _repo.Update<Rent>(model);
                _repo.Update<Book>(book);
                _repo.SaveChanges();
                return model;

            }
        }

        public Rent RentDelete(int rentId)
        {
            var rent = _repo.GetRentById(rentId);
            if (rent == null)
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

