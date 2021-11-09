using System;
using System.Collections.Generic;
using System.Text;
using Taste.DataAccess.Data.Repository.IRepository;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
  public   interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICarTypeRepository CarType { get; }
        ICarRepository Car { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        void Save();
    }
}
