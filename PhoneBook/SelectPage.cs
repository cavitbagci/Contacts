using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
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
                Console.WriteLine("(0)-Yaptığınız işlemi iptal etmek için");

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
                        break;
                    case 3:
                        Console.WriteLine("Kişi silinecek");
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
                Console.WriteLine("{0} {1} : {2}", person.FirstName,person.LastName,person.PhoneNumber);
            }
        }
    }
}
