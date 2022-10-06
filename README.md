# Rise Tech Assessment

Birbirleri ile haberleşen iki microservice'in olduğu, basit 
bir telefon rehberi uygulaması

1. Appsettings.development.json dosyalarında connectionstringler düzenlenmeli.
2.ContactService ve ReportService veritabanı tablolarını local databasemizde oluşturabilmemiz için nuget package console'da default proje olarak RiseAssessment.ContactService.Infrastructure seçili olacak şekilde `update-database` yazıyoruz. Aynı Şekilde RiseAssessment.ReportService.Infrastructure içinde yapıyoruz. ![alt text]( https://github.com/mustafayasarr/RiseAssessment/blob/development/Images/migration.png "Database oluşturma")
3. Kuyruklama olarak RabbitMQ kullanıldı. Ben localde docker ile ayağa kaldırdım. Rabbitmq connection bilgilerini appsettings dosyasından değiştirilebiir.
4. Projede Subscriber olarak DotNetCore.CAP kullanılmıştır.
5. Http Client haberleşme için RestSharp kullanıldı.

## ContactService.ContactAPI

1. Projede api dökümantasyonu olarak swagger kullanılmıştır.
2. Contact ve ContactInformation adında 2 adet entity oluşturulmuştur.
3. Context, repository ve migration **RiseAssessment.ContactService.Infrastructure** katmanında yer almaktadır.
4. Cap dashboard bulunmaktadır. https://localhost:7046/cap yazılarak gidilebilir.

## ReportService.ReportAPI
1. ReportItems isminde entity bulunmaktadır.
2. Swagger ile ayağa kalkmaktadır.
3. Rapor talebi için **CreateLocationReport** endpointine istek atılır.
4. Atılan istek ile birlikte rapor Id ile veritabanında bekler ve rapor talebini cap ile kuyruğa gönderir ve Contactserviceden rapor beklenir.
5. Rapor hazırlandıktan sonra reporservice geri gelir ve excel oluşturulup RiseAssessment.ReportService.ReportAPI içerisinde Reports klasörüne kaydedilir.
6. GetListReport endpointinde raporlara durumlarına ve excel linklerine burada ulaşılır.
