using OyunPazari.Core.Entity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OyunPazari.Core.Entity
{
    public class CoreEntity
    {
        //Burası tüm entitylerin ortak özelliklerinin belirtileceği yerdir.

        //Alttakiler burada tanımlamak yerine coremap sınıfında tanımladık. Orayı kontrol etmeyi unutmayınız.

        //[Column(Order =1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public Status Status { get; set; }




        //Alttaki özellikler loglama amaçlıdır.

        //İlk ekleme anı özellikleri

        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedADUserName { get; set; }





        //Güncelleme anı özellikleri

        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedADUserName { get; set; }


    }
}
