using OyunPazari.Model.Entities;
using OyunPazari.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OyunPazari.Service.Concrete
{
    public class ProductService:BaseService<Product>
    {
        
        public List<Product> GetLatestProducts(int productCount)
        {
            return _context.Products.Where(product => product.Status == Core.Entity.Enum.Status.Active).OrderByDescending(product => product.CreatedDate).Take(productCount).ToList();
        }


        public List<Product> GetProductsByCategoryID(Guid id) => GetDefault(product => product.CategoryID == id && product.Status == Core.Entity.Enum.Status.Active);


        public Product GetProductByID(Guid id) => GetByDefault(product => product.ID == id);


    }
}
