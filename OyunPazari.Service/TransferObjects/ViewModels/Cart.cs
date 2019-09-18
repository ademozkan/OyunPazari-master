using OyunPazari.Service.TransferObjects.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OyunPazari.Service.TransferObjects.ViewModels
{
    //Genel sepet sınıfı
    public class Cart
    {
        Dictionary<Guid, CartItem> _myCart = new Dictionary<Guid, CartItem>();


        //Dışarıdan sepet istendiğinde dictiobary değil, list olarak çıkacaktır, ancak içerde işlemleri hızlandırmak amacıyla dictionary tipinde çalışma gerçekleşecektir.
        public List<CartItem> MyCart
        {
            get
            {
                return _myCart.Values.ToList();
            }
        }

        public void AddItem(CartItem item)
        {
            if (_myCart.ContainsKey(item.ID))
            {
                _myCart[item.ID].Quantity += 1;
                return;
            }
            _myCart.Add(item.ID, item);
        }

    }
}
