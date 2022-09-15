using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Admin : Person
    {
        int adminID;
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        void createProfessor(string name, string surname, string email, int id)
        {
            Professor professor = new Professor();
            professor.Name = name;
            professor.Surname = surname;
            professor.Email = email;
            professor.ID = id;
        }
    }
}