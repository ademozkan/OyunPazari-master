using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Model.Entities
{
    public class Product:CoreEntity
    {
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public string Name { get; set; }
        public long UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public bool DisplayOnWeb { get; set; }
        public bool DisplayOnMobile { get; set; }
        public string Features { get; set; }

        //Kategori İlişkisi
        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //Sipariş Detay İlişkisi
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
