using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.Models;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
  
        public interface ICarRepository : IRepository<Car>
        {
            void Update(Car car);
        }
    
}
