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
        //public void CreateStudent(string firstName, string lastName, char gender, DateTime birthDate, int departmentId)
        //{
        //    var student = new Student(firstName, lastName, gender, birthDate);
        //    var departmentId = new Department(name);
           
        //    _repository.AddUpdateDepartment(departmentId);
        //    _repository.AddStudent(student);
        //    _repository.SaveChanges();
        //}
        public void CreateLecture(string name)
        {
            var lecture = new Lecture(name);
            _repository.AddLecture(lecture);
            _repository.SaveChanges();
        }


        //public void AssignDepartmentToLecture(int lectureId, string department)
        //{
        //    var lecture = _repository.GetLecture(lectureId);
        //    if (lecture.Departments.Any(g => g.Name.Equals(department, StringComparison.InvariantCultureIgnoreCase))) ;
        //    // jei movie Genre turi kurio pavadinimas "g=> g.Name.ToUpper()"
        //    // yra toks "genre.ToUpper()" (tai ka mes padaveme
        //    {
        //        return;
        //        //jei neturi tai turaukiam
        //    }
        //    var departmentfromDb = _repository.GetDepartment(department);
        //    lecture.Departments.Add(departmentfromDb ?? new Department(department));
        //    // (genrefromDb ?? new Genre(genre))
        //    // naudosime "genrefromDb"  ?? ( ?? reiskia jei tokio nera) naudosime  "new Genre(genre)"

        //    _repository.UpDateLecture(lecture); //issikvieciame ka norime Attachinti per Frame work Change trackerio
        //    _repository.SaveChanges();

        //}
    }
}
