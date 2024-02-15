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
                new Person("Irmak", "Taskin",222222)
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
                Console.WriteLine("(2)-Rehbere Kişi Ekle");
                Console.WriteLine("(3)-Rehberdeki Kişiyi Sil");
                Console.WriteLine("(4)-Rehberdeki Kişiyi Güncelle");
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
                        Console.WriteLine("Kişi eklenecek");
                        RehbereEkle();
                        break;
                    case 3:
                        Console.WriteLine("Kişi silinecek");
                        RehberdenSil();
                        break;
                    case 4:
                        Console.WriteLine("Kişi güncellenecek");
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

            kisiler.Add(new Person(FirstName, LastName, PhoneNumber));

        }

        private void RehberdenSil()
        {
            Console.WriteLine("Silmek istediğiniz kişinin ismini ya da soyismini yazınız.");
            string aranan = Console.ReadLine();
            Person bulunanKisi = kisiler.FirstOrDefault(Person =>
            Person.FirstName.Equals(aranan, StringComparison.OrdinalIgnoreCase) ||
            Person.LastName.Equals(aranan, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("{0} Rehberinizden siliniyor...", aranan);
            kisiler.Remove(bulunanKisi);
        }

        private void RehberGuncelle()
        {
           
        }
    }
}
