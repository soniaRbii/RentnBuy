using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.DataAccess.Data.Repository.IRepository;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
  public   interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICarTypeRepository CarType { get; }
        ICarRepository Car { get; }
        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IApplicationUserRepository ApplicationUser { get; }
    
    
        void Save();
    }
}
