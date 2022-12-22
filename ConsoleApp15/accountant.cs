using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class accountant : CRUD
    {
        private string Name;
        private int _pos;
        public accountant(string name)
        {
            Name = name;
            Menu();
        }


        public void Create()
        {
            List<salaries> AllSalaries = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            Console.Clear();
            Console.Write("Введите фамилию: ");
            string name = Console.ReadLine();
            Console.Write("Введите ID: ");
            string ID = Console.ReadLine();
            Console.Write("Введите сумму: ");
            int sum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите дату: ");
            string date = Console.ReadLine();
            Console.Write("Введите тип транзакции(зарплата/вычет): ");
            string type = Console.ReadLine();
            Console.Clear();
            salaries salary = new salaries(ID, name, sum, date, type);
            AllSalaries.Add(salary);
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json", AllSalaries);
            Menu();
        }

        public void Delete()
        {
            List<salaries> AllSalaries = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            Console.Clear();
            AllSalaries.Remove(AllSalaries[_pos]);
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json", AllSalaries);
            Menu();
        }

        public void Read()
        {
            List<salaries> AllSalaries = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            int y = 0;
            foreach (salaries item in AllSalaries)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.ID);
                Console.SetCursorPosition(35, y);
                Console.Write(item.sum);
                Console.SetCursorPosition(50, y);
                Console.Write(item.date);
                Console.SetCursorPosition(65, y);
                Console.Write(item.dopOrMinus);
                y += 1;
            }


        }

        public void Update()
        {
            List<salaries> AllSalaries = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            Console.Clear();
            Console.WriteLine($"    Фамилия: {AllSalaries[_pos].Name}");
            Console.WriteLine($"    ID: {AllSalaries[_pos].ID}");
            Console.WriteLine($"    Сумма: {AllSalaries[_pos].sum}");
            Console.WriteLine($"    Дата: {AllSalaries[_pos].date}");
            Console.WriteLine($"    Тип операции: {AllSalaries[_pos].dopOrMinus}");

            int pos = 0;
            Console.SetCursorPosition(70, 0);
            Console.Write("Enter - изменить параметр");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > 4) { pos = 4; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > 4) { pos = 4; }
                    if (pos < 0) { pos = 0; }
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json", AllSalaries);
                    Menu();
                    break;
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    if (pos == 0)
                    {
                        Console.SetCursorPosition(12,0);
                        Console.Write("                  ");
                        Console.SetCursorPosition(13, 0);
                        AllSalaries[_pos].Name = Console.ReadLine();
                    }
                    else if (pos == 1)
                    {
                        Console.SetCursorPosition(7, 1);
                        Console.Write("                  ");
                        Console.SetCursorPosition(8, 1);
                        AllSalaries[_pos].ID = Console.ReadLine();

                    }
                    else if (pos == 2)
                    {
                        Console.SetCursorPosition(10, 2);
                        Console.Write("                  ");
                        Console.SetCursorPosition(11, 2);
                        AllSalaries[_pos].sum = Convert.ToInt32(Console.ReadLine());

                    }
                    else if(pos == 3)
                    {
                        Console.SetCursorPosition(8, 3);
                        Console.Write("                  ");
                        Console.SetCursorPosition(9, 3);
                        AllSalaries[_pos].date = Console.ReadLine();
                    }
                    else if(pos == 4)
                    {
                        Console.SetCursorPosition(17, 4);
                        Console.Write("                  ");
                        Console.SetCursorPosition(18, 4);
                        AllSalaries[_pos].dopOrMinus = Console.ReadLine();
                    }

                }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");

            }


        }
        public void Find(string Fitem)
        {
            int pos = 0;
            List<salaries> AllSalaries = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            List<salaries> sorted = new List<salaries>();
            foreach (salaries salaries in AllSalaries)
            {
                if ((salaries.Name == Fitem) || (salaries.ID == Fitem) || (salaries.date == Fitem) || (salaries.dopOrMinus == Fitem) || (salaries.sum == Convert.ToInt32(Fitem)))
                {
                    sorted.Add(salaries);
                }
            }
            int y = 0;
            foreach (salaries item in sorted)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.ID);
                Console.SetCursorPosition(35, y);
                Console.Write(item.sum);
                Console.SetCursorPosition(50, y);
                Console.Write(item.date);
                Console.SetCursorPosition(65, y);
                Console.Write(item.dopOrMinus);
                y += 1;
            }
            Console.SetCursorPosition(85, 0);
            Console.Write("F1 - Добавить выплату");
            Console.SetCursorPosition(85, 1);
            Console.Write("F2 - Изменить выплату");
            Console.SetCursorPosition(85, 2);
            Console.Write("F3 - Удалить выплату");
            Console.SetCursorPosition(85, 3);
            Console.Write("F4(Escape) - Сбросить фильтр");
            Console.SetCursorPosition(85, 5);
            Console.Write("Здравствуйте, " + Name + "!");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(3, sorted.Count + 2);
            Console.Write("Имя");
            Console.SetCursorPosition(20, sorted.Count + 2);
            Console.Write("ID");
            Console.SetCursorPosition(35, sorted.Count + 2);
            Console.Write("Сумма");
            Console.SetCursorPosition(50, sorted.Count + 2);
            Console.Write("Дата");
            Console.SetCursorPosition(65, sorted.Count + 2);
            Console.Write("Тип операции");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > sorted.Count - 1) { pos = sorted.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > sorted.Count - 1) { pos = sorted.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if ((key.Key == ConsoleKey.Escape) || (key.Key == ConsoleKey.F4))
                {
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json", AllSalaries);
                    Console.Clear();
                    break;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Create();
                    break;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    _pos = AllSalaries.IndexOf(sorted[pos]);
                    Update();
                    break;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    _pos = AllSalaries.IndexOf(sorted[pos]);
                    Delete();
                    break;
                }

                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }


        }


        public void Menu()
        {
            int pos = 0;
            List<salaries> AllSalaries = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            Read();
            Console.SetCursorPosition(85, 0);
            Console.Write("F1 - Добавить выплату");
            Console.SetCursorPosition(85, 1);
            Console.Write("F2 - Изменить выплату");
            Console.SetCursorPosition(85, 2);
            Console.Write("F3 - Удалить выплату");
            Console.SetCursorPosition(85, 3);
            Console.Write("F4 - Найти выплату");
            Console.SetCursorPosition(85, 5);
            Console.Write("Здравствуйте, " + Name + "!");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(3, AllSalaries.Count + 2);
            Console.Write("Имя");
            Console.SetCursorPosition(20, AllSalaries.Count + 2);
            Console.Write("ID");
            Console.SetCursorPosition(35, AllSalaries.Count + 2);
            Console.Write("Сумма");
            Console.SetCursorPosition(50, AllSalaries.Count + 2);
            Console.Write("Дата");
            Console.SetCursorPosition(65, AllSalaries.Count + 2);
            Console.Write("Тип операции");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > AllSalaries.Count - 1) { pos = AllSalaries.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > AllSalaries.Count - 1) { pos = AllSalaries.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json", AllSalaries);
                    Console.Clear();
                    login lo = new login();
                    break;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    Create();
                    break;
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    _pos = pos;
                    Update();
                    break;
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    _pos = pos;
                    Delete();
                    break;
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    Console.WriteLine("Введите ключ, по которому будет производиться поиск: ");
                    string keyz = Console.ReadLine();
                    Console.Clear();
                    Find(keyz);
                    break;
                }

                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }

        }


    }
}
