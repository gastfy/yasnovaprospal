using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class login
    {
        public string Password;
        public string Username;
        private string NAMEUSED;
        public login()
        {
            LoginPage();
        }
        private void LoginPage()
        {
            Console.Write("Введите логин: ");
            string user_name = Console.ReadLine();
            Username = user_name;
            Console.Write("Введите пароль: ");
            ConsoleKeyInfo a = Console.ReadKey(true);
            if (a.Key == ConsoleKey.Escape) { Console.Clear(); LoginPage(); }
            else
            {
                string pass = "" + a.KeyChar;
                Console.SetCursorPosition(17 + pass.Length - 2, 1);
                Console.Write('*');
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Password = pass;
                        Check();
                        break;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        LoginPage();
                        break;
                    }
                    else
                    {
                        pass += key.KeyChar;
                        Console.SetCursorPosition(17 + pass.Length - 2, 1);
                        Console.Write('*');
                    }
                }
            }
        }
        private void Check()
        {
            string text = File.ReadAllText("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users.json");
            List<user> users = JsonConvert.DeserializeObject<List<user>>(text);
            List<user2> users2 = CringeConverter.CringeDeserializer<List<user2>>("C:\\Users\\gastf\\source\\repos\\ConsoleApp15\\ConsoleApp15\\users2.json");
            bool Fool = true;
            foreach (user item in users)
            {
                if(item.Login == Username && item.Password == Password)
                {
                    Console.Clear();
                    NAMEUSED = item.Login;
                    foreach(user2 user in users2)
                    {
                        if(item.ID == user.IDNext)
                        {
                            NAMEUSED = user.Name;
                        }

                    }
                    if(item.Role == "admin")
                    {
                        admin admin = new admin(NAMEUSED);
                    }
                    else if(item.Role == "accountant")
                    {
                        accountant accountant = new accountant(NAMEUSED);                    
                    }
                    else if(item.Role == "storage_manager")
                    {
                        storageManager storageManager = new storageManager(NAMEUSED);
                    }
                    else if(item.Role == "manager")
                    {
                        manager manager = new manager(NAMEUSED);
                    }
                    else if(item.Role == "cassier")
                    {
                        cassier cassier = new cassier(NAMEUSED);
                    }
                    Fool = false;
                    break;
                }
            }
            if (Fool)
            {
                Console.WriteLine("\nВы ввели несущетсвуещего пользователя, хотите попробовать еще раз? (y/n)");
                string answ = Console.ReadLine();
                if (answ == "y")
                {
                    Console.Clear();
                    LoginPage();
                }
                else { Console.WriteLine("Хорошо, досвидания!"); }
            }

        }

    }
}
