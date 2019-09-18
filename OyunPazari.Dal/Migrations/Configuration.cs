namespace OyunPazari.Dal.Migrations
{
    using OyunPazari.Model.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OyunPazari.Dal.Context.OyunPazariContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OyunPazari.Dal.Context.OyunPazariContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            List<AppUser> defaultUsers = new List<AppUser>();

            defaultUsers.Add(new AppUser
            {
                Name = "Theo",
                LastName = "Christian",
                Address = "Westborough, Massachusetts(MA), 01581",
                PhoneNumber = "978-807-8044",
                Email = "terry.hamme10@hotmail.com",
                BirthDate = new DateTime(1995,1,11),
                ImagePath="~/Uploads/terryFoto.jpg",
                Role=Role.Admin,
                UserName="admin",
                Password="123",
                Status=Core.Entity.Enum.Status.Active,
                CreatedDate=DateTime.Now
                
            });

            context.Users.AddRange(defaultUsers);
            base.Seed(context);

        }
    }
}
