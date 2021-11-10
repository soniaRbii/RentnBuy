using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;

namespace RentnBuy.DataAccess.Data.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Car car)
        {
            var carFromDb = _db.Car.FirstOrDefault(m => m.Id == car.Id);

            carFromDb.Name = car.Name;
            carFromDb.CategoryId = car.CategoryId;
            carFromDb.Description = car.Description;
            carFromDb.CarTypeId = car.CarTypeId;
            carFromDb.Price = car.Price;
            if (car.Image != null)
            {
                carFromDb.Image = car.Image;
            }
            _db.SaveChanges();

        }
    }
}