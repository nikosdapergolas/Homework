using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Person
    {
        string name { get; set; }
        string surname { get; set; }
        string email { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}