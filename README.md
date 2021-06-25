# Mobiroller


Projeyi katmanlı mimari olarak oluşturdum ve SOLID prensiplerine dikkat ederek ilerlemeye çalıştım.İlk olarak JsonParseHelper oluştararak Json verilerini database pushladım.
Gerekli database yapısını oluşturdum. Database scriptinide klasörleyerek projeye dahil edildi. Postman'ı kullanarak gerekli sorgulamalar yapıldığında Authorize olunması 
gerekmektedir. Authorize olunduktan sonra Accept-Language kısmından "tr-TR" veya "it-IT" kısımları eklenerek o dile ait sorgulamalar gelmektedir.


## İsterler

- **Request Localization :** Postman programından header kısmına "Accept-Language" "tr-TR" ve "it-IT" şeklinde eklenerek gerekli get operasyonları başarıyla tamamlanmıştır.
- **Authentication :** Asp.Net Core JWT teknolojisi kullanılarak gerekli oturum kısıtlama işlemleri yapılmıştır.Sisteme register olup devamında login işlemi yaptığınızda gelen tokeni girip kısıtlamaya dahil olan get ve diğer operasyonları gerçekleştirebilirsiniz.
- **Cache (In-memory or Distributed) :** MemoryCache Aspect Oriented Programming kurallarına uygun bir şekilde cachelenmesi gereken methodların üzerine eklenmiştir.
- **Exception Handler :** IResult, IDataResult gibi genel return işlemleriyle hata yönetimi bir kapsamda ele alınmıştır.
- **Api & Code documentation :** Api dökümantasyonu için Swagger projeye implemente edilip, code dökümantasyonu için ise GitHub.readme alanında genel bilgilendirme yapılmıştır.
- **Validation :** Validasyon yapılandırmasını kullanmak için Business katmanında ValidationRules klasörü altında gerekli kullanıma uygun yapıları oluşturabilirsiniz.


## Katmanlar

- **Core :** Bu katmanda her projede kullanabileceğim ortak yapıları oluşturmaya çalıştım. "Result", "Interceptors", "CrossCuttingCorcerns", "Aspect" vb.
yapıları gibi..
- **DataAccess :** Bu katmanda "Abstract" "Concrete" klasörlemerini oluşturarak Repository Pattern'i kullanmak için "IEventDal" ve "EfEventDal" gibi yapılarımı tuttum.
- **Entities:** Bu kısımda entity ve Dtolarımı kullandım. Bu classları "Core" içindeki "IEntity" ve "IDTo" interfaceleri ile çıplak kalmamasını sağladım.
- **Business :** Gerekli "Services" ve "Manager" yapılarını iş katmanında kullanarak projenin iş yükünü tamamen burada kullandım."DependencyResolvers" klasörü altında gerekli 
implementleri yapmak üzere "AutofacBusinessModule" kullandım.
- **API :** EventsController, CategoriesController ve AuthController olmak üzere 3 controllerdan oluşturdum. JSON import etme, olay listelerini getirme 
sorguları kullandım.

## Cache & Validation & Authentication & Exception Handler & Swagger

- **Cache :** Cache yapısını Core katmanında tasarladım. "CrossCuttingConcerns" klasörü altında "ICacheManager" ve "MemorCacheManager" yapılarını oluşturdum ve gerekli 
methodlarını gerçekleştirdim. Devamında ise iş katmanında "Manager" yapısının üst kısmında kullanmak üzere önceden oluşturup her projede kullandığımız "Aspect Interceptors" 
yapılarını "Core" katmanında (Aspect>Autofac>Caching) "CacheAspect" ve "CacheRemoveAspect" olmak üzere yapılarımı oluşturdum. Devamında ise cachelemek istediğim Get operasyonuna
gerektiği gibi kullandım. "CacheRemoveAspect" ise databaseye ekleme, silme veya güncelleme gibi işlemlerden sonra database değişikliği için cachenin baştan oluşturulması için
bu methodlarda gerekli gibi kullandım.

- **Validation :** Validation için "FluentValidation" package kullandım. "Core" katmanında "CrossCuttingConcerns" klasörü altında "ValidationTool" oluşturdum. Devamında ise 
(Aspect>Autofac>Validation) "ValidationAspect" oluşturup önceden oluşturup her projede kullandığımız "Aspect Interceptors" yapılarını kullandım. Devamında bu validation yapısını
kullanmak üzere "Business" katmanına giderek "ValidationRules>FluentValidation" klasörlemesini yaparak burada entitylerime ait gerekli validasyon işlemlerini gerçekleştirdim.
Son olarak validasyon yaptığım entity'e ait managerlere giderek aspectleri gerektiği gibi kullandım.

- **Authentication :** İlk olarak package olarak AspNet.Core nin JWT projeye eklendi. Start'up içine gerekli ayarlamaları yapılarak Token ve TokenHandler gibi yapılar Core 
katmanı içinde (Utilities>Security>JWT) yer verildi. Devamında ise AuthController da Register ve Login methodları oluşturularak yapı projeye dahil edildi. Kayıt olunduktan sonra
authorize olabilmek için kullanıcıya gerekli tokenlar başarıyla döndürüldü. Bu gelen token girişi sayesinde projenin kullanımı için gerekli yetkilendirme yapıldı.

- **Exception Handler :** Hata yönetiminde ise Core katmanı içinde (Utilities>Results) "Result" yapıları oluşturuldu. Bu yapılar iş katmanlarına implemente edilerek ortak bir
hata yönetimi kullanmaya çalıştım.

- **Swagger :** API dökümantasyonu için Swagger projeye eklendi. Buradan gerekli tüm sorgulamalara ulaşılması sağlandı.

## Kullanılan Teknojiler ve Yapılar

- .Net Core
- EntityFramework Core
- MSSQL
- Autofac
- Aspect Oriented Programming
- JWT
- FluentValidation
- MemoryCache
- Newtonsoft.Json
- IoC
- Swagger

![swagger](https://user-images.githubusercontent.com/64231904/123258213-cc09b480-d4fb-11eb-943b-6b42b49bed53.png)

![sql](https://user-images.githubusercontent.com/64231904/123258505-1c811200-d4fc-11eb-8e4a-e7a703cda18f.png)

![Screenshot_3](https://user-images.githubusercontent.com/64231904/123467364-1b81da80-d5f9-11eb-869c-d1b065358830.png)

