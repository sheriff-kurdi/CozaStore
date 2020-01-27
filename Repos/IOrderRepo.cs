using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TShirtCompany.Models;

namespace TShirtCompany.Repos
{
    public interface IOrderRepo
    {
        Order RequestOrder(OrderRequestVM order);
        Order GetOrdertByID(int id);
        IEnumerable<Order> GetAllOrders();
        void Delete(Order pro);
        void Update(Order proToUpdate);
    }
}
