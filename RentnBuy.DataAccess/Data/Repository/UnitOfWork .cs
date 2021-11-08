using RentnBuy.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentnBuy.DataAccess.Data.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CarType = new CarTypeRepository(_db);
            Car = new CarRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public ICarTypeRepository CarType { get; private set; }
        public ICarRepository Car { get; private set; }
    
     
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

