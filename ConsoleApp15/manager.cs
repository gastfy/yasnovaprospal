using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class manager : CRUD
    {
        private string Name;
        private int _pos;
        public manager(string name)
        {
            Name = name;
            Menu();
        }

        public void Create()
        {
            List<user2> users = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            Console.Clear();
            Console.Write("Введите имя: ");
            string _name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            string _lastname = Console.ReadLine();
            Console.Write("Введите отчество: ");
            string _fathname = Console.ReadLine();
            Console.Write("Введите id (для закрепления имени): ");
            string _idnext = Console.ReadLine();
            Console.Write("Введите дату рождения: ");
            string _bd = Console.ReadLine();
            Console.Write("Введите серию и номер паспорта: ");
            string _passportid = Console.ReadLine();
            Console.Write("Введите должность: ");
            string _jobname = Console.ReadLine();
            Console.Write("Введите зарплату: ");
            string _salary = Console.ReadLine();
            string _id = Convert.ToString(users.Count);
            user2 newuser = new user2(_name, _lastname, _fathname, _id, _bd, _idnext, _passportid, _salary, _jobname);
            users.Add(newuser);
            Console.Clear();
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json", users);
            Menu();
        }
        public void Update()
        {
            Console.Clear();
            List<user2> users = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            Console.WriteLine($"    ID: {users[_pos].ID}\n    Имя: {users[_pos].Name}\n    Фамилия: {users[_pos].LastName}\n    Отчество: {users[_pos].FatherName}\n    День рождения: {users[_pos].BirthDate}\n    Серия и Номер паспорта: {users[_pos].PassportID}\n    Должность: {users[_pos].job_title}\n    Зарплата: {users[_pos].Salary}\n    ID2: {users[_pos].IDNext}");
            int pos = 0;
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(60, 0);
            Console.Write("Для изменения параметра, нажмите Enter");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos < 0) { pos = 0; }
                    if (pos > 8) { pos = 8; }

                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos < 0) { pos = 0; }
                    if (pos > 8) { pos = 8; }

                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if(pos == 0)
                    {
                        Console.SetCursorPosition(7, 0);
                        Console.Write("            ");
                        Console.SetCursorPosition(8, 0);
                        string _i = Console.ReadLine();
                        users[_pos].ID = _i;
                    }
                    else if(pos == 1)
                    {
                        Console.SetCursorPosition(8, 1);
                        Console.Write("           ");
                        Console.SetCursorPosition(9, 1);
                        string _i = Console.ReadLine();
                        users[_pos].Name = _i;
                    }
                    else if (pos == 2)
                    {
                        Console.SetCursorPosition(12, 2);
                        Console.Write("           ");
                        Console.SetCursorPosition(13, 2);
                        string _i = Console.ReadLine();
                        users[_pos].LastName = _i;
                    }
                    else if (pos == 3)
                    {
                        Console.SetCursorPosition(13, 3);
                        Console.Write("           ");
                        Console.SetCursorPosition(14, 3);
                        string _i = Console.ReadLine();
                        users[_pos].FatherName = _i;
                    }
                    else if (pos == 4)
                    {
                        Console.SetCursorPosition(18, 4);
                        Console.Write("               ");
                        Console.SetCursorPosition(19, 4);
                        string _i = Console.ReadLine();
                        users[_pos].BirthDate = _i;
                    }
                    else if (pos == 5)
                    {
                        Console.SetCursorPosition(28, 5);
                        Console.Write("               ");
                        Console.SetCursorPosition(29, 5);
                        string _i = Console.ReadLine();
                        users[_pos].PassportID = _i;
                    }
                    else if (pos == 6)
                    {
                        Console.SetCursorPosition(14, 6);
                        Console.Write("           ");
                        Console.SetCursorPosition(15, 6);
                        string _i = Console.ReadLine();
                        users[_pos].job_title = _i;
                    }
                    else if (pos == 7)
                    {
                        Console.SetCursorPosition(13, 7);
                        Console.Write("           ");
                        Console.SetCursorPosition(14, 7);
                        string _i = Console.ReadLine();
                        users[_pos].Salary = _i;
                    }
                    else if (pos == 8)
                    {
                        Console.SetCursorPosition(8, 8);
                        Console.Write("           ");
                        Console.SetCursorPosition(9, 8);
                        string _i = Console.ReadLine();
                        users[_pos].IDNext = _i;
                    }
                }
                else if(key.Key == ConsoleKey.Escape) 
                { 
                    Console.Clear();
                    CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json", users);
                    Menu();
                    break;
                }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }
        }
        public void Read()
        {
            List<user2> users = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            foreach (user2 user in users)
            {
                Console.Write($"    {user.ID}  -  {user.Name}  -  {user.LastName}  -  {user.FatherName}  -   {user.job_title}\n");
            }
        }
        public void Find(string item)
        {
            List<user2> users = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            List<user2> sorted_users = new List<user2>();
            foreach (user2 user in users)
            {
                if(user.job_title.Equals(item) || user.Name.Equals(item) || user.LastName.Equals(item) || user.FatherName.Equals(item) || user.Salary.Equals(item) || user.ID.Equals(item) || user.BirthDate.Equals(item) || user.PassportID.Equals(item))
                {
                    sorted_users.Add(user);
                }

            }
            Console.Clear();
            int pos = 0;
            foreach (user2 user in sorted_users)
            {
                Console.Write($"    {user.ID}  -  {user.Name}  -  {user.LastName}  -  {user.FatherName}  -   {user.job_title}\n");
            }
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(80, 0);
            Console.Write("F1 - Изменить выбранную запись");
            Console.SetCursorPosition(80, 1);
            Console.Write("F2 - Создать новую запись");
            Console.SetCursorPosition(80, 2);
            Console.Write("F3 - Удалить запись");
            Console.SetCursorPosition(80, 3);
            Console.Write("Escape - Сбросить фильтр");
            Console.SetCursorPosition(80, 5);
            Console.Write("Вы зашли под логином: " + Name);
            Console.SetCursorPosition(3, sorted_users.Count + 3);
            Console.Write("ID");
            Console.SetCursorPosition(12, sorted_users.Count + 3);
            Console.Write("Имя");
            Console.SetCursorPosition(21, sorted_users.Count + 3);
            Console.Write("Фамилия");
            Console.SetCursorPosition(32, sorted_users.Count + 3);
            Console.Write("Отчество");
            Console.SetCursorPosition(47, sorted_users.Count + 3);
            Console.Write("Должность");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > sorted_users.Count - 1)
                    {
                        pos = sorted_users.Count - 1;
                    }
                    if (pos < 0)
                    {
                        pos = 0;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > sorted_users.Count - 1)
                    {
                        pos = sorted_users.Count - 1;
                    }
                    if (pos < 0)
                    {
                        pos = 0;
                    }
                }
                else if(key.Key == ConsoleKey.Escape) { Console.Clear(); Menu(); break; }
                else if(key.Key == ConsoleKey.F1) { _pos = users.IndexOf(sorted_users[pos]); Update(); break; }
                else if(key.Key == ConsoleKey.F2) { Create(); break;}
                else if(key.Key == ConsoleKey.F3) { _pos = users.IndexOf(sorted_users[pos]); Delete(); break; }

                Console.SetCursorPosition(0, pos);
                Console.Write("->");
            }

        }
        public void Delete()
        {
            List<user2> users = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            if (users[_pos].Name != Name)
            {
                users.Remove(users[_pos]);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Вы не можете удалить активную учетную запись!");
            }
            CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json", users);
            Console.Clear();
            Menu();
        }
        public void Menu()
        {
            List<user2> users = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            int pos = 0;
            Read();
            Console.SetCursorPosition(0, pos);
            Console.Write("->");
            Console.SetCursorPosition(80, 0);
            Console.Write("F1 - Изменить выбранную запись");
            Console.SetCursorPosition(80, 1);
            Console.Write("F2 - Создать новую запись");
            Console.SetCursorPosition(80, 2);
            Console.Write("F3 - Удалить запись");
            Console.SetCursorPosition(80, 3);
            Console.Write("F4 - Найти запись");
            Console.SetCursorPosition(80, 5);
            Console.Write("Вы зашли под логином: " + Name);
            Console.SetCursorPosition(3, users.Count + 3);
            Console.Write("ID");
            Console.SetCursorPosition(12, users.Count + 3);
            Console.Write("Имя");
            Console.SetCursorPosition(21, users.Count + 3);
            Console.Write("Фамилия");
            Console.SetCursorPosition(32, users.Count + 3);
            Console.Write("Отчество");
            Console.SetCursorPosition(47, users.Count + 3);
            Console.Write("Должность");
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos += 1;
                    if (pos > users.Count - 1)
                    {
                        pos = users.Count - 1;
                    }
                    if (pos < 0)
                    {
                        pos = 0;
                    }
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(0, pos);
                    Console.Write("   ");
                    pos -= 1;
                    if (pos > users.Count - 1)
                    {
                        pos = users.Count - 1;
                    }
                    if (pos < 0)
                    {
                        pos = 0;
                    }
                }
                else if(key.Key == ConsoleKey.F1)
                {
                    _pos = pos;
                    Update();
                    break;
                }
                else if(key.Key == ConsoleKey.F2)
                {
                    Create();
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
                    Console.Write("Введите ключ по которому будет произведен поиск: ");
                    string kluch = Console.ReadLine();
                    Find(kluch);
                    break;
                }
                else if (key.Key == ConsoleKey.Escape) { CringeConverter.CringeSerializer("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json", users); Console.Clear(); login lo = new login(); break; }
                Console.SetCursorPosition(0, pos);
                Console.Write("->");

            }


        }


    }

}
