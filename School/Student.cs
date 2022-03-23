using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private int id = new Random().Next(10000, 99999);

        private string name;

        public int Id
        {
            get { return id; }

        }



        public string Name
        {
            get { return name; }
            set
            {
                if (value == null)
                {

                    throw new NullReferenceException("Name should not be empty!");
                }

                value = value.Trim();


                if (value.Length == 0)
                {
                    throw new ArgumentException("Name should not be empty!");
                }


                name = value;

            }
        }

    }
}
