using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExampleWithErrors
{
    //Код неподвижен - все в одном файле!!!! - 1 ошибка
    //Ошибка именования и код стайла (плохая читабельность) - 2 ошибка
    internal class Program
    {
        private class Kontakt
        {
            public string Imya { get; set; }
            public string NomerTelephona { get; set; }
            public TypeKontact TypeKontact { get; set; }

            public override string ToString()
            {
                return $"Имя: {Imya}, Телефон: {NomerTelephona}, Тип контакта: {TypeKontact}";
            }
        }
        
        public enum TypeKontact //жесткость - использование перечислимого типа - 3 ошибка
        {
            Rabochii,
            Domashniy
        }

        public static void Main(string[] args)
        {
            List<Kontakt> kontakty = new List<Kontakt>();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить контакт");
                Console.WriteLine("2. Поиск контакта");
                Console.WriteLine("3. Печать всех контактов");
                Console.WriteLine("4. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": //Добавление нового контакта
                        Console.Write("Введите имя: ");
                        string imya = Console.ReadLine();
                        
                        Console.Write("Введите номер телефона: ");
                        string nomer = Console.ReadLine();
                        
                        Console.Write("Введите тип контакт1а: 0 - рабочий, 1 - домашний ");
                        string tip = Console.ReadLine();
                        
                        //жесткость - использование перечислимого типа
                        Kontakt noviykontakt = new Kontakt
                        {
                            Imya = imya, NomerTelephona = nomer,
                            TypeKontact = tip != null && tip.Equals("0") ? TypeKontact.Rabochii : TypeKontact.Domashniy
                        };
                        kontakty.Add(noviykontakt);
                        Console.WriteLine("Контакт успешно добавлен.");
                        break;

                    case "2": //Поиск по ключевому слову или номеру
                        Console.Write("Введите ключевое слово для поиска: ");
                        string keyword = Console.ReadLine();
                        List<Kontakt> naidennyieResyltaty = kontakty
                            .Where(kontakt =>
                                keyword != null && (kontakt.Imya.Contains(keyword) ||
                                                    kontakt.NomerTelephona.Contains(keyword)))
                            .ToList();
                        Console.WriteLine("Результаты поиска:");
                        if (naidennyieResyltaty.Count == 0)
                        {
                            Console.WriteLine("Контактов не найдено.");
                        }
                        else
                        {
                            naidennyieResyltaty.ForEach(Console.WriteLine);
                        }

                        break;

                    case "3":

                        Console.WriteLine("Список всех контактов:");
                        kontakty.ForEach(Console.WriteLine); //Именование
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}