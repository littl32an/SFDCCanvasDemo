using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace C_Sharp_Canvas_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();

            var g = from a in db.Table_2s select a;
        }

        static void showEmployees()
        {
            List<Employee> employees = new List<Employee>();
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Title: {1}", Name, Title);
        }
    }
}
