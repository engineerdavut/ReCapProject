using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Constanst
{
    public static class Messages
    {
        public static string CarNameInvalid = " 3 harften kucuk ya da gunluk 0 tl den az kiralama bedeli giremezsiniz";

        public static string CarAdded = " Araciniz veritabanina eklenmistir.";

        public static string MaintenanceTime = " Sistem bakimda.";

        public static string CarListened=" Araclar listelendi. " ;

        public static string BrandInvalid = " 3 harften kucuk marka giremezsiniz";

        public static string BrandAdded = " Markaniz veritabanina eklendi.";

        public static string ColorInvalid = " 3 harften kucuk renk giremezsiniz";

        public static string ColorAdded = " Renginiz veritabanina eklendi.";

        public static string UserAdded = " Kullanici sisteme kayit edildi.";

        public static string Invalid = " Bilgileriniz Gecersiz,Lutfen Dogru Girin.";

        public static string UserListened = " Kullanicilar Listelendi";

        public static string CustomerAdded = " Müsteri veritabanina eklendi.";

        public static string CustomerListened = " Müşteriler listelendi.";

        public static string RentDetailListened = " Kiralama detaylari listelendi";

        public static string RentalError = " Arac Kiralama Hatasi. Arac iade edilmemiş";

        public static string CarRented = " Araç kiralandi";

        public static string UserDeleted = " Kullanici silindi. ";

        public static string GetUser = " Kullanici bilgileri";

        public static string CustomerDeleted = " Müsteri silindi.";

        public static string GetCustomer = " Müsteri bilgileri";

        public static string CarToBeRented = " Kiralanacak araçlar ";

        public static string UserUpdated = " Kullanici bilgileri guncellendi.";

        public static string RentDeleted = " Kiralama bilgisi silindi.";

        public static string CarRentedUpdated = " Arac kiralama bilgisi guncelllendi";

        public static string CarDeleted = " Kiralik araciniz veritabanindan silindi.";

        public static string CustomerUpdated = " Musteri bilgileri guncellendi.";

        public static string ColorDeleted = " Renk  silindi.";

        public static string ColorUpdated = " Renk guncellendi";

        public static string BrandDeleted = " Marka silindi";

        public static string BrandUpdated = " Marka guncellendi";

        public static string GetBrand = " Marka bilgisi. ";

        public static string GetColor = " Renk Bilgisi.";

        public static string GetCar = "  Araç Bilgisi.";

        public static string GetRentDetail = " Kiralama Bilgisi.";
        internal static string FileToSave = " Dosya yolu belirlendi,kadedildi.";

        public static string CarImageLimitExceeded = "Bir aracın en fazla 5 tane fotosu olabilir.";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string UserRegistered="Kullanici olusturuldu";
        public static string AccessTokenCreated="Erisim tokeni olusturuldu";
        public static string UserAlreadyExists="Kullanici zaten kayitli";
        public static string UserNotFound="Kullanici bulunamadi";
        public static string SuccessfulLogin="Giris basarili";
        public static string PasswordError="Sifre hatali";
        public static string CarUpdated="Arac guncellendi.......";
    }
}
