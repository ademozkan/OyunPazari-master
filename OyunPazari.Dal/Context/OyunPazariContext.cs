using OyunPazari.Core.Entity;
using OyunPazari.Map.EntityMaps;
using OyunPazari.Model.Entities;
using OyunPazari.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OyunPazari.Dal.Context
{
    public class OyunPazariContext:DbContext
    {
        public OyunPazariContext()
        {
            Database.Connection.ConnectionString = @"server=.;database=OyunPazariDB;uid=sa;pwd=123;";
            //Database.Connection.ConnectionString = @"server=.;database=OyunPazariDB;Integrated Security = True";
            //Üstteki windows authentication içindir.


            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OyunPazariContext>()); //Bu strateji sayesinde modeldeki bir değişimde (Örnek Product classına yeni bir property eklenmesi gibi) veritabanı Drop edilir ve baştan oluşturulur.

            //Database.SetInitializer(new CreateDatabaseIfNotExists<OyunPazariContext>()); //Varsayılan olandır
            //Database.SetInitializer(new DropCreateDatabaseAlways<OyunPazariContext>()); //Her init yapılşında veritabanı baştan oluşturulur.
            //Database.SetInitializer(new CustomStrategySınıfınız());

            //Stratejileri kapatmak istersek:
            //Database.SetInitializer<OyunPazariContext>(null);

        }

        //Map sınıflarımızı da context'e dahil edebilmek için modellerin (entitylerin) tabloya dönüştürülmesi anında çalışacak olan onModelCreating metodunu yani modelleri tabloya dönüştüren metodu override ederek çağırıyoruz. DB Kurallarımızı da dahil etmesini sağlıyoruz.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());

            base.OnModelCreating(modelBuilder);
        }


        //Dbsetleri oluşturmazsak, tablolar oluşmaz.
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }


        public override int SaveChanges()
        {
            //Otomatik loglama amaçlı kullanılan bazı özelliklerin doldurulması için, savechannges öetodunu override ediyoruz.

            //İlk olarak yeni eklenen veya yeni güncellenen tüm kayıtları yakalamalıyız.

            //ChangeTracker nesnesi savechanges metodu çağırıldığında bizim yaptığımız tüm kayıtlardaki değişimleri takip eden nesnedir.

            //Alttaki kodda eklenmeyi bekleyen veya güncellenmeyi bekleyen tüm kayıtları yani entry'leri yakalıyoruz.
            var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);


            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime date = DateTime.Now;
            //Utility projesinden çekilir.
            string ip = RemoteIP.IpAddress;
            //string ip = default(string);

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (entity != null)
                {
                    if (item.State==EntityState.Added)
                    {
                        entity.Status = Core.Entity.Enum.Status.Active;
                        entity.CreatedADUserName = identity;
                        entity.CreatedComputerName = computerName;
                        entity.CreatedIP = ip;
                        entity.CreatedDate = date;
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.ModifiedADUserName = identity;
                        entity.ModifiedComputerName = computerName;
                        entity.ModifiedIP = ip;
                        entity.ModifiedDate = date;
                    }
                }
            }




            return base.SaveChanges();
        }



    }
}
