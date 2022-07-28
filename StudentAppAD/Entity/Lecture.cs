

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
            Name = name;
            Departments = new List<Department>();
            Students = new List<Student>();
        }
    }
}
