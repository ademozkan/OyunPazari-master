using OyunPazari.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace OyunPazari.Core.Map
{
    //Core Entity tüm sınıflara miras veren sınıftır. Şu an yazmakta oldugumuz sınıf ise tüm map sınıflarına yani tüm db kurallarına sahip entity sınıflarının ortak map sınfıını yaratmak içindir. Aynı zamanda da Core Entity özelliklerinin burada db kurallarını oluşturuyoruz.

    //Nasıl core entity tüm sınıflara miras veriyorsa, core map sınfıı da tüm map sınıflarına miras verecektir.
    //Bu noktada dikkat etmemiz gereken direk entity sınfılarını kullanamamamız. CoreMap sınıfında tüm entitylerin ortak sınıfı lan coreentity sınıfından destek alıyoruz. Bu sayede tüm entity sınıflarımız buradan türediği için daha sonra problem yaşanmayacaktır.


    //Entity framework kurallarını tanımlamak için gerekli sınıf EntityTypeConfiguration sınıfıdır. Bu sınıftan miras alırsam, db kurallarımızı tanımlayabilirim(Maximum karakter sayısı, zorunluluk durumu sütun/kolon veri tipi vb)


    public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(core => core.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnOrder(1);


            Property(core => core.Status).IsOptional();

            //Eklemede Kullanılan propertylerin Kuralları
            Property(core => core.CreatedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.CreatedBy).IsOptional();


            //Güncellemede Kullanılan propertylerin Kuralları
            Property(core => core.ModifiedDate).HasColumnType("datetime2").IsOptional();
            Property(core => core.ModifiedBy).IsOptional();

        }
    }
}
