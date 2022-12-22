using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class storageManager : CRUD
    {
        private string Name;
        private int _pos;
        public storageManager(string name)
        {
            Name = name;
            Menu();
        }


        public void Create()
        {
            List<goods> AllGoods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            Console.Clear();
            Console.Write("Введите название товара: ");
            string _name = Console.ReadLine();
            Console.Write("Введите ID товара: ");
            string _ID = Console.ReadLine();
            Console.Write("Введите количество товара: ");
            int _amount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите цену товара за 1 штуку: ");
            int _price = Convert.ToInt32(Console.ReadLine());
            goods g = new goods(_ID, _name, _price, _amount);
            AllGoods.Add(g);
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", AllGoods);
            Console.Clear();
            Menu();
        }

        public void Delete()
        {
            Console.Clear();
            List<goods> AllGoods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            AllGoods.RemoveAt(_pos);
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", AllGoods);
            Menu();
        }

        public void Read()
        {
            int y = 0;
            List<goods> AllGoods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            foreach (goods item in AllGoods)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.ID);
                Console.SetCursorPosition(35, y);
                Console.Write(item.Amount);
                Console.SetCursorPosition(50, y);
                Console.Write(item.CostForPiece);
                y+=1;
            }


        }

        public void Update()
        {
            int pos = 0;
            List<goods> AllGoods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            Console.Clear();
            Console.WriteLine($"\tНазвание: {AllGoods[_pos].Name}\n\tID: {AllGoods[_pos].ID}\n\tКоличество на складе: {AllGoods[_pos].Amount}\n\tЦена за 1 шт: {AllGoods[_pos].CostForPiece}");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(70, 0);
            Console.Write("Enter - изменить параметр");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);    
                if(key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if(pos > 3) { pos = 3; }
                    if(pos < 0) { pos = 0; }
                }
                else if(key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.Escape) { CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", AllGoods); Console.Clear(); Menu(); break; }
                else if(key.Key == ConsoleKey.Enter)
                {
                    if(pos == 0)
                    {
                        Console.SetCursorPosition(17,0);
                        Console.Write("                 ");
                        Console.SetCursorPosition(18, 0);
                        AllGoods[_pos].Name = Console.ReadLine(); 
                    }
                    else if(pos == 1)
                    {
                        Console.SetCursorPosition(13, 1);
                        Console.Write("                 ");
                        Console.SetCursorPosition(14, 1);
                        AllGoods[_pos].ID = Console.ReadLine();
                    }
                    else if(pos == 2)
                    {
                        Console.SetCursorPosition(29, 2);
                        Console.Write("                 ");
                        Console.SetCursorPosition(30, 2);
                        AllGoods[_pos].Amount = Convert.ToInt32(Console.ReadLine());
                    }
                    else if(pos == 3)
                    {
                        Console.SetCursorPosition(21, 3);
                        Console.Write("                 ");
                        Console.SetCursorPosition(22, 3);
                        AllGoods[_pos].CostForPiece = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.SetCursorPosition(0, pos);//4 - tab
                Console.Write("->");


            }

        }
        public void Find(string zitem)
        {
            Console.Clear();
            int y = 0;
            int pos = 0;
            List<goods> AllGoods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            List<goods> sorted = new List<goods>();
            foreach (goods good in AllGoods)
            {
                if((good.ID == zitem) || (good.Name == zitem) || (good.Amount == Convert.ToInt32(zitem)) || (good.CostForPiece == Convert.ToInt32(zitem)))
                {
                    sorted.Add(good);
                }
            }
            foreach(goods item in sorted)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Name);
                Console.SetCursorPosition(20, y);
                Console.Write(item.ID);
                Console.SetCursorPosition(35, y);
                Console.Write(item.Amount);
                Console.SetCursorPosition(50, y);
                Console.Write(item.CostForPiece);
                y += 1;
            }
            Console.SetCursorPosition(75, 0);
            Console.Write("F1 - Добавить товар на склад");
            Console.SetCursorPosition(75, 1);
            Console.Write("F2 - Изменить товар со склада");
            Console.SetCursorPosition(75, 2);
            Console.Write("F3 - Удалить товар со склада");
            Console.SetCursorPosition(75, 3);
            Console.Write("F4(Escape) - Сбросить фильтры");
            Console.SetCursorPosition(75, 5);
            Console.Write("Здравствуйте, " + Name + "!");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(3, AllGoods.Count + 2);
            Console.Write("Имя");
            Console.SetCursorPosition(20, AllGoods.Count + 2);
            Console.Write("ID");
            Console.SetCursorPosition(35, AllGoods.Count + 2);
            Console.Write("Количество");
            Console.SetCursorPosition(50, AllGoods.Count + 2);
            Console.Write("Цена");
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
                else if((key.Key == ConsoleKey.Escape) || (key.Key == ConsoleKey.F4)){ Console.Clear(); CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", AllGoods); Menu(); break; }
                else if(key.Key == ConsoleKey.F1)
                {
                    Create();
                    break;
                }
                else if(key.Key == ConsoleKey.F2)
                {
                    _pos = AllGoods.IndexOf(sorted[pos]);
                    Update();
                    break;
                }
                else if(key.Key == ConsoleKey.F3)
                {
                    _pos = AllGoods.IndexOf(sorted[pos]);
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
            List<goods> AllGoods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            Read();
            Console.SetCursorPosition(75, 0);
            Console.Write("F1 - Добавить товар на склад");
            Console.SetCursorPosition(75, 1);
            Console.Write("F2 - Изменить товар со склада");
            Console.SetCursorPosition(75, 2);
            Console.Write("F3 - Удалить товар со склада");
            Console.SetCursorPosition(75, 3);
            Console.Write("F4 - Найти товар на складе");
            Console.SetCursorPosition(75, 5);
            Console.Write("Здравствуйте, " + Name + "!");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(3, AllGoods.Count + 2);
            Console.Write("Имя");
            Console.SetCursorPosition(20, AllGoods.Count + 2);
            Console.Write("ID");
            Console.SetCursorPosition(35, AllGoods.Count + 2);
            Console.Write("Количество");
            Console.SetCursorPosition(50, AllGoods.Count + 2);
            Console.Write("Цена");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if(pos > AllGoods.Count - 1) { pos = AllGoods.Count - 1; }
                    if(pos < 0) { pos = 0; }
                }
                else if(key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > AllGoods.Count - 1) { pos = AllGoods.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", AllGoods);
                    Console.Clear();
                    login lo = new login();
                    break;
                }
                else if(key.Key == ConsoleKey.F1)
                {
                    Create();
                    break;
                }
                else if(key.Key == ConsoleKey.F2)
                {
                    _pos = pos;
                    Update();
                    break;
                }
                else if(key.Key == ConsoleKey.F3)
                {
                    _pos = pos;
                    Delete();
                    break;
                }
                else if(key.Key == ConsoleKey.F4)
                {
                    Console.Clear();
                    Console.WriteLine("Введите ключ, по которому будет производиться поиск: ");
                    string keyz = Console.ReadLine();
                    Find(keyz);
                    break;
                }

                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }

        }







        //манабрек искри по питам дастану дизмилейт манабрек цвет маих касаний станет халадней манабрек расикает анивей цепицепицепи паражение литально


    }
}
