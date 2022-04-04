# TelefonRehberMicroservice

Program iki servis ve bir UIdan oluşmaktadır.

Contact.Web UI  - .net Core 5.0, html, css, jquery, signalR <br />
Contact Service - .net Core 5.0, postresql, entityframework <br />
Report Service  - .net Core 5.0, mongodb, RabbitMQ(MassTransit), signalR <br />

Contact.Web : Contact web üzerinden yaptığımız tüm crud işlemleri, contact microservisine istek olarak iletilir. Rapor oluşturma talebi için de Report microservisine istek yapar. <br />
Contact.Service : Contact web üzerinden gelen isteklere cevap verir ve aynı zamanda Report.Service üzerinden gelen Rapor isteğine cevap verir. <br />
Report.Service : Contact tarafından gelen rapor isteğini alır. Kuyruğa ekler ve sırasıyla kuyruktan okur raporu oluştururken contact servisine istekler atıp ilgili rapor verilerini çeker ve rapor tamalandığında client tarafını dosyanın indirmeye hazır olduğu şeklinde bilgilendirir. <br />

Servislerin Çalışacağı Portlar <br />
"Contact.Web"	   : "http://localhost:5010" <br />
"Contact.Services" : "http://localhost:5011" <br />
"Report.Services"  : "http://localhost:5012" <br />

Docker Ayarları : <br />
Contact.Service <br />
	Postresql port : 5432<br />
Report.Service <br />
	mongodb port   : 27017<br />
	rabbitmq port  : 15672<br />


Diğer Ayrıntılar ;<br />
	Contact.Service: Özellikle mimari açısından Contact.Service'yi tüm solid prensiplerine uygun şekilde hazırladım. Çalışmayı katmanlara ayırarak çalıştım. Business,DataAccess,Entities,Web.Api olmak üzere 4 katman var. <br />
		Entities Katmanı	: Burada modellerim ve dtolarım mevcut. <br />
		DataAccess Katmanı	: Burada veritabanı teknoloji seçimime göre bağlantılarım, tablolarım, fluent api işlemleri, custom repositorylerim ve migrationlarım mevcut. <br />
		Business Katmanı	: Burada iş katmanım mevcut aynı zamanda fluent validationlarım ve ioc ayarlarım mevcut. <br />
		Web.Api				: Controllerimin dışında model mapping ve custom filtersleri burada barındırıyorum. <br />
