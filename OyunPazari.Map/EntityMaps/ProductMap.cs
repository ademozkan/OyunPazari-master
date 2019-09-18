using OyunPazari.Core.Map;
using OyunPazari.Model.Entities;


namespace OyunPazari.Map.EntityMaps
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");
            Property(product => product.UnitPrice).IsOptional();
            Property(product => product.UnitsInStock).IsOptional();
            //Kategori ilişkisi categoryMap altında, OrderDetail ilişkisi OrderDetailMap altında var. Bu nedenle burada bir daha yazmaya gerek yoktur.

        }
    }
}
