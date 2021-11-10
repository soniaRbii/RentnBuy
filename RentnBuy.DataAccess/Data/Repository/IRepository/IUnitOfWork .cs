using System;
using System.Collections.Generic;
using System.Text;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
  public   interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }
        ICarTypeRepository CarType { get; }
        ICarRepository Car { get; }
        IApplicationUserRepository ApplicationUser { get; }
        void Save();
    }
}
