﻿NTier Proje Adımları

--Core--
1)Ntier.Core C# Library açılır=>Entity Framework yüklenir.
1.1)Entity klasörü açılır.
1.1.1)IEntity açılır (Core Entity buradan miras alacaktır)
1.1.2)Core Entity açılır. Tüm entitylerin kullanacağı propertyler tanımlanır.
1.2)Enum Açılır, içerisine statuler eklenir.
1.3)Map açılır. temel entity propertylerinin maplemeleri yapılır(maximum karakter alanı vb...)
1.4)Service açılır.İçerisine ICoreService interface açılır.Her entity üzerinde çalışacak olan metotlar tanımlanır.

--Model--
2)Model C# Library açılır=>NTier.Core referanslara eklenir.
2.1)Option klasörü açılır.
2.1.1)AppUser,Category ve Product entityleri oluşturulur. Hepsi CoreEntity sınıfından miras almalıdır. Bu sayede ortak propertylere erişim sağlanacaktır.

--Map--
3)Map C# Library açılır.Entity Framework yüklenir,Referanslara Core ve Model eklenir.
3.1)Option Klasörü açılır.
3.1.1)Her entity için mapleme işlemleri gerçekleştirilir.(Category ve Product için ekstra ilişki durumu belirtilir.)


--Dal--
4)Dal katmanı oluşturulur. Context klasörü açılır içerisine Project COntext sınıfı oluşturulur.
4.1)Constructor ile db connection yazılır.
4.2)OnModelCreating override edilir ve mapler konfigürasyonlara eklenir.
4.3)SaveChanges override edilir ve yükleme aşamasında temel propertyler içerisinde değerler eklenir.
NOT:Ip yakalama gibi işlemler Utility Katmanı açılarak gerçekleştirilir. Projeye yararlı olacak genel sınıf ve metotlar bu katman içerisinde saklanır. Utility library Dal içerisine eklenmeli.

5)console üzerinden DAL projesi seçilerek enable-migrations -enableAutomaticMigrations yazılır. Arkasından problem yaşanmadıysa update-database yazılarak veri tabanı oluşturulur.

--Service--
6)Service katmanı yazılır. BaseService içerisinde genel olarak kullanılacak olan metotlar generic(genel) şekilde yazılır.ICoreService interfaceten miras alınarak devam edilir.
6.1)Option klasörü açılır. İçerisine tüm entitylerimizin service sınıfları açılır ve serviceBase'den miras alınır.Entity'e özel bir metot var ise(checkCredentiails vb) bu metotlar sınıfların içerisine eklenir.

--UI--
7)UI katmanı içerisine Admin Area açılır. UI katmanına EntitiyFramework yüklenmelidir. 
7.1)Core Model ve Service referanslara eklenmelidir.
7.2)Admin sayfası için bir template oluşturulur. Shared Layout olarak kaydedilir.
7.2.1)Admin template için start bootstrap admin panelini kullandık. Daha önce hazırlamış olduğumuz şablonu kendi _layout sayfamıza kopyaladık ve eski projedeki content klasörünü de projemize sürükleyip bıraktık.
7.3)Controllerlar açılarak viewler oluşturulur.
7.4)Authentication işlemleri en son yapılırsa daha rahat olacaktır. Attribute klasörü açarak rol bazlı auth işlemleri gerçekleştirebiliriz.