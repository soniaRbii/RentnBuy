﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RentnBuy.Models.ViewModels
{
    public class OrderDetailsViewModel
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}