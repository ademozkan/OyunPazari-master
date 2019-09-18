using OyunPazari.Model.Entities;
using OyunPazari.Service.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace OyunPazari.Service.Concrete
{
    public class OrderService : BaseService<Order>
    {
        public List<Order> ListPendingOrders()
        {

            return GetDefault(order => order.OrderStatus != OrderStatus.Declined
            && order.OrderStatus != OrderStatus.Cancelled
            && order.OrderStatus != OrderStatus.Completed);
        }

        public List<Order> LastOrders(int count)
        {
            return _context.Orders.Where(order => order.OrderStatus != OrderStatus.Declined
           && order.OrderStatus != OrderStatus.Cancelled
           && order.OrderStatus != OrderStatus.Completed).OrderByDescending(o=>o.CreatedDate).Take(count).ToList();
        }

    }
}
