-Proje Yapısı-
Proje N-Layer Architecture prensiplerine uygun bir şekilde tasarlanmıştır.
SOLID ve OOP prensiplerini maximum seviyede dikkat edilmiş Design Patternlara(Repository Pattern, UnitOfWork Pattern) uygulanmıştır.
ORM aracı olarak EntityFramework kullanılmıştır.
Authantication Autharization işlemleri için JWTBearer ve Identity kütüphaneleri beraber kullanılmıştır.
Hata Yönetimi içi ILogger(Microsoft.Extensions.Logging;)dan faydalanılmış ve Caching için Redis teknolojisi kullanılmıştır.
Validasyon işlemleri için Fluent Validation işlemleri Service katmanında ayrıca işletilmiştir

-Proje Kurulum-
Projeyi cloneladıktan sonra Katmanların csprojlarındaki  Nuget Packageları indirin.
Appsettings.json üzerinden gerekli bilgileri lokalinize uyarlayın.
Migration dosyasının üzerine Ef yardımı ile Package Manager Console yardımıyla Update-Database komutu ile DB oluşturun.
