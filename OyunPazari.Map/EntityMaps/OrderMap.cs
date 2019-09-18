using OyunPazari.Core.Map;
using OyunPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Map.EntityMaps
{
    public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");
            Property(o => o.TotalPrice).IsOptional();
            Property(o => o.OrderDate).HasColumnType("datetime2").IsOptional();
            Property(o => o.OrderStatus).IsOptional();
            Property(o => o.ApprovalDate).HasColumnType("datetime2").IsOptional();


            //Order - AppUser İlişkisi
            HasRequired(o => o.AppUser)
                .WithMany(user => user.Orders)
                .HasForeignKey(o => o.AppUserID)
                .WillCascadeOnDelete(false);

            //Order - OrderDetail İlişkisi
            HasMany(o => o.OrderDetails)
                .WithRequired(od => od.Order)
                .HasForeignKey(od => od.OrderID)
                .WillCascadeOnDelete(false);


        }
    }
}
