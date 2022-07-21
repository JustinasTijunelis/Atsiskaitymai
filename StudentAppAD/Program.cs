
using StudentAppAD.Entity;
using StudentAppAD.StudentSystemBL;


/*
1. Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points 
    jei pridedamos paskaitos jau egzistuojančios duomenų bazėje).
2.Pridėti studentus / paskaitas į jau egzistuojantį departamentą.
3. Sukurti paskaitą ir ją priskirti prie departamento.
4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.
5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).
*/

public static class Program
{
    public static void Main()
    {
        var systemService = new SystemService();

        CreatDepartmentAndAssignStudentLecrute();
        //PrintStudent();
        //PrintDepartment();
        //CreateLecture();


      
        void CreatLectureAndAssignToDepartment()
        {
            Console.WriteLine("Iveskite paskaita");
            string lectureName = Console.ReadLine();
            systemService.CreateLecture(lectureName);
            Console.WriteLine("Kuriam departamentui priskirti paskaita");
            PrintDepartment();
            int departmentId = Convert.ToInt32(Console.ReadLine());
            
            systemService.AssignLectureToDepartment(lectureName, departmentId);
        }
        void CreatDepartmentAndAssignStudentLecrute()  // 1 Uzduoti  neprideda i departamenta studentu bei paskaitu, nulai gaunasi 
                                                       // tikriausiai i problema su konstruktoriumi ir negali uzsisetinti 
        {
            var departmentName = CreateDepartment();
            //Console.WriteLine("Pasirinkite Departamenta i kuri norite prideti Studentus ir Paskaitas");
            // PrintDepartment();
            //var departmentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pasirinkite pridedama Studenta");
            PrintStudent();
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pasirinkite pridedama Paskaita");
            PrintLecture();
            var lectureId = Convert.ToInt32(Console.ReadLine());
            systemService.AssignStudentAndLectureToDepartment(studentId, lectureId, departmentName);
        }
        void AddStudentAndLecturesToDepartment() //2 uzduoties puse darbo
        {
            var departmentId = CreateStuden();
            Console.WriteLine("Koks studento Id");
            PrintStudent();
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Koks Paskaitos Id");
            PrintLecture();
            var lectureId = Convert.ToInt32(Console.ReadLine());
            systemService.AssignStudentToDepartment(departmentId, studentId);
            systemService.AssignLectureToDepartment(departmentId, lectureId);
            
        }
        void CreatLectureAndAssigneToDepartemnt()  //3 uzduotis
        {
           var lectureName=  CreateLecture();
            Console.WriteLine("Pasirinkite departamenta");
            PrintDepartment();
            var departmentId = Convert.ToInt32(Console.ReadLine());
            systemService.AssigneLectureToDepartment(lectureName, departmentId);
             
        }
        #region Create_Lecture_Department_Student
        string CreateDepartment()
        {
            Console.WriteLine("Iveskite departamento pavadinima");
            string name = Console.ReadLine();
            systemService.CreateDepartment(name);
            return name;
        }
        int CreateStuden()
        {
            var department = new Department();

            Console.WriteLine("Iveskite Studento varda - Vardenis");
            string firstName = Console.ReadLine();

            Console.WriteLine("Iveskite Studento pavarde - Pavardenis");
            string lastName = Console.ReadLine();

            Console.WriteLine("Iveskite Studento lyti - V/M");
            Char gender = Convert.ToChar(Console.ReadLine().ToUpper());

            Console.WriteLine("Iveskite Studento gimimo data - 1983-01-01");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Kuriam Departamentui priskirti");
            PrintDepartment();
            //string department = Console.ReadLine();
            int departamentId = Convert.ToInt32(Console.ReadLine());

            systemService.CreateStudent(firstName, lastName, gender, birthDate, department);
            return departamentId;
        }
        string CreateLecture()
        {
            Console.WriteLine("Iveskite paskaita");
            string name = Console.ReadLine();
            systemService.CreateLecture(name);
            return name;
        }
        #endregion
        #region Print_To_ Console

        void PrintLecture()
        {
            Console.WriteLine("Paskaitos");
            var lectures = systemService.GetAllLecture();
            foreach (var lecture in lectures) { Console.WriteLine($"[{lecture.Id}] {lecture.Name}"); }
           
        }
        void PrintStudent()
        {
            Console.WriteLine("Studentia");
            var students = systemService.GetAllStudents();
            foreach (var student in students) { Console.WriteLine($"[{student.Id}] " +
                $"{student.FirstName} {student.LastName} {student.Gender} {student.BirthDate}"); }
        }
        void PrintDepartment()
        {
            Console.WriteLine("Departamentai");
            var departments = systemService.GetAllDepartment();
            foreach (var department in departments) { Console.WriteLine($"[{department.Id}] {department.Name}"); }
        }
#endregion 
    }
}