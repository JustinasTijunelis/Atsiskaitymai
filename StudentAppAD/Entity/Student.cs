

namespace StudentAppAD.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Lecture> Lecture { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public Student() { }
        public Student(string firstName, string lastName, char gender, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            Lecture = new List<Lecture>();
        }
        public Student(string firstName, string lastName, char gender, DateTime birthDate, Department department)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            Lecture = new List<Lecture>();
            Department = department;
        }
        public Student( string firstName, string lastName, char gender, DateTime birthDate, Department department,
            List<Lecture> lecture)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            Lecture = lecture;
            Department = department;
        }
    }
}
