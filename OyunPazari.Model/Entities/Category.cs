using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Model.Entities
{
    public class Category:CoreEntity
    {

        public Category()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}