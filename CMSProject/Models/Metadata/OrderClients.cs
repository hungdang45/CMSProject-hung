﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSProject.Models
{
    public class OrderClients
    {
        public int OrderID { get; set; }

        public Nullable<byte> OrderName { get; set; }

        public Nullable<int> CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public Nullable<byte> Gender { get; set; }

        public string Phone { get; set; }

        public string ShipAddress { get; set; }

        public string OrderCreate { get; set; }

        public Nullable<System.DateTime> CreateDate { get; set; }

        public string Shipper { get; set; }

        public Nullable<System.DateTime> ShipDate { get; set; }

        public string Receiver { get; set; }

        public Nullable<System.DateTime> PayDate { get; set; }

        public Nullable<decimal> Total { get; set; }

        public string Note { get; set; }

        public Nullable<byte> Status { get; set; }
    }
}