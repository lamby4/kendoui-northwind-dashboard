﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KendoUI.Northwind.Dashboard.Models
{ 
    public class OrderDetailViewModel
    {
        public string OrderDetailID
        {
            get
            {
                return this.OrderID + "_" + this.ProductID;
            }
        }
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        [Required]
        [UIHint("Currency")]
        public decimal UnitPrice { get; set; }

        [Required]
        [UIHint("Integer")]
        public int Quantity { get; set; }

        [Required]
        [UIHint("Float")]
        public float Discount { get; set; }
    }
}
