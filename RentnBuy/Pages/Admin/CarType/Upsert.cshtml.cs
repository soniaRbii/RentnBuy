using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;
using RentnBuy.Utility;

namespace RentnBuy.Pages.Admin.CarType
{
   
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.CarType CarsTypeObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            CarsTypeObj = new Models.CarType();
            if (id != null)
            {
                CarsTypeObj = _unitOfWork.CarType.GetFirstOrDefault(u => u.Id == id);
                if (CarsTypeObj == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (CarsTypeObj.Id == 0)
            {
                _unitOfWork.CarType.Add(CarsTypeObj);
            }
            else
            {
                _unitOfWork.CarType.Update(CarsTypeObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}