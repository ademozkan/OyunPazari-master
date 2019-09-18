using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Model.Entities
{
    public class OrderDetail:CoreEntity
    {
        public short Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal UnitPrice { get; set; }

        //Ürün İlişkisi
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        //Sipariş İlişkisi
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}