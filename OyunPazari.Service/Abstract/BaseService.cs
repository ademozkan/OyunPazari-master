using OyunPazari.Core.Entity;
using OyunPazari.Core.Service;
using OyunPazari.Dal.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Service.Abstract
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Bu sınıfın amacı, ortak tüm metotlarımızı tanımlamak, yani tüm entitylerimizin/tablolarımızın işine yarayacak metotları bir kere yazmak ve daha sonrasında bu sınıfı ve içerisindeki metotları miras vermek.
        //Eğer miras alan sınıfların kendilerine özel metotları varsa, onlar o sınıfların altında tanımlanacaktır.


        protected OyunPazariContext _context;

        public BaseService()
        {
            _context = new OyunPazariContext();
        }


        public bool Add(T item)
        {
            try
            {
                //_context.Products.Add();
                _context.Set<T>().Add(item);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Add(List<T> items)
        {
            try
            {
                _context.Set<T>().AddRange(items);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<T> GetActive()
        {
            return _context.Set<T>().Where(x => x.Status == Core.Entity.Enum.Status.Active).ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            try
            {
                item.Status = Core.Entity.Enum.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(Guid id,Guid userID)
        {
            try
            {
                T item = GetByID(id);
                item.Status = Core.Entity.Enum.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(Guid id)
        {
            try
            {
                T item = GetByID(id);
                item.Status = Core.Entity.Enum.Status.Deleted;
                Update(item);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                T itemToBeUpdated = GetByID(item.ID);
                DbEntityEntry entry = _context.Entry(itemToBeUpdated);
                entry.CurrentValues.SetValues(item);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
