using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotes
{
    internal static class Program
    {
        private static List<string> Notes = new List<string>();

        public static void Addendum()
        {
            Console.WriteLine("Введите название заметки");
            string NameNote = Console.ReadLine();
            Notes.Add(NameNote);
        }
        public static void DeleteNote()
        {
            Console.WriteLine("Какую заметку удалить?");
            int IndexNote = int.Parse(Console.ReadLine());
            Notes.RemoveAt(IndexNote);
        }
        public static void DeleteAll()
        {
            Notes.Clear();
        }
        public static void Сhange()
        {
            Console.WriteLine("Какую заметку изменить?");
            int IndexNote = int.Parse(Console.ReadLine());
            if (IndexNote <= Notes.Count - 1)
            {
                Console.WriteLine("На что вы хотите поменять?");
                Notes[IndexNote] = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Нет такой заметки");
            }
        }
        public static void Save()
        {
            string json = JsonConvert.SerializeObject(Notes);
            File.WriteAllText(@"C:\1\Notes.txt", json);
        }
        public static void Load()
        {
            if (File.Exists(@"C:\1\Notes.txt"))
            {
                string json = File.ReadAllText(@"C:\1\Notes.txt");

                Notes = JsonConvert.DeserializeObject<List<string>>(json);
            }
            else
            {
                Console.WriteLine("Нет файла");
            }
        }

        public static void Output()
        {
            for (int i = 0; i < Notes.Count; i++)
            {
                Console.WriteLine(Notes[i]);
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Изменение - 0");
            Console.WriteLine("Добавление - 1");
            Console.WriteLine("Удаление заметки - 2");
            Console.WriteLine("Удаление всех заметок - 3");
            Console.WriteLine("Сохранение - 4");
            Console.WriteLine("Загрузка - 5");
            Console.WriteLine("Вывод заметок - 6");

            int Key = 0;
            try
            {
                Key = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Неверное значение\n");
                Menu();
                return;
            }
            Console.Clear();

            switch (Key)
            {
                case 0:
                    Сhange();
                    break;
                case 1:
                    Addendum();
                    break;
                case 2:
                    DeleteNote();
                    break;
                case 3:
                    DeleteAll();
                    break;
                case 4:
                    Save();
                    break;
                case 5:
                    Load();
                    break;
                case 6:
                    Output();
                    break;
                default:
                    Console.WriteLine("Такого нет");
                    break;
            }
            Console.WriteLine();
            Menu();
        }

        public static void Main()
        {
            Menu();
        }
    }
}




//    Программа “Заметки”
//Программа хранит список заметок, пользователь может добавлять, редактировать и удалять заметки.

//Функционал:

//•	Вывод всех заметок - Console.WriteLine
//•	Добавление новой заметки в список - list
//•	Удаление существующей заметки из списка listName.Remuv(NameNod)
//•	Удаление всех заметок.list.Clear
//•	Изменение существующей заметки, через индекс(через название)
//Нумерование
//•	(Дополнительно) сохранение заметок в файл и загрузка
