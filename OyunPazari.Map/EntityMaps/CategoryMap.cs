using OyunPazari.Core.Map;
using OyunPazari.Model.Entities;


namespace OyunPazari.Map.EntityMaps
{
    public class CategoryMap:CoreMap<Category>
    {
        //ctor + tab + tab
        public CategoryMap()
        {
            ToTable("dbo.Categories");

            Property(cat => cat.Name).IsRequired();


            //Fluent API(Map işlemleri) ve genel olarak Entity Framework hakkında alttaki linkten gerekli bilgileri alabilirsiniz.
            //https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx


            //Kategori - Ürün İlişkisi => Zaten sınıflar içerisinde gerekli ilişki tanımlamalarını gerçekleştirdiğimiz için, alttaki kodları yazmamıza gerek yoktur.
            
            HasMany(cat => cat.Products)  //Kategorinin bir sürü ürünü vardır.
                .WithRequired(product => product.Category) //Ürünlerin zorunlu kategorisi vardır.
                .HasForeignKey(product => product.CategoryID) //İkincil anahtar üründeki CategoryID'dir.
                .WillCascadeOnDelete(false); //Kategoriler silindiğinde ürünler silinmesin(false yazdıgımız için)


        }
    }
}
