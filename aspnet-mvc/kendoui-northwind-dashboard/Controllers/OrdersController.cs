﻿using KendoUI.Northwind.Dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Data;

namespace KendoUI.Northwind.Dashboard.Controllers
{
    public class OrdersController : Controller
    {

        public ActionResult Orders_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Orders_Create([DataSourceRequest]DataSourceRequest request, OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                using (var northwind = new NorthwindEntities())
                {
                    var entity = new Order
                    {
                        CustomerID = order.CustomerID,
                        EmployeeID = order.EmployeeID,
                        OrderDate = order.OrderDate,
                        ShipCountry = order.ShipCountry,
                        ShipVia = order.ShipVia,
                        ShippedDate = order.ShippedDate,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipPostalCode = order.ShipPostalCode
                    };
                    northwind.Orders.Add(entity);
                    northwind.SaveChanges();
                    order.OrderID = entity.OrderID;
                }
            }
            return Json(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Orders_Update([DataSourceRequest]DataSourceRequest request, OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                using (var northwind = new NorthwindEntities())
                {
                    var entity = new Order
                    {

                        CustomerID = order.CustomerID,
                        OrderID = order.OrderID,
                        EmployeeID = order.EmployeeID,
                        OrderDate = order.OrderDate,
                        ShipCountry = order.ShipCountry,
                        ShipVia = order.ShipVia,
                        ShippedDate = order.ShippedDate,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipPostalCode = order.ShipPostalCode
                    };
                    northwind.Orders.Attach(entity);
                    northwind.Entry(entity).State = EntityState.Modified;
                    northwind.SaveChanges();
                }
            }
            return Json(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Orders_Destroy([DataSourceRequest]DataSourceRequest request, OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                using (var northwind = new NorthwindEntities())
                {

                    var entity = new Order
                    {
                        CustomerID = order.CustomerID,
                        OrderID = order.OrderID,
                        EmployeeID = order.EmployeeID,
                        OrderDate = order.OrderDate,
                        ShipCountry = order.ShipCountry,
                        ShipVia = order.ShipVia,
                        ShippedDate = order.ShippedDate,
                        ShipName = order.ShipName,
                        ShipAddress = order.ShipAddress,
                        ShipCity = order.ShipCity,
                        ShipPostalCode = order.ShipPostalCode
                    };
                    northwind.Orders.Attach(entity);
                    northwind.Orders.Remove(entity);
                    northwind.SaveChanges();
                }
            }
            return Json(new[] { order }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Countries_Read()
        {

            var countries = GetOrders().GroupBy(o => o.ShipCountry).Select(group => new
            {
                Country = group.Key == null ? " Other" : group.Key
            }).OrderBy(c => c.Country).ToList();

            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        private static IQueryable<OrderViewModel> GetOrders()
        {
            var northwind = new NorthwindEntities();
            var orders = northwind.Orders.Select(order => new OrderViewModel
            {
                CustomerID = order.CustomerID,
                OrderID = order.OrderID,
                EmployeeID = order.EmployeeID,
                OrderDate = order.OrderDate,
                ShipCountry = order.ShipCountry,
                ShipVia = order.ShipVia,
                ShippedDate = order.ShippedDate,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipPostalCode = order.ShipPostalCode

            });

            return orders;
        }

    }
}
