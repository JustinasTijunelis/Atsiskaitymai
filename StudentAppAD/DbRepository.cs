using StudentAppAD.Entity;
using StudentAppAD.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAppAD
{
    public class DbREpository
    {
        private readonly StudentDBContext _dbContext;
        public DbREpository()
        {
            _dbContext = new StudentDBContext();
        }
        public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
        }
        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
        }
        public void AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
