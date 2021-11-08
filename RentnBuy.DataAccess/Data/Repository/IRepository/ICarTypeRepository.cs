using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using RentnBuy.Models;


namespace RentnBuy.DataAccess.Data.Repository.IRepository
{
    public interface ICarTypeRepository : IRepository<CarType>
    {
        IEnumerable<SelectListItem> GetCarsTypeListForDropDown();
        void Update(CarType CarType);
    }
}
