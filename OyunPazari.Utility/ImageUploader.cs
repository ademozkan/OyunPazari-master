using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OyunPazari.Utility
{
    public class ImageUploader
    {
        //Hata Kodları
        //0 => Dosya Boş
        //1 => Dosya Zaten Var
        //2 => Uzantı Hatası

        public static string UploadSingleImage(string serverPath,HttpPostedFileBase file)
        {
            if (file!=null)
            {
                //Eğer dosya boş değilse, kullanıcının gönderdiği dosyanın adını değiştirmek için (kendi klasör yolu ile birlikte gelecketiri. O şekilde kaydetmek istemeyiz) altta değişken oluşturuyoruz.
                Guid yeniDosyaAdi = Guid.NewGuid();

                //Server yolunda ~ işaretileri kalmasın diye onlarıyok ediyoruz.
                serverPath = serverPath.Replace("~", string.Empty);

                string[] fileArr = file.FileName.Split('.');

                //Dosya uzantısını yakalıyoruz.
                string dosyaUzantisi = fileArr[fileArr.Length - 1];


                //Yeni dosya adı ile, yakaladığımız uzantıyı birleştiriyoruz.
                string dosya = yeniDosyaAdi + "." + dosyaUzantisi;

                //Uzantı kontrolü
                if (dosyaUzantisi=="jpg" || dosyaUzantisi=="png" || dosyaUzantisi=="jpeg" || dosyaUzantisi=="gif")
                {
                    //Eğer zaten böyle bir dosya varsa (Belirtilen yolda belirtilen isimde bir dosya varsa)
                    // Örnek => /Uploads/3b172ca8-6a5b-44be-8525-ad43436f4edd.jpeg
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath+dosya)))
                    {
                        return "1";
                    }
                    else
                    {
                        //Herşey yolunda artık dosyayı kaydedip, dosyanın yolunu geriye return edebiliriz.
                        var dosyaYolu = HttpContext.Current.Server.MapPath(serverPath + dosya);
                        file.SaveAs(dosyaYolu);
                        //Dosyanın yolunu döndürür bizde bu sayede veritabanında dosya yolunu yani ImagePath sütunu tutabiliriz.
                        return serverPath + dosya;
                    }


                }
                else
                {
                    return "2";
                }


            }
            else
            {
                return "0";
            }
        }

    }
}
