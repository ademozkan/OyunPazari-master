using System;


namespace OyunPazari.Service.TransferObjects.DataTransferObjects
{
    //Sepetteki bir ürünü temsil eden sınıf.
    public class CartItem
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }


        //Sepetteki miktarını tutmak için
        public short Quantity { get; set; }

        public string ImagePath { get; set; }

    }
}
