using Microsoft.EntityFrameworkCore;
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
        public void UpDateLecture(Lecture lecture) //Attach tai prijungti dar viena SITA Oblekta  Entity Framworko Change trackerio
        {
            _dbContext.Attach(lecture);
        }
        public void UpDateDepatment(Department department) //Attach tai prijungti dar viena SITA Oblekta  Entity Framworko Change trackerio
        {
            _dbContext.Attach(department);
        }

        //Student
        public Student GetStudentById(int studentId) //paselektinti pagal ID
        {
            return _dbContext.Students.FirstOrDefault(d => d.Id == studentId);
        }
        public List<Student> GetStudentByDepatmentId(int departmentId) //paselektinti pagal ID
        {
            return _dbContext.Students.Include(d=> d.Department).Include(d=> d.Lecture).Where(d => d.Id == departmentId).ToList();
        }
        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            return _dbContext.Students.Where(d=> d.Department.Id==departmentId).ToList();
        }
        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }


        //Lecture
        public Lecture GetLectureByName(string lecture)
        {
            return _dbContext.Lectures.Include(l=> l.Students).FirstOrDefault(l=> l.Name.ToUpper()==lecture.ToUpper());
        }
        public List<Lecture> GetLecturesByStudentId(int studentId)
        {
            return _dbContext.Lectures.Where(l=> l.Students.Any(s=> s.Id==studentId)).ToList();
        }
        public Lecture GetLecturesById(int lectureId)
        {
            return _dbContext.Lectures.Include(l=> l.Departments).FirstOrDefault(l=> l.Id==lectureId);
        }
        public List<Lecture> GetLectureByDepartment(Department department)
        {
            return _dbContext.Lectures.Include(l=> l.Departments).Where(l=> l.Id==department.Id).ToList();
        }
        public List<Lecture> GetAllLecture()
        {
            return _dbContext.Lectures.ToList();
        }


        //Department
        public Department GetDepartmentById(int departmentId)
        {
            return _dbContext.Departments.Include(d=> d.Lectures).FirstOrDefault(d=> d.Id==departmentId);
        }
        public Department GetDepartmentByName(string department)
        {
            return _dbContext.Departments.Include(d=> d.Lectures).FirstOrDefault(d=> d.Name.ToUpper() == department.ToUpper());
        }

        public void AddUpdateDepartment(Department department)
        {
            if (_dbContext.Departments.Any(i => i.Name.ToUpper() == department.Name.ToUpper()))
            {
                _dbContext.Departments.Update(department);
            }
            else
            {
                _dbContext.Departments.Add(department);
            }
        }            //public Lecture GetLecture(int id) // Kaip pasiimti Movie Is Movie + Genre kenteles pagal ID  
            //{
            //    return _dbContext.Lectures.Include(m => m.Department).FirstOrDefault(m => m.Id == id);
            //}
           public Department GetDepartment(string department) //Metodas kad grazintu zanra, paduodame zanro pavadinima
        {
            return _dbContext.Departments.FirstOrDefault(g => g.Name.ToUpper() == department.ToUpper());
            //graziname zanra is SQL pagal pavadinima  
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
