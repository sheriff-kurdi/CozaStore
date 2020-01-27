using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TShirtCompany.Models;

namespace TShirtCompany.Repos
{
    public class SqlOrderRepo : IOrderRepo
    {
        private readonly DBContext db;

        public SqlOrderRepo(DBContext db)
        {
            this.db = db;
        }



        public Order RequestOrder(OrderRequestVM orderRequestVM)
        {
            int cost = orderRequestVM.ItemNumbers * orderRequestVM.product.Price;
            int numbersOfItems = orderRequestVM.ItemNumbers;

            Size orderSize = orderRequestVM.product.Size;
            string image = orderRequestVM.product.Image;

            Order order = new Order()
            {

                TotallCost = cost,
                ItemName = orderRequestVM.product.Name,
                ItemNumbers = numbersOfItems,
                Size = orderSize,
                CustomerName = orderRequestVM.CustomerName,
                Phone = orderRequestVM.Phone,
                Image = image
            };

            db.Orders.Add(order);
            db.SaveChanges();

            return order;
        }

        public void Delete(Order order)
        {
            db.Remove(order);
            db.SaveChanges();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IEnumerable<Order> orders = db.Orders.ToList();
            return orders;
        }

        public Order GetOrdertByID(int id)
        {
            Order requestedOrder = db.Orders.Find(id);
            return requestedOrder;

        }

        public void Update(Order proToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
