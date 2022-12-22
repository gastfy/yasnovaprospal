using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class cassier : CRUD
    {
        private string Name;
        private int _pos;
        public cassier(string name)
        {
            Name = name;
            Menu(0);
        }

        public void Create()
        {
            if (File.Exists("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json"))
            {
                List<Cassier_goods> cassier_Goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json");
                cassier_Goods[_pos].used_count += 1;
                CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json", cassier_Goods);
            }
            else
            {
                List<Cassier_goods> goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
                goods[_pos].used_count += 1;
                CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json", goods);
            }
            Menu(_pos);
        }

        public void Delete()
        {
            if (File.Exists("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json")) 
            {
                List<Cassier_goods> cassier_Goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json");
                if (cassier_Goods[_pos].used_count > 0)
                {
                    cassier_Goods[_pos].used_count -= 1;
                }
                else
                {
                    cassier_Goods[_pos].used_count = 0;
                }
                CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json", cassier_Goods);
            }
            else
            {
                List<Cassier_goods> goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
                if (goods[_pos].used_count > 0)
                {
                    goods[_pos].used_count -= 1;
                }
                else
                {
                    goods[_pos].used_count = 0;
                }
                CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", goods);
            }
            Menu(_pos);
        }

        public void Menu(int posit)
        {
            int pos = posit;
            List<Cassier_goods> goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            Read();
            Console.SetCursorPosition(85, 0);
            Console.Write("\'+\' - Добавить в чек 1 позицию.");
            Console.SetCursorPosition(85, 1);
            Console.Write("\'-\' - Убрать из чека 1 позицию.");
            Console.SetCursorPosition(85, 2);
            Console.Write("S - Завершить покупку.");
            Console.SetCursorPosition(85, 3);
            Console.Write("Escape - Выход в меню");
            Console.SetCursorPosition(3, goods.Count + 2);
            Console.Write("Название");
            Console.SetCursorPosition(20, goods.Count + 2);
            Console.Write("ID");
            Console.SetCursorPosition(25, goods.Count + 2);
            Console.Write("Количество на складе");
            Console.SetCursorPosition(50, goods.Count + 2);
            Console.Write("Цена за штуку");
            Console.SetCursorPosition(65, goods.Count + 2);
            Console.Write("Выбранно");
            Console.SetCursorPosition(0, pos);
            Console.Write("->");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > goods.Count - 1) { pos = goods.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > goods.Count - 1) { pos = goods.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if(key.Key == ConsoleKey.OemPlus)
                {
                    _pos = pos;
                    Console.Clear();
                    Create();
                    break;
                }
                else if(key.Key == ConsoleKey.OemMinus)
                {
                    _pos = pos;
                    Console.Clear();
                    Delete();
                    break;
                }
                else if(key.Key == ConsoleKey.S)
                {
                    Console.Clear();
                    Update();
                    break;
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    login lo = new login();
                    break;
                }



                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }

        }

        public void Read()
        {
            List<Cassier_goods> goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            int y = 0;
            if (File.Exists("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json"))
            {
                goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json");
                foreach (Cassier_goods item in goods)
                {
                    Console.SetCursorPosition(3, y);
                    Console.Write(item.Name);
                    Console.SetCursorPosition(20, y);
                    Console.Write(item.ID);
                    Console.SetCursorPosition(35, y);
                    Console.Write(item.Amount);
                    Console.SetCursorPosition(50, y);
                    Console.Write(item.CostForPiece);
                    Console.SetCursorPosition(65, y);
                    Console.Write(item.used_count);
                    y += 1;
                }
            }
            else
            {
                foreach (Cassier_goods item in goods)
                {
                    Console.SetCursorPosition(3, y);
                    Console.Write(item.Name);
                    Console.SetCursorPosition(20, y);
                    Console.Write(item.ID);
                    Console.SetCursorPosition(35, y);
                    Console.Write(item.Amount);
                    Console.SetCursorPosition(50, y);
                    Console.Write(item.CostForPiece);
                    Console.SetCursorPosition(65, y);
                    Console.Write(item.used_count);
                    y += 1;
                }
            }
        }

        public void Update()
        {
            List<goods> goods = CringeConverter.CringeDeserializer<List<goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json");
            List<Cassier_goods> cas_goods = CringeConverter.CringeDeserializer<List<Cassier_goods>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json");
            int a = 0;
            int sum = 0;
            foreach (goods item in goods)
            {
                if (cas_goods[a].used_count > item.Amount) { sum = item.Amount * item.CostForPiece; item.Amount -= item.Amount; }
                else
                {
                    item.Amount -= cas_goods[a].used_count;
                    sum += item.CostForPiece * cas_goods[a].used_count;
                }
                a += 1;
            }
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\goods.json", goods);
            List<salaries> helpme = CringeConverter.CringeDeserializer<List<salaries>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json");
            salaries vichet = new salaries(Convert.ToString(helpme.Count-1), "Покупка", sum, $"{Convert.ToString(DateTime.UtcNow.Date).Split(' ')[0]}", "Прибыль");
            helpme.Add(vichet);
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\viplat.json", helpme);
            File.Delete("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\cassier_goods.json");
            Menu(0);
        }
    }
}
