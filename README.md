# Clean Architecture Setup

Bu repo, projelerinizde ba�lang�� noktas� olarak kullanabilece�iniz bir Clean Architecture yap�s� i�ermektedir. Bu yap�, modern yaz�l�m geli�tirme prensiplerine uygun olarak tasarlanm��t�r ve esnek, s�rd�r�lebilir ve test edilebilir bir kod taban� olu�turman�za yard�mc� olur. Ayr�ca, **.NET Aspire** ve **Scalar** gibi modern ara�lar da entegre edilmi�tir.

---

## Mimari ve Tasar�m Desenleri

### Mimari Desen
- **Clean Architecture**: Proje, katmanl� bir mimari yap�s�na sahiptir ve ba��ml�l�klar�n tersine �evrilmesi (Dependency Inversion) prensibine uygun olarak tasarlanm��t�r. Bu sayede, uygulama katmanlar� birbirinden ba��ms�z hale gelir ve daha kolay test edilebilir ve s�rd�r�lebilir bir yap� olu�turulur.

### Tasar�m Desenleri
- **Result Pattern**: ��lem sonu�lar�n� tutarl� bir �ekilde y�netmek ve hata durumlar�n� merkezi olarak ele almak i�in kullan�l�r.
- **Repository Pattern**: Veri eri�im katman�n� soyutlamak ve veri eri�im kodunu merkezi bir yap�da y�netmek i�in kullan�l�r.
- **CQRS Pattern**: Komut ve sorgu sorumluluklar�n� ay�rarak, uygulaman�n daha �l�eklenebilir ve bak�m� kolay hale gelmesini sa�lar.
- **Unit of Work Pattern**: Veritaban� i�lemlerini atomik olarak y�netmek ve tutarl�l��� sa�lamak i�in kullan�l�r.

---

## Kullan�lan K�t�phaneler ve Ara�lar

### Temel K�t�phaneler
- **Entity Framework Core**: ORM (Object-Relational Mapping) arac� olarak kullan�l�r ve veritaban� i�lemlerini kolayla�t�r�r.
- **AutoMapper**: Nesneler aras�nda otomatik olarak e�leme yapmak i�in kullan�l�r.
- **FluentValidation**: Giri� do�rulama i�lemlerini y�netmek ve hata mesajlar�n� �zelle�tirmek i�in kullan�l�r.
- **MediatR**: CQRS pattern'ini uygulamak ve komut/sorgu i�lemlerini merkezi olarak y�netmek i�in kullan�l�r.
- **TS.Result**: ��lem sonu�lar�n� standart bir yap�da tutmak ve hata y�netimini kolayla�t�rmak i�in kullan�l�r.
- **Mapster**: AutoMapper'a alternatif olarak kullan�labilecek bir nesne e�leme k�t�phanesidir.
- **TS.EntityFrameworkCore.GenericRepository**: Generic repository pattern'ini uygulamak ve veri eri�im i�lemlerini kolayla�t�rmak i�in kullan�l�r.
- **OData**: RESTful API'lerde sorgulama i�lemlerini kolayla�t�rmak ve esnek bir sorgulama yap�s� sunmak i�in kullan�l�r.
- **Scrutor**: Dependency Injection (DI) konteyner�na otomatik olarak servisleri kaydetmek i�in kullan�l�r.

### Modern Ara�lar
- **.NET Aspire**: Bulut-native uygulamalar geli�tirmek ve da��tmak i�in kullan�lan bir ara� setidir. Mikroservisler, da��t�lm�� sistemler ve bulut tabanl� ��z�mler i�in idealdir.
- **Scalar**: API dok�mantasyonunu otomatik olarak olu�turmak ve geli�tiricilere interaktif bir API deneyimi sunmak i�in kullan�l�r. Swagger/OpenAPI tabanl�d�r ve API'lerinizi daha anla��l�r hale getirir.

---

## Proje Yap�s�

Proje, Clean Architecture prensiplerine uygun olarak a�a��daki katmanlara ayr�lm��t�r:

1. **Domain**: Uygulaman�n �ekirdek i� mant���n� i�erir. Entity'ler, value object'ler, domain servisleri ve domain event'ler bu katmanda bulunur.
2. **Application**: Uygulama katman�, domain katman� ile ileti�im kurar ve i� ak��lar�n� y�netir. CQRS pattern'i bu katmanda uygulan�r.
3. **Infrastructure**: Veri eri�im, harici servis entegrasyonlar� ve di�er altyap�sal i�lemler bu katmanda yer al�r. Repository pattern ve Unit of Work pattern bu katmanda uygulan�r.
4. **WebAPI**: API katman�d�r. Bu katman uygulama katman�na istekleri iletir.

---

## Kurulum ve Ba�lang��

1. **Repository'yi Klonlay�n**:
   ```bash
   git clone https://github.com//emreylmz7/CleanArchitectureSetup.git
   ```

2. **Gerekli Paketleri Y�kleyin**:
   ```bash
   dotnet restore
   ```

3. **Veritaban�n� Ayarlay�n**:
   - `appsettings.json` dosyas�nda veritaban� ba�lant� dizesini g�ncelleyin.
   - Entity Framework Core migrations'lar� �al��t�rarak veritaban�n� olu�turun:
     ```bash
     dotnet ef database update
     ```

4. **.NET Aspire ile �al��t�r�n**:
   - .NET Aspire, bulut-native uygulamalar i�in gerekli ortam� otomatik olarak ayarlar. Projeyi Aspire ile �al��t�rmak i�in:
     ```bash
     dotnet run --project AspireHostProject
     ```

5. **Scalar ile API Dok�mantasyonunu G�r�nt�leyin**:
   - Scalar, Swagger/OpenAPI tabanl� bir API dok�mantasyon arac�d�r. API dok�mantasyonunu g�r�nt�lemek i�in:
     ```bash
     dotnet run --project Presentation
     ```
   - Taray�c�n�zda `https://localhost:7088/scalar/v1` adresine giderek interaktif API dok�mantasyonunu g�r�nt�leyebilirsiniz.

---

## Katk�da Bulunma

Bu projeye katk�da bulunmak isterseniz, l�tfen a�a��daki ad�mlar� izleyin:

1. Repo'yu fork edin.
2. Yeni bir branch olu�turun (`git checkout -b feature/AmazingFeature`).
3. De�i�ikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`).
4. Branch'inizi pushlay�n (`git push origin feature/AmazingFeature`).
5. Bir Pull Request a��n.

---

## Lisans

Bu proje MIT lisans� alt�nda lisanslanm��t�r. Daha fazla bilgi i�in `LICENSE` dosyas�na bak�n.

---

Bu README dosyas�, projenizin yap�s�n� ve kullan�lan teknolojileri a��klamak i�in temel bir ba�lang�� noktas�d�r. Projenizin gereksinimlerine g�re bu dosyay� daha da �zelle�tirebilirsiniz.