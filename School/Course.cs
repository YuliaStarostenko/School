using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        private string name;
        private List<Student> students;

        public Course()
        {
            students = new List<Student>();
        }

        public string Name { get; set; }
        public List<Student> Students { get { return students; } }


        public void addStudentToTheCourse(Student newStudent)
        {
            if (students.Count < 2)
            {
                if (!students.Contains(newStudent))
                {
                    students.Add(newStudent);
                }
            }
            else
            {
                throw new Exception("The course is fully booked");

            }

        }

        public void deleteStudentFromACourse(Student student)
        {
            if (!students.Contains(student))
            {
                throw new Exception("There is no such a student in the cource");

            }
            else
            {
                students.Remove(student);
            }
        }
    }
}
