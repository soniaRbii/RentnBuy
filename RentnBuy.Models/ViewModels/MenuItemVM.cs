using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentnBuy.Models.ViewModels
{
    public class CarVM
    {
        public Car Car { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> CarsTypeList { get; set; }
    }
}