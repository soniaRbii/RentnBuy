using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentnBuy.DataAccess;
using RentnBuy.DataAccess.Data.Repository;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;

namespace Taste.DataAccess.Data.Repository
{
    public class MenuItemRepository : Repository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Car car)
        {
            var menuItemFromDb = _db.Car.FirstOrDefault(m => m.Id == car.Id);

            menuItemFromDb.Name = car.Name;
            menuItemFromDb.CategoryId = car.CategoryId;
            menuItemFromDb.Description = car.Description;
            menuItemFromDb.CarTypeId = car.CarTypeId;
            menuItemFromDb.Price = car.Price;
            if (car.Image != null)
            {
                menuItemFromDb.Image = car.Image;
            }
            _db.SaveChanges();

        }
    }
}