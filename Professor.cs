using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Professor : Person
    {
        int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        void setHomework(string nameOfHomework, string deadline)
        {
            Homework homework = new Homework(nameOfHomework, deadline);
        }

        void setpoints(int pointsOfHomework)
        {
            Points points = new Points();
            points.PointsOfHomework = pointsOfHomework;
        }
    }
}