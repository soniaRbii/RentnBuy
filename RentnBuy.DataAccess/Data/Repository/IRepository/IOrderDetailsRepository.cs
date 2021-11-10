using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        void Update(OrderDetails orderDetails);
    }
}