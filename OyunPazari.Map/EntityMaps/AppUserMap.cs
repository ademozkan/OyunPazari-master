using OyunPazari.Core.Map;
using OyunPazari.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Map.EntityMaps
{
    public class AppUserMap:CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.Users");

            Property(user => user.Role).IsOptional();
            Property(user => user.UserName).IsRequired();
            Property(user => user.Email).IsRequired();
            Property(user => user.Password).IsRequired();
            Property(user => user.BirthDate).HasColumnType("datetime2").IsOptional();
        }
    }
}