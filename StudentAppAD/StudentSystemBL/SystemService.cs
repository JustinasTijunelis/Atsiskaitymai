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
        public void CreateLecture(string name)
        {
            var lecture = new Lecture(name);
            _repository.AddLecture(lecture);
            _repository.SaveChanges();
        }
        public void CreateStudent(string firstName, string lastName, char gender, DateTime birthDate, Department department)
        {
            
            _repository.GetDepartmentById(department.Id);
            var student = new Student(firstName, lastName, gender, birthDate);
            _repository.AddStudent(student);
            _repository.SaveChanges();
        }
        public void TrasferStudentToDepartmentWithLecture(int studentId, int departmentId)
        {
            var student = _repository.GetStudentById(studentId);
            var department = _repository.GetDepartmentById(departmentId);
            var lectures = _repository.GetLectureByDepartmentId(departmentId); 

            student.Lecture.Clear();
            student.Department = department;
            student.Lecture = lectures;
            _repository.UpDateStudent(student);
            _repository.SaveChanges();
        }

        public void AssignStudentAndLectureToDepartment(int studentId, int lectureId, string departmentName)
        {
            var student = _repository.GetStudentById(studentId);
            var lecture = _repository.GetLecturesById(lectureId);
            var department = _repository.GetDepartmentByName(departmentName);

            department.Students.Add(student);
            department.Lectures.Add(lecture);
            _repository.UpDateDepatment(department);

            _repository.SaveChanges();
        }
        public void AssigneLectureToDepartment(string lectureName, int departmentId)
        {
            var lecture = _repository.GetLectureByName(lectureName);
            var department = _repository.GetDepartmentById(departmentId);

            department.Lectures.Add(lecture);
            _repository.UpDateDepatment(department);
            _repository.SaveChanges();
        }
         public List<Lecture> GetAllLecture()
        {
            return _repository.GetAllLecture();
        }
        public List<Student> GetAllStudents()
        {
            return _repository.GetAllStudents();
        }
        public List<Department> GetAllDepartment()
        {
            return _repository.GetAllDepartment();
        }
        //public void CreateStudentToDepartmentWithLecture(string firstName, string lastName, char gender, DateTime birthDate, Department department)
        //{
        //    var departmentLecture = _repository.GetLectureByDepartment(department);
        //    var student = new Student(firstName, lastName, gender, birthDate);//(department,departmentLecture)
        //    _repository.AddStudent(student);
        //    _repository.SaveChanges();
        //}

        //public void CreateStudentToDepartment(string firstName, string lastName, char gender, DateTime birthDate, Department department)
        //{
        //    var student = new Student(firstName, lastName, gender, birthDate, department); //Sukurti Konstruktoriu su Department
        //    _repository.AddStudent(student);
        //    _repository.SaveChanges();
        //}


        //public void CreateStudent(string firstName, string lastName, char gender, DateTime birthDate, int departmentId)
        //{
        //    var student = new Student(firstName, lastName, gender, birthDate);
        //    var departmentId = new Department(name);

        //    _repository.AddUpdateDepartment(departmentId);
        //    _repository.AddStudent(student);
        //    _repository.SaveChanges();
        //}

        public void AssignStudentToDepartment(int departmentId, int studentId)
        {
            var department = _repository.GetDepartmentById(departmentId);
            var student = _repository.GetStudentById(studentId);
            department.Students.Add(student);
            _repository.UpDateDepatment(department);
            _repository.SaveChanges();
        }

        public void AssignLectureToDepartment(int departmentId, int lectureId)
        {

            var department = _repository.GetDepartmentById(departmentId);
            var lecture = _repository.GetLecturesById(lectureId);
            department.Lectures.Add(lecture);
            _repository.UpDateDepatment(department);
            _repository.SaveChanges();
        }


        public void AssignLectureToDepartment(string lecureName, int departmentId)
        {
            var lecture = _repository.GetLectureByName(lecureName);
            var department = _repository.GetDepartmentById(departmentId);
            department.Lectures.Add(lecture);
            _repository.UpDateDepatment(department);
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
