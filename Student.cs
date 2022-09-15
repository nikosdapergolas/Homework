using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Student : Person
    {
        int a_m;
        public int A_M
        {
            get { return a_m; }
            set { a_m = value; }
        }
        void createTeam(string teamName)
        {
            Team team = new Team();
            team.TeamName = teamName;
            // Μενει σε αυτο το σημείο Να βαλω ως παράμετρο τον αριθμό
            // των ατόμων της ομάδας, και ανάλογα με αυτόν τον αριθμό, να τρέχει ένα 
            // for loop που θα ζητάει τα ονόματα και τα ΑΜ για να τα προσθέτει
        }
    }
}