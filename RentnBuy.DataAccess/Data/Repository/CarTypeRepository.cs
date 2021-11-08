using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;
using RentnBuy.DataAccess;
using RentnBuy.DataAccess.Data.Repository;

namespace RentnBuy.DataAccess.Data.Repository
{
    public class CarTypeRepository : Repository<CarType>, ICarTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public CarTypeRepository(ApplicationDbContext db)
            : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCarsTypeListForDropDown()
        {
            return _db.CarType.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }


        public void Update(CarType objectToBeUpdated)
        {
            var categoryFromDb = _db.CarType.FirstOrDefault(s => s.Id == objectToBeUpdated.Id);
            categoryFromDb.Name = objectToBeUpdated.Name;
            _db.SaveChanges();
        }

    }
}

