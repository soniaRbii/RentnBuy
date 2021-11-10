using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;
using RentnBuy.Models.ViewModels;
using RentnBuy.Utility;

namespace RentnBuy.Pages.Customer.Cart
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public OrderDetailsCart OrderDetailsCartVM { get; set; }

        public void OnGet()
        {
            OrderDetailsCartVM = new OrderDetailsCart()
            {
                OrderHeader = new RentnBuy.Models.OrderHeader(),
                listCart = new List<ShoppingCart>()
            };

            OrderDetailsCartVM.OrderHeader.OrderTotal = 0;

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                IEnumerable<ShoppingCart> cart = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == claim.Value);

                if (cart != null)
                {
                    OrderDetailsCartVM.listCart = cart.ToList();
                }

                foreach (var cartList in OrderDetailsCartVM.listCart)
                {
                    cartList.Car = _unitOfWork.Car.GetFirstOrDefault(m => m.Id == cartList.CarId);
                    OrderDetailsCartVM.OrderHeader.OrderTotal += (cartList.Car.Price * cartList.Count);
                }
            }
        }

        public IActionResult OnPostPlus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.Id == cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
            _unitOfWork.Save();
            return RedirectToPage("/Customer/Cart/Index");
        }

        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.Id == cartId);
            if (cart.Count == 1)
            {
                _unitOfWork.ShoppingCart.Remove(cart);
                _unitOfWork.Save();

                var cnt = _unitOfWork.ShoppingCart.
                                GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, cnt);
            }
            else
            {
                _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
                _unitOfWork.Save();

            }


            return RedirectToPage("/Customer/Cart/Index");
        }


        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.Id == cartId);
            _unitOfWork.ShoppingCart.Remove(cart);
            _unitOfWork.Save();

            var cnt = _unitOfWork.ShoppingCart.
                               GetAll(u => u.ApplicationUserId == cart.ApplicationUserId).ToList().Count;
            HttpContext.Session.SetInt32(SD.ShoppingCart, cnt);
            return RedirectToPage("/Customer/Cart/Index");
        }
    }
}