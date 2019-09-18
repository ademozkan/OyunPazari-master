using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Model.Entities
{

    public enum OrderStatus
    {
        None = 0,
        Ordered = 2,
        Processing = 4,
        Completed = 6,
        Cancelled = 8,
        Declined = 10,
        Incomplete = 12,
        PreOrdered = 14
    }

    public class Order : CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public OrderStatus OrderStatus { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ApprovalDate { get; set; }

        //Sipariş Detay İlişkisi
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        //Kullanıcı İlişkisi
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser { get; set; }


    }
}
