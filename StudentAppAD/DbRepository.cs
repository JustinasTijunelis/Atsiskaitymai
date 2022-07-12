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
        public Student GetStudentById(int id) //paselektinti pagal ID
        {
            return _dbContext.Students.FirstOrDefault(d => d.Id == id);
        }
        public Student GetDepatmentById(int id) //paselektinti pagal ID
        {
            return _dbContext.Departments.FirstOrDefault(d => d.Id == id);
        }

        public void AddUpdateDepartment(Department department)
        {
            if (_dbContext.Departments.Any(i => i.Name == department.Name))
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
