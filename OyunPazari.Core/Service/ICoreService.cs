using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        //Genel olarak tüm tabloların ihtiyacı olacak davranışları tanımlıyoruz.

        bool Add(T item);
        bool Add(List<T> items);
        bool Update(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        List<T> GetActive();
        T GetByID(Guid id);
        int Save();

        //Alttaki metotlar, parametrelerinde ifade kabul ederler.
        // Örnek : GetDefault(product => product.Price >= 100) gibi.

        T GetByDefault(Expression<Func<T,bool>> exp);
        List<T> GetDefault(Expression<Func<T,bool>> exp);

    }
}
