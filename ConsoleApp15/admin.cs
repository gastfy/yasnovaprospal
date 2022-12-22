using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class admin : CRUD
    {
        private int _pos;
        private string _name;
        private bool _isError;

        public admin(string AdminName) 
        {
            _name = AdminName;
            Read();
        }

        public void Create()
        {
            List<user> users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
            Console.Clear();
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();
            Console.Write("Введите уникальный ID: ");
            string ID = Console.ReadLine();
            Console.Write("Введите роль: ");
            string Role = Console.ReadLine();
            user new_user = new user(name, password, Role, ID);
            users.Add(new_user);
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json", users);
        }
        public void Update()
        {
            int pos = 0;
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            while (true)
            {
                List<user> users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos -= 1;
                    if (pos > users.Count - 1) { pos = users.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos += 1;
                    if (pos > users.Count - 1) { pos = users.Count - 1; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    users[pos] = ReadType(users[pos]);
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json", users);
                    Console.Clear();
                    int y = 0;
                    foreach (var item in users)
                    {
                        Console.SetCursorPosition(3, y);
                        Console.Write(item.Login);
                        Console.SetCursorPosition(25, y);
                        Console.Write(item.Role);
                        Console.SetCursorPosition(45, y);
                        Console.Write(item.ID);
                        y += 1;
                    }
                    Console.SetCursorPosition(75, 0);
                    Console.Write("F1 - Добавление");
                    Console.SetCursorPosition(75, 1);
                    Console.Write("F2 - Удаление");
                    Console.SetCursorPosition(75, 2);
                    Console.Write("F4 - Фильтр поиска");
                    Console.SetCursorPosition(75, 5);
                    Console.Write("Вы зашли под логином: " + _name);
                    Console.SetCursorPosition(3, users.Count + 3);
                    Console.Write("Логин");
                    Console.SetCursorPosition(25, users.Count + 3);
                    Console.Write("Роль");
                    Console.SetCursorPosition(45, users.Count + 3);
                    Console.Write("ID");

                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json", users);
                    login login = new login();
                    break;
                }
                else if(key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Create();
                    Console.Clear();
                    
                    users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
                    int y = 0;
                    foreach (var item in users)
                    {
                        Console.SetCursorPosition(3, y);
                        Console.Write(item.Login);
                        Console.SetCursorPosition(25, y);
                        Console.Write(item.Role);
                        Console.SetCursorPosition(45, y);
                        Console.Write(item.ID);
                        y += 1;
                    }
                    y = 0;
                    Console.SetCursorPosition(75, 0);
                    Console.Write("F1 - Добавление");
                    Console.SetCursorPosition(75, 1);
                    Console.Write("F2 - Удаление");
                    Console.SetCursorPosition(75, 2);
                    Console.Write("F4 - Фильтр поиска");
                    Console.SetCursorPosition(75, 5);
                    Console.Write("Вы зашли под логином: " + _name);
                    Console.SetCursorPosition(3, users.Count + 3);
                    Console.Write("Логин");
                    Console.SetCursorPosition(25, users.Count + 3);
                    Console.Write("Роль");
                    Console.SetCursorPosition(45, users.Count + 3);
                    Console.Write("ID");
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    _pos = pos;
                    Delete();
                    Console.Clear();
                    if (_isError)
                    {
                        Console.SetCursorPosition(75, 7);
                        Console.WriteLine("Вы не можете удалить активный профиль!");
                        _isError = false;
                        Console.SetCursorPosition(0, 0);
                    }
                    else
                    {
                        Console.Clear();
                    }
                    
                    users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
                    int y = 0;
                    foreach (var item in users)
                    {
                        Console.SetCursorPosition(3, y);
                        Console.Write(item.Login);
                        Console.SetCursorPosition(25, y);
                        Console.Write(item.Role);
                        Console.SetCursorPosition(45, y);
                        Console.Write(item.ID);
                        y += 1;
                    }
                    y = 0;
                    Console.SetCursorPosition(75, 0);
                    Console.Write("F1 - Добавление");
                    Console.SetCursorPosition(75, 1);
                    Console.Write("F2 - Удаление");
                    Console.SetCursorPosition(75, 2);
                    Console.Write("F3 - Фильтр поиска");
                    Console.SetCursorPosition(75, 5);
                    Console.Write("Вы зашли под логином: " + _name);
                    Console.SetCursorPosition(3, users.Count + 3);
                    Console.Write("Логин");
                    Console.SetCursorPosition(25, users.Count + 3);
                    Console.Write("Роль");
                    Console.SetCursorPosition(45, users.Count + 3);
                    Console.Write("ID");
                }
                else if(key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.Write("Введите TAG по которому искать пользователей(это может быть login, роль или ID): ");
                    string findableItem = Console.ReadLine();
                    FindByItem(findableItem);
                }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }
            
        }

        public void Delete()
        {
            List<user> users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
            if (users[_pos].Login != _name)
            {
                users.Remove(users[_pos]);
                CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json", users);
            }
            else
            {
                _isError = true;
            }
        }
        public void Read()
        {
            Console.Clear();
            int y = 0;
            List<user> users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
            int pos = 0;
            foreach(var item in users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Login);
                Console.SetCursorPosition(25, y);
                Console.Write(item.Role);
                Console.SetCursorPosition(45, y);
                Console.Write(item.ID);
                y += 1;
            }
            y = 0;
            Console.SetCursorPosition(75, 0);
            Console.Write("F1 - Добавление");
            Console.SetCursorPosition(75, 1);
            Console.Write("F2 - Удаление");
            Console.SetCursorPosition(75, 5);
            Console.Write("Вы зашли под логином: " + _name);
            Console.SetCursorPosition(75, 2);
            Console.Write("F3 - Фильтр поиска");
            Console.SetCursorPosition(3, users.Count + 3);
            Console.Write("Логин");
            Console.SetCursorPosition(25, users.Count + 3);
            Console.Write("Роль");
            Console.SetCursorPosition(45, users.Count + 3);
            Console.Write("ID");
            Update();
        }
        private user ReadType(user item) // это кароче метод апдейт только апдейт я тогда расписал как менюшку поэтому все так
        {
            Console.Clear();
            List<user> users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
            Console.WriteLine($"   ID: {item.ID}\n   Login: {item.Login}\n   Password: {item.Password}\n   Role: {item.Role}");
            int pos = 0;
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos -= 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("  ");
                    pos += 1;
                    if (pos > 3) { pos = 3; }
                    if (pos < 0) { pos = 0; }
                }
                else if(key.Key == ConsoleKey.Enter)
                {
                    if(pos == 0)
                    {
                        Console.SetCursorPosition(7, 0);
                        Console.Write("                             ");
                        Console.SetCursorPosition(7, 0);
                        string new_ID = Console.ReadLine();
                        item.ID = new_ID;
                    }
                    else if(pos == 1)
                    {
                        Console.SetCursorPosition(10, 1);
                        Console.Write("                             ");
                        Console.SetCursorPosition(10, 1);
                        string new_login = Console.ReadLine();
                        item.Login = new_login;
                    }
                    else if(pos == 2)
                    {
                        Console.SetCursorPosition(13, 2);
                        Console.Write("                             ");
                        Console.SetCursorPosition(13, 2);
                        string new_password = Console.ReadLine();
                        item.Password = new_password;
                    }
                    else if(pos == 3)
                    {
                        Console.SetCursorPosition(9, 3);
                        Console.Write("                             ");
                        Console.SetCursorPosition(9, 3);
                        string new_role = Console.ReadLine();
                        item.Role = new_role;
                    }
                    Console.Clear();
                    Console.WriteLine($"   ID: {item.ID}\n   Login: {item.Login}\n   Password: {item.Password}\n   Role: {item.Role}");
                }
                else if(key.Key == ConsoleKey.Escape) { break; }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }
            return item;
        }
        private void FindByItem(string foundableItem)
        {
            Console.Clear();
            List<user> users = CringeConverter.CringeDeserializer<List<user>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
            List<user> sorted_users = new List<user>();
            foreach(user user in users)
            {
                if(foundableItem.Equals(user.ID) || foundableItem.Equals(user.Role) || foundableItem.Equals(user.Login))
                {
                    sorted_users.Add(user);
                }
            }
            int y = 0;
            foreach(var item in sorted_users)
            {
                Console.SetCursorPosition(3, y);
                Console.Write(item.Login);
                Console.SetCursorPosition(25, y);
                Console.Write(item.Role);
                Console.SetCursorPosition(45, y);
                Console.Write(item.ID);
                y += 1;
            }
            y = 0;
            Console.SetCursorPosition(75, 0);
            Console.Write("F1 - Добавление");
            Console.SetCursorPosition(75, 1);
            Console.Write("F2 - Удаление");
            Console.SetCursorPosition(75, 3);
            Console.Write("F3 - Фильтр поиска");
            Console.SetCursorPosition(75, 4);
            Console.Write("F4 - Сбросить фильтр поиска");
            Console.SetCursorPosition(75, 7);
            Console.Write("Вы зашли под логином: " + _name);
            Console.SetCursorPosition(3, sorted_users.Count + 3);
            Console.Write("Логин");
            Console.SetCursorPosition(25, sorted_users.Count + 3);
            Console.Write("Роль");
            Console.SetCursorPosition(45, sorted_users.Count + 3);
            Console.Write("ID");
            int position = 0;
            Console.SetCursorPosition(0, position);
            Console.Write("->");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.Write("  ");
                    position -= 1;
                    if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                    if (position < 0) { position = 0; }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, position);
                    Console.Write("  ");
                    position += 1;
                    if (position > sorted_users.Count - 1) { position = sorted_users.Count - 1; }
                    if (position < 0) { position = 0; }
                }
                else if(key.Key == ConsoleKey.F1)
                {
                    Console.Clear();
                    Create();
                    Console.Clear();
                    foreach (var item in sorted_users)
                    {
                        Console.WriteLine($"   Login: {item.Login} - Role: {item.Role} - ID: {item.ID}");
                    }
                    Console.SetCursorPosition(75, 0);
                    Console.Write("F1 - Добавление");
                    Console.SetCursorPosition(75, 1);
                    Console.Write("F2 - Удаление");
                    Console.SetCursorPosition(75, 2);
                    Console.Write("F3 - Фильтр поиска");
                    Console.SetCursorPosition(75, 3);
                    Console.Write("F4 - Сбросить фильтр поиска");
                    Console.SetCursorPosition(75, 5);
                    Console.Write("Вы зашли под логином: " + _name);
                    Console.SetCursorPosition(15, sorted_users.Count + 3);
                    Console.Write("Логин");
                    Console.SetCursorPosition(27, sorted_users.Count + 3);
                    Console.Write("Роль");
                    Console.SetCursorPosition(35, sorted_users.Count + 3);
                    Console.Write("ID");

                }
                else if(key.Key == ConsoleKey.F2)
                {
                    int index = users.IndexOf(sorted_users[position]);
                    users.RemoveAt(index);
                    sorted_users.Remove(sorted_users[position]);
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json", users);
                    Console.Clear();
                    foreach (var item in sorted_users)
                    {
                        Console.WriteLine($"   Login: {item.Login} - Role: {item.Role} - ID: {item.ID}");
                    }
                    Console.SetCursorPosition(75, 0);
                    Console.Write("F1 - Добавление");
                    Console.SetCursorPosition(75, 1);
                    Console.Write("F2 - Удаление");
                    Console.SetCursorPosition(75, 3);
                    Console.Write("F3 - Фильтр поиска");
                    Console.SetCursorPosition(75, 4);
                    Console.Write("F4 или Escape - Сбросить фильтр поиска");
                    Console.SetCursorPosition(75, 7);
                    Console.Write("Вы зашли под логином: " + _name);
                    Console.SetCursorPosition(3, sorted_users.Count + 3);
                    Console.Write("Логин");
                    Console.SetCursorPosition(25, sorted_users.Count + 3);
                    Console.Write("Роль");
                    Console.SetCursorPosition(45, sorted_users.Count + 3);
                    Console.Write("ID");
                }
                else if(key.Key == ConsoleKey.F3)
                {
                    Console.Clear();
                    Console.Write("Введите TAG по которому искать пользователей(это может быть login, роль или ID): ");
                    string findableItem = Console.ReadLine();
                    FindByItem(findableItem);
                    break;
                }
                else if(key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Read();
                    break;
                }
                Console.SetCursorPosition(0, position);
                Console.Write("->");
            }
            
        }
    }
}
