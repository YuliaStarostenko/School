using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {

        private List<Course> courses;

        public School()
        {
            courses = new List<Course>();
        }
        public List<Course> Courses { get { return courses; } }


    }
}
