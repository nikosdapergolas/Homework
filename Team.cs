using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Team
    {
        string teamName;
        public string TeamName
        {
            get { return teamName; }
            set { teamName = value; }
        }

        public List<string> listOfStudents = new List<string>();
    }
}   