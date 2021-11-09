using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.Models;

namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        void Update(OrderDetails orderDetails);
    }
}