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
Ben rabbitmq_server-3.13.3 ve erlang 14.2.5 ile çalıştım.
<br>
rabbitMQ download: https://github.com/rabbitmq/rabbitmq-server/releases/download/v3.13.3/rabbitmq-server-3.13.3.exe
<br>
erlang download: https://www.erlang.org/patches/otp-26.2.5
