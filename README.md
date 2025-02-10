# Clean Architecture Setup

Bu repo, projelerinizde baþlangýç noktasý olarak kullanabileceðiniz bir Clean Architecture yapýsý içermektedir. Bu yapý, modern yazýlým geliþtirme prensiplerine uygun olarak tasarlanmýþtýr ve esnek, sürdürülebilir ve test edilebilir bir kod tabaný oluþturmanýza yardýmcý olur. Ayrýca, **.NET Aspire** ve **Scalar** gibi modern araçlar da entegre edilmiþtir.

---

## Mimari ve Tasarým Desenleri

### Mimari Desen
- **Clean Architecture**: Proje, katmanlý bir mimari yapýsýna sahiptir ve baðýmlýlýklarýn tersine çevrilmesi (Dependency Inversion) prensibine uygun olarak tasarlanmýþtýr. Bu sayede, uygulama katmanlarý birbirinden baðýmsýz hale gelir ve daha kolay test edilebilir ve sürdürülebilir bir yapý oluþturulur.

### Tasarým Desenleri
- **Result Pattern**: Ýþlem sonuçlarýný tutarlý bir þekilde yönetmek ve hata durumlarýný merkezi olarak ele almak için kullanýlýr.
- **Repository Pattern**: Veri eriþim katmanýný soyutlamak ve veri eriþim kodunu merkezi bir yapýda yönetmek için kullanýlýr.
- **CQRS Pattern**: Komut ve sorgu sorumluluklarýný ayýrarak, uygulamanýn daha ölçeklenebilir ve bakýmý kolay hale gelmesini saðlar.
- **Unit of Work Pattern**: Veritabaný iþlemlerini atomik olarak yönetmek ve tutarlýlýðý saðlamak için kullanýlýr.

---

## Kullanýlan Kütüphaneler ve Araçlar

### Temel Kütüphaneler
- **Entity Framework Core**: ORM (Object-Relational Mapping) aracý olarak kullanýlýr ve veritabaný iþlemlerini kolaylaþtýrýr.
- **AutoMapper**: Nesneler arasýnda otomatik olarak eþleme yapmak için kullanýlýr.
- **FluentValidation**: Giriþ doðrulama iþlemlerini yönetmek ve hata mesajlarýný özelleþtirmek için kullanýlýr.
- **MediatR**: CQRS pattern'ini uygulamak ve komut/sorgu iþlemlerini merkezi olarak yönetmek için kullanýlýr.
- **TS.Result**: Ýþlem sonuçlarýný standart bir yapýda tutmak ve hata yönetimini kolaylaþtýrmak için kullanýlýr.
- **Mapster**: AutoMapper'a alternatif olarak kullanýlabilecek bir nesne eþleme kütüphanesidir.
- **TS.EntityFrameworkCore.GenericRepository**: Generic repository pattern'ini uygulamak ve veri eriþim iþlemlerini kolaylaþtýrmak için kullanýlýr.
- **OData**: RESTful API'lerde sorgulama iþlemlerini kolaylaþtýrmak ve esnek bir sorgulama yapýsý sunmak için kullanýlýr.
- **Scrutor**: Dependency Injection (DI) konteynerýna otomatik olarak servisleri kaydetmek için kullanýlýr.

### Modern Araçlar
- **.NET Aspire**: Bulut-native uygulamalar geliþtirmek ve daðýtmak için kullanýlan bir araç setidir. Mikroservisler, daðýtýlmýþ sistemler ve bulut tabanlý çözümler için idealdir.
- **Scalar**: API dokümantasyonunu otomatik olarak oluþturmak ve geliþtiricilere interaktif bir API deneyimi sunmak için kullanýlýr. Swagger/OpenAPI tabanlýdýr ve API'lerinizi daha anlaþýlýr hale getirir.

---

## Proje Yapýsý

Proje, Clean Architecture prensiplerine uygun olarak aþaðýdaki katmanlara ayrýlmýþtýr:

1. **Domain**: Uygulamanýn çekirdek iþ mantýðýný içerir. Entity'ler, value object'ler, domain servisleri ve domain event'ler bu katmanda bulunur.
2. **Application**: Uygulama katmaný, domain katmaný ile iletiþim kurar ve iþ akýþlarýný yönetir. CQRS pattern'i bu katmanda uygulanýr.
3. **Infrastructure**: Veri eriþim, harici servis entegrasyonlarý ve diðer altyapýsal iþlemler bu katmanda yer alýr. Repository pattern ve Unit of Work pattern bu katmanda uygulanýr.
4. **WebAPI**: API katmanýdýr. Bu katman uygulama katmanýna istekleri iletir.

---

## Kurulum ve Baþlangýç

1. **Repository'yi Klonlayýn**:
   ```bash
   git clone https://github.com//emreylmz7/CleanArchitectureSetup.git
   ```

2. **Gerekli Paketleri Yükleyin**:
   ```bash
   dotnet restore
   ```

3. **Veritabanýný Ayarlayýn**:
   - `appsettings.json` dosyasýnda veritabaný baðlantý dizesini güncelleyin.
   - Entity Framework Core migrations'larý çalýþtýrarak veritabanýný oluþturun:
     ```bash
     dotnet ef database update
     ```

4. **.NET Aspire ile Çalýþtýrýn**:
   - .NET Aspire, bulut-native uygulamalar için gerekli ortamý otomatik olarak ayarlar. Projeyi Aspire ile çalýþtýrmak için:
     ```bash
     dotnet run --project AspireHostProject
     ```

5. **Scalar ile API Dokümantasyonunu Görüntüleyin**:
   - Scalar, Swagger/OpenAPI tabanlý bir API dokümantasyon aracýdýr. API dokümantasyonunu görüntülemek için:
     ```bash
     dotnet run --project Presentation
     ```
   - Tarayýcýnýzda `https://localhost:7088/scalar/v1` adresine giderek interaktif API dokümantasyonunu görüntüleyebilirsiniz.

---

## Katkýda Bulunma

Bu projeye katkýda bulunmak isterseniz, lütfen aþaðýdaki adýmlarý izleyin:

1. Repo'yu fork edin.
2. Yeni bir branch oluþturun (`git checkout -b feature/AmazingFeature`).
3. Deðiþikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`).
4. Branch'inizi pushlayýn (`git push origin feature/AmazingFeature`).
5. Bir Pull Request açýn.

---

## Lisans

Bu proje MIT lisansý altýnda lisanslanmýþtýr. Daha fazla bilgi için `LICENSE` dosyasýna bakýn.

---

Bu README dosyasý, projenizin yapýsýný ve kullanýlan teknolojileri açýklamak için temel bir baþlangýç noktasýdýr. Projenizin gereksinimlerine göre bu dosyayý daha da özelleþtirebilirsiniz.