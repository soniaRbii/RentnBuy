using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RentnBuy.Models
{
   public  class CarType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string Name { get; set; }
    }
}
