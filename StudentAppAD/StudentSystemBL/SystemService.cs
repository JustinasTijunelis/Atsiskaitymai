using StudentAppAD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppAD.StudentSystemBL
{
    public class SystemService
    {
        private readonly DbREpository _repository;

        public SystemService()
        {
            _repository = new DbREpository();
        }
        public void CreateDepartment(string name)
        {
            var department = new Department(name);
            _repository.AddDepartment(department);
            _repository.SaveChanges();
        }
        public void CreateStudent(string firstName, string lastName, char gender, DateTime birthDate)
        {
            var student = new Student(firstName, lastName, gender, birthDate);
            _repository.AddStudent(student);
            _repository.SaveChanges();
        }
        public void CreateLecture(string name)
        {
            var lecture = new Lecture(name);
            _repository.AddLecture(lecture);
            _repository.SaveChanges();
        }
    }
}
