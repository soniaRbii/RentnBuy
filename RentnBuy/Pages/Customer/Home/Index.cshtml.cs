using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;

namespace RentnBuy.Pages.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Car> CarsList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }


        public void OnGet()
        {
            CarsList = _unitOfWork.Car.GetAll(null, null, "Category,CarType");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);

        }
       
    }
}
