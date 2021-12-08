using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RentnBuy.DataAccess.Data.Repository.IRepository;
using RentnBuy.Models;
using RentnBuy.Models.ViewModels;
using RentnBuy.Utility;

namespace RentnBuy.Pages.Admin.Cars
{
    [Authorize(Roles = SD.ManagerRole)]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public CarVM MenuItemObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            MenuItemObj = new CarVM
            {
                CategoryList = _unitOfWork.Category.GetCategoryListForDropDown(),
                CarsTypeList = _unitOfWork.CarType.GetCarsTypeListForDropDown(),
                Car = new Models.Car()
            };
            if (id != null)
            {
                MenuItemObj.Car = _unitOfWork.Car.GetFirstOrDefault(u => u.Id == id);
                if (MenuItemObj.Car == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }


        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (MenuItemObj.Car.Id == 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\cars");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItemObj.Car.Image = @"\images\cars\" + fileName + extension;

                _unitOfWork.Car.Add(MenuItemObj.Car);
            }
            else
            {
                //Edit Menu Item
                var objFromDb = _unitOfWork.Car.Get(MenuItemObj.Car.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\cars");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }


                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    MenuItemObj.Car.Image = @"\images\cars\" + fileName + extension;
                }
                else
                {
                    MenuItemObj.Car.Image = objFromDb.Image;
                }


                _unitOfWork.Car.Update(MenuItemObj.Car);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}