using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    class Employee
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }

        public Employee()
        {
            Firstname = "";
            Lastname = "";
            Email = "";
            Gender = "";
            Salary = 0;

        }
        public Employee(string firstname, string lastname, string email, string gender, double salary)
        {
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Gender = gender;
            Salary = salary;


        }
        public override string ToString()
        {
            string employeeAsString = $"{Firstname} {Lastname} {Gender.ToUpper()[0]}has an email of {Email} and has a Salary of {Salary.ToString("C2")}";
            return employeeAsString;
        }





    }
}
