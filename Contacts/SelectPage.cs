using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts
{
    internal class SelectPage
    {
        private List<Person> kisiler;

        public void Rehber()
        {
            kisiler = new List<Person>()
            {
                new Person("Cavit","Bağcı",111111),
                new Person("Irmak", "Taskin",222222),
                new Person("Ahmet","Ahmetoğlu",333333),
                new Person("Mehmet","Mehmetçocuğu",444444),
                new Person("Ayşe","Yılmaz",555555),
                new Person("Fatma","Aras",555555),
            };
            Select();
        }

        public void Select()
        {
            bool continue1 = true;
            while (continue1)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz");
                Console.WriteLine("(1)-Rehberi Görüntüle");
                Console.WriteLine("(2)-Rehberde Kişi Ara");
                Console.WriteLine("(3)-Rehbere Kişi Ekle");
                Console.WriteLine("(4)-Rehberdeki Kişiyi Sil");
                Console.WriteLine("(5)-Rehberdeki Kişiyi Güncelle");
                Console.WriteLine("(0)-Uygulamadan Çıkmak İçin");

                int select = int.Parse(Console.ReadLine());

                switch (select)
                {
                    case 0:
                        continue1 = false;
                        break;
                    case 1:
                        RehberGoruntule();
                        break;
                    case 2:
                        RehberdeAra();
                        break;
                    case 3:
                        RehbereEkle();
                        break;
                    case 4:
                        RehberdenSil();
                        break;
                    case 5:
                        RehberGuncelle();
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim yaptınız lütfen 1 ile 4 arasında bir değer giriniz");
                        break;
                }
            }
        }

        private void RehberGoruntule()
        {
            Console.WriteLine("Rehber Görüntüleniyor:");
            Console.WriteLine("************************");

            foreach (Person person in kisiler)
            {
                Console.WriteLine("{0} {1} : {2}", person.FirstName, person.LastName, person.PhoneNumber);
            }
        }

        private void RehbereEkle()
        {
            Console.Write("İsim Giriniz: ");
            string FirstName = Console.ReadLine();

            Console.Write("Soyisim Giriniz: ");
            string LastName = Console.ReadLine();

            Console.Write("Telefon Numarası Giriniz: ");
            int PhoneNumber = int.Parse(Console.ReadLine());

            Person kisiekle = new Person(FirstName, LastName, PhoneNumber);
            kisiler.Add(kisiekle);
        }

        private void RehberdeAra()
        {
            Console.WriteLine("İsim/soyisime göre arama yapmak için: (1) Telefon numarasına göre arama yapmak için: (2)");
            int secim = int.Parse(Console.ReadLine());
            switch (secim)
            {
                case 1:
                    Console.WriteLine("İsim/Soyisim giriniz.");
                    string aranan = Console.ReadLine();

                    List<Person> bulunanKisiler = kisiler.Where(Person =>
                    Person.FirstName.IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    Person.LastName.IndexOf(aranan, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                    foreach (Person person in bulunanKisiler)
                    {
                        Console.WriteLine("İsim : {0} Soyisim : {1} | Telefon Numarası : {2}", person.FirstName, person.LastName, person.PhoneNumber);
                    }
                    break;
                case 2:
                    Console.WriteLine("Telefon numarası giriniz.");
                    int telno = int.Parse(Console.ReadLine());

                    Person bulunanKisilerWNo = kisiler.FirstOrDefault(Person =>
                    Person.PhoneNumber.Equals(telno));

                    Console.WriteLine("İsim : {0} Soyisim : {1} | Telefon Numarası : {2}", bulunanKisilerWNo.FirstName, bulunanKisilerWNo.LastName, bulunanKisilerWNo.PhoneNumber);
                    break;
            }
        }

        private void RehberdenSil()
        {
            Console.WriteLine("Silmek istediğiniz kişinin ismini ya da soyismini yazınız.");
            string aranan = Console.ReadLine();

            Person bulunanKisi = kisiler.FirstOrDefault(Person =>
            Person.FirstName.Equals(aranan, StringComparison.OrdinalIgnoreCase) ||
            Person.LastName.Equals(aranan, StringComparison.OrdinalIgnoreCase));

            if (bulunanKisi == null)
            {
                Console.WriteLine("Girdiğiniz isim rehberde yok");
            }
            else
            {
                Console.WriteLine("{0} isimli kişi rehberinizden silinecek işlemi onaylıyor musunuz? (Y/N)", aranan);
                string silmeOnay = Console.ReadLine();
                switch (silmeOnay)
                {
                    case "y":
                        Console.WriteLine("{0} Rehberinizden siliniyor...", aranan);
                        kisiler.Remove(bulunanKisi);
                        break;
                    case "n":
                        Console.WriteLine("İşlem iptal edilmiştir.");
                        break;
                }
            }
        }

        private void RehberGuncelle()
        {
            Console.WriteLine("Güncellemek istediğiniz kişinin ismini yazınız.");
            string GuncellenecekKisi = Console.ReadLine();

            Person bulunanKisi = kisiler.FirstOrDefault(Person =>
            Person.FirstName.Equals(GuncellenecekKisi, StringComparison.OrdinalIgnoreCase) ||
            Person.LastName.Equals(GuncellenecekKisi, StringComparison.OrdinalIgnoreCase));

            if (bulunanKisi == null)
            {
                Console.WriteLine("Böyle birisi rehberinizde yok.");
            }
            else
            {
                Console.WriteLine("Yeni numarayı yazınız.");
                int newNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("{0} isimli kişinin numarası {1}'den {2} olacaktır onaylıyor musunuz? (Y/N)", bulunanKisi.FirstName, bulunanKisi.PhoneNumber, newNumber);

                string guncellemeOnay = Console.ReadLine();
                switch (guncellemeOnay)
                {
                    case "y":
                        bulunanKisi.PhoneNumber = newNumber;
                        Console.WriteLine("{0} Kişinin numarası güncellenmiştir.", bulunanKisi.FirstName);
                        break;
                    case "n":
                        Console.WriteLine("İşlem iptal edilmiştir.");
                        break;
                }
            }
        }
    }
}
