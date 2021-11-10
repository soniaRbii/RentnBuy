using RentnBuy.DataAccess;
using RentnBuy.DataAccess.Data.Repository;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.DataAccess.Data.Repository;
using RentnBuy.Models;

namespace RentnBuy.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CarType = new CarTypeRepository(_db);
            Car = new CarRepository(_db);

            ShoppingCart = new ShoppingCartRepository(_db);

            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);

        }

        public ICategoryRepository Category { get; private set; }
        public ICarTypeRepository CarType { get; private set; }
        public ICarRepository Car { get; private set; }
<<<<<<< HEAD
        public IShoppingCartRepository ShoppingCart { get; private set; }

=======
        public IOrderDetailsRepository OrderDetails { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
>>>>>>> ca14c01ad9500206d0a5dd343542385d40a993cb

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