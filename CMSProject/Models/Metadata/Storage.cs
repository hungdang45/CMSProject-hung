using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSProject.Models
{
    public class Storage
    {
        public int GoodsReceiptDetailID { get; set; }
        public int GoodsReceiptID { get; set; }
        public string GoodsReceipt { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}