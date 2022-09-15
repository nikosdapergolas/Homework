using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Homework
    {
        string nameofHomework;
        string deadline;
        public string NameofHomework
        {
            get { return nameofHomework; }
            set { nameofHomework = value; }
        }
        public string Deadline
        {
            get { return deadline; }
            set { deadline = value; }
        }

        public Homework(string nameofHomework, string deadline)
        {
            this.NameofHomework = nameofHomework;
            this.Deadline = deadline;
        }
    }
    
}