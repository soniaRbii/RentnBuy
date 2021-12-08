using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentnBuy.DataAccess.Data.Repository;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;
using RentnBuy.Utility;

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

            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                int shoppingCartCount = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, shoppingCartCount);
            }

                    CarsList = _unitOfWork.Car.GetAll(null, null, "Category,CarType");
            CategoryList = _unitOfWork.Category.GetAll(null, q => q.OrderBy(c => c.DisplayOrder), null);
        }
    }
}