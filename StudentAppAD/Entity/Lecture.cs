using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppAD.Entity
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public List<Student> Students { get; set; }

        public Lecture() { }
        public Lecture(string name)
        {
            //Id = Id;
            Name = name;
            Departments = new List<Department>();
            Students = new List<Student>();
        }
    }
}
