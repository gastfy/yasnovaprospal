using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class user2
    {
        public string Name;
        public string LastName;
        public string FatherName;
        public string ID;
        public string BirthDate;
        public string IDNext;
        public string PassportID;
        public string Salary;
        public string job_title;

        public user2(string _name, string _lastname, string fathername ,string _id, string _bd, string _idnext, string _passportID, string _salary, string _job_title)
        {
            Name = _name;
            LastName = _lastname;
            FatherName = fathername;
            ID = _id;
            BirthDate = _bd;
            IDNext = _idnext;
            PassportID = _passportID;
            Salary = _salary;
            job_title = _job_title;
        }
    }
}
