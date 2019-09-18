using OyunPazari.Core.Map;
using OyunPazari.Model.Entities;


namespace OyunPazari.Map.EntityMaps
{
    public class OrderDetailMap:CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");

            Property(od => od.UnitPrice).IsOptional();
            Property(od => od.Quantity).IsOptional();

            //OrderDetail - Product İlişkisi
            HasRequired(od => od.Product)
                .WithMany(product => product.OrderDetails)
                .HasForeignKey(od => od.ProductID)
                .WillCascadeOnDelete(false);

        }
    }
}