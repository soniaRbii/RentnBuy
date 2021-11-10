using System;
using System.Collections.Generic;
using System.Text;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
  public   interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICarTypeRepository CarType { get; }
        ICarRepository Car { get; }
        IShoppingCartRepository ShoppingCart { get; }
        void Save();
    }
}
