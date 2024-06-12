Solution, birden fazla startup proje ile çalışmaktadır.
<br>
<br>
1-) QueueConsumer (Kuyruğu dinler)
<br>
2-) PhoneGuideReportService.API (Rapor isteklerini alır ve kuyruğa ekler)

visual studio'da bu şekilde gelmezse yukarıdaki sıralamada birden fazla startup proje olacak şekilde ayarlandıktan sonra çalıştırılabilir
<br>
<br>

Uygulamanın çalışacağı sunucuda rabbitMQ ve erlang kurulu olmalıdır. 
<br>
Ben rabbitmq_server-3.13.3 ve erlang 26.2.5 ile çalıştım.
<br>
rabbitMQ download: https://github.com/rabbitmq/rabbitmq-server/releases/download/v3.13.3/rabbitmq-server-3.13.3.exe
<br>
erlang download: https://www.erlang.org/patches/otp-26.2.5
<br>
<br>
RabbitMQ ve erlang kurulduktan sonra system environment variables ayarları yapılmalıdır
<br>
<br>
Sistem değişkenlerine "ERLANG_HOME" keyi eklenerek değeri "C:\Program Files\Erlang OTP" olacak şekilde (bilgisayarda hangi dizine kuruldu ise) ayarlanmalıdır
<br>
<br>
Yine sistem değişkenlerine "RABBITMQ_SERVER" keyi eklenerek değeri "C:\Program Files\rabbitmq_server-3.13.3" olacak şekilde (bilgisayarda hangi dizine kuruldu ise) ayarlanmalıdır
<br>
<br>
Sistem değişkenlerinden "PATH" değişkenine ise "C:\Program Files\rabbitmq_server-3.13.3" ve "C:\Program Files\Erlang OTP\bin" (bilgisayarda hangi dizinlere kuruldu ise) değerleri eklenmelidir
