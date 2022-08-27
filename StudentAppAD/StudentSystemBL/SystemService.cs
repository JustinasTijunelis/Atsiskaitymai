using StudentAppAD.Entity;

namespace StudentAppAD.StudentSystemBL
{
    public class SystemService
    {
        private readonly DbREpository _repository;

        public SystemService()
        {
            _repository = new DbREpository();
        }
        public int CreateDepartment(string name)
        {
            var department = new Department(name);
            _repository.AddDepartment(department);
            _repository.SaveChanges();
            return department.Id;
        }
        public int CreateLecture(string name)
        {
            var lecture = new Lecture(name);
            _repository.AddLecture(lecture);
            _repository.SaveChanges();
            return lecture.Id;
        }
        public int CreateStudent(string firstName, string lastName, char gender, DateTime birthDate, Department department)
        {
            _repository.GetDepartmentById(department.Id);
            var student = new Student(firstName, lastName, gender, birthDate,department);
            _repository.AddStudent(student);
            //_repository.UpDateDepatment(department);
            _repository.SaveChanges();
            return student.Id;
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
        public void AssignStudentAndLectureToDepartment(int studentId, int lectureId,int departmentId)
        {
            var student = _repository.GetStudentById(studentId);
            var lecture = _repository.GetLecturesById(lectureId);
            var department = _repository.GetDepartmentById(departmentId);

            department.Students.Add(student);
            department.Lectures.Add(lecture);
            student.Lecture.Add(lecture);
            _repository.UpDateDepatment(department);
            _repository.UpDateStudent(student);
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
        public Department GetDepartmentById(int departmentId)
        {
            return _repository.GetDepartmentById(departmentId);
        }
        public List<Student> GetAllStudentsByDepartmentId(int departmentId)
        {
            return _repository.GetStudentsByDepartment(departmentId).ToList();
        }
        public List<Lecture> GetAllLecturesByDepartmentId(int departmentId)
        {
            return _repository.GetLectureByDepartmentId(departmentId).ToList();
        }
        public List<Lecture> GetAllLecturesByStudentId(int studentId)
        {
            return _repository.GetLecturesByStudentId(studentId).ToList();
        }
        #region Not using
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
        #endregion
    }
}
