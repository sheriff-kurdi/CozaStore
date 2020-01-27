using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TShirtCompany.Models;
using TShirtCompany.Repos;

namespace TShirtCompany.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductRepo productRepo;
        private readonly IOrderRepo orderRepo;

        public OrdersController( IProductRepo productRepo, IOrderRepo orderRepo)
        {
            this.productRepo = productRepo;
            this.orderRepo = orderRepo;
        }
        public IActionResult Index()
        {
            return View();
        }


    
        [HttpGet]
        public IActionResult RquestOrder(int id)
        {
            //Product product =  db.Products.Find(id);
            Product product = productRepo.GetProductByID(id);
            //id of the product to show price and image
            OrderRequestVM model = new OrderRequestVM()
            {
                ItemNumbers = 0,
                product = product
            };
   
            return View(model);
        }


        [HttpPost]
        public IActionResult RquestOrder(OrderRequestVM orderRequestVM)
        {
            if(ModelState.IsValid)
            {

               Order order = orderRepo.RequestOrder(orderRequestVM);

                return RedirectToAction("ConfirmRequest", "orders", new { id = order.Id });
            }
            return RedirectToAction("RquestOrder" , "orders");


        }

        //confirm request take order id and show order
        [HttpGet]
        public IActionResult ConfirmRequest(int id)
        {
            Order requestedOrder = orderRepo.GetOrdertByID(id);

            if (requestedOrder != null)
            {
                return View(requestedOrder);
            }
            return RedirectToAction("index", "home");
        }

     


        [Authorize]
        [HttpGet]
        public IActionResult OrdersManagment()
        {
            IEnumerable<Order> orders = orderRepo.GetAllOrders();
            return View(orders);
        }

        [Authorize]
        public IActionResult Delete(Order order)
        {
           if(order != null)
            {
                orderRepo.Delete(order);
            }
            return RedirectToAction("OrdersManagment");
        }



    }
}