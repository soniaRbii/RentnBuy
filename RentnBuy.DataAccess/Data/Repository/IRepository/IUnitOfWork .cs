using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.DataAccess.Data.Repository.IRepository;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
  public  interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICarTypeRepository CarType { get; }
        ICarRepository Car { get; }
        IShoppingCartRepository ShoppingCart { get; }
        void Save();
    }
}
