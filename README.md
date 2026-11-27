\# YMH219 - Key Event Logger



Windows Forms ile geliştirilmiş, yalnızca kendi penceresi aktifken tuş olaylarını yakalayan ve zaman damgasıyla listeleyen masaüstü uygulaması. Nesne Tabanlı Programlama (YMH 219) ek uygulama ödevi kapsamında hazırlanmıştır.



\## Kullanılan Teknolojiler

\- C#

\- .NET (Windows Forms)

\- Visual Studio



\## Kurulum ve Çalıştırma

1\. Repoyu klonla: `git clone https://github.com/saryaasu/YMH219-KeyEventLogger.git`

2\. Proje çözüm dosyasını (`.sln` veya `.slnx`) Visual Studio ile aç

3\. \*\*F5\*\* ile çalıştır



\## Uygulama Kontrolleri

\- \*\*Başlat:\*\* Aktif form penceresinde tuş kaydını başlatır

\- \*\*Durdur:\*\* Tuş kaydını durdurur

\- \*\*Temizle:\*\* Ekrandaki ve bellekteki tuş kayıtlarını temizler

\- \*\*TXT Kaydet:\*\* Kayıtları `.txt` dosyasına kaydeder



\## Temel Özellikler

\- `KeyPreview` özelliği ve `KeyDown` olayı ile yalnızca uygulama penceresi aktifken basılan tuşun adını ve zaman bilgisini listeleme

\- `Başlat`, `Durdur`, `Temizle` ve `TXT Kaydet` butonları ile kayıt sürecini ve dışa aktarımı yönetme

\- `Durum` göstergesi ile kayıt durumunu açıkça belirtme

\- `SaveFileDialog` ve `StreamWriter` ile kayıtları yerel `.txt` dosyasına kaydetme ve hata durumlarında `MessageBox` ile bilgilendirme

\- Nesne tabanlı yapı: `KeyEventRecord` (zaman, olay türü, tuş adı ve biçimlendirilmiş kayıt çıktısı) ve `Form1` (arayüz, durum yönetimi ve olay yakalama)



\## Ekran Görüntüleri



\### Kayıt Aktif Ekranı

!\[Kayıt Aktif](screenshots/kayıtta.png)



\### Tuş Kayıtları ve TXT Kaydetme

!\[Kayıtlar](screenshots/yazıkaydı.png)



\### Kayıt Durdurulmuş Ekranı

!\[Pasif Durum](screenshots/kayıtbaslamadan.png)



\## Bilinen Sınırlamalar / Geliştirme Notları

\- Yalnızca uygulama penceresi odaktayken çalışır; sistem geneli veya arka plan tuş yakalama yapılmaz

\- İsteğe bağlı olarak tuş sıklığı istatistiği veya tarih-saat filtreleme henüz eklenmedi

\- Kayıtlar otomatik değil, kullanıcı butona bastığında `.txt` dosyasına aktarılır



\## Öğrenci

Sarya Su Toğyıldız - 250542024

