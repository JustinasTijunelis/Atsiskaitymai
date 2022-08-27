
using StudentAppAD.Entity;
using StudentAppAD.StudentSystemBL;


/* Uzduotis
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

        MeniuStart();

        void CreatDepartmentAndAssignStudentLecrute()  // 1 Uzduoti  
        {
            var departmentId = CreateDepartment();
            Console.WriteLine("Pasirinkite pridedama Studenta");
            PrintStudent();
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pasirinkite pridedama Paskaita");
            PrintLecture();
            var lectureId = Convert.ToInt32(Console.ReadLine());
            systemService.AssignStudentAndLectureToDepartment(studentId, lectureId, departmentId);
            MeniuStart();
        }
        void AddSudentAndLectureToDepartment() // 2 uzduotis
        {
            Console.WriteLine("Pasirinkite studenta");
            PrintStudent();
            var studentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Pasirinkite departamenta");
            PrintDepartment();
            var departmanetId = Convert.ToInt32(Console.ReadLine());
            var lectures = systemService.GetAllLecturesByDepartmentId(departmanetId);
            foreach (var lecture in lectures) { Console.WriteLine($"[{lecture.Id}] {lecture.Name}"); }
            Console.WriteLine("Pasirinkite paskaita");
            var lectureId = Convert.ToInt32(Console.ReadLine());
            systemService.AssignStudentAndLectureToDepartment(studentId, lectureId, departmanetId);
            MeniuStart();
        }
        void CreatLectureAndAssigneToDepartemnt()  //3 uzduotis
        {
            var lectureId = CreateLecture();
            Console.WriteLine("Pasirinkite departamenta");
            PrintDepartment();
            var departmentId = Convert.ToInt32(Console.ReadLine());
            systemService.AssignLectureToDepartment(departmentId, lectureId);
            MeniuStart();
        }
        void CreateAddStudentAndLecturesToDepartment() //4 uzduotis
        {
            var studentId = CreateStudent();
            Console.WriteLine("Pasirinkite pridedama paskaita");
            PrintLecture();
            var lectureId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pasirinkite i kuri departamenta norite prideti");
            var departmentId = Convert.ToInt32(Console.ReadLine());
           // systemService.AssignStudentAndLectureToDepartment(studentId, lectureId, departmentId);
            systemService.AssignStudentToDepartment(departmentId, studentId);
            systemService.AssignLectureToDepartment(departmentId, lectureId);
            MeniuStart();
        }
        void MoveStudentToDepartment() //5 uzduoti
        {
            Console.WriteLine("Koks studento Id");
            PrintStudent();
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Koks Paskaitos Id");
            PrintLecture();
            var lectureId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pasirinkite i kuri departamenta norite prideti");
            PrintDepartment();
            var departmentId = Convert.ToInt32(Console.ReadLine());
            systemService.TrasferStudentToDepartmentWithLecture(studentId, departmentId);
            MeniuStart();
        }
        void ShowStudentsOfDepartment() //6 Uzduotis
        {
            Console.WriteLine("Pasirinkite departamenta");
            PrintDepartment();
            var departmanetId=Convert.ToInt32(Console.ReadLine());
            var students = systemService.GetAllStudentsByDepartmentId(departmanetId);
            foreach (var student in students){Console.WriteLine($"[{student.Id}] " +
            $"{student.FirstName} {student.LastName} {student.Gender} {student.BirthDate}");}
            Console.ReadKey();
            MeniuStart();
        }
        void ShowLecturesOfDepartment() //7 Uzduotis
        {
            Console.WriteLine("Pasirinkite departamenta");
            PrintDepartment();
            var departmanetId = Convert.ToInt32(Console.ReadLine());
            var lectures = systemService.GetAllLecturesByDepartmentId(departmanetId);
            foreach (var lecture in lectures) {Console.WriteLine($"[{lecture.Id}] {lecture.Name}");}
            Console.ReadKey();
            MeniuStart();
        }
        void ShowLecturesOfStudent() //8 Uzduotis
        {
            Console.WriteLine("Pasirinkite Studenta");
            PrintStudent();
            var studentId = Convert.ToInt32(Console.ReadLine());
            var lectures = systemService.GetAllLecturesByStudentId(studentId);
            foreach (var lecture in lectures) { Console.WriteLine($"[{lecture.Id}] {lecture.Name}"); }
            Console.ReadKey();
            MeniuStart();
        }
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
        #region Create_Lecture_Department_Student
        int CreateDepartment()
        {
            Console.WriteLine("Iveskite departamento pavadinima");
            string name = Console.ReadLine();
            var departmentId = systemService.CreateDepartment(name);
            return departmentId;
        }
        int CreateStudent()
        {
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
            var departmentId = Convert.ToInt32(Console.ReadLine());
            Department department = systemService.GetDepartmentById(departmentId);
            var studentId = systemService.CreateStudent(firstName, lastName, gender, birthDate, department);
            return studentId; 
        }
        int CreateLecture()
        {
            Console.WriteLine("Iveskite paskaita");
            string name = Console.ReadLine();
            return systemService.CreateLecture(name); 
        }
        #endregion
        #region Print_To_ Console

        void PrintLecture()
        {
            Console.WriteLine("Paskaitos");
            var lectures = systemService.GetAllLecture();
            foreach (var lecture in lectures) { Console.WriteLine($"[{lecture.Id}] {lecture.Name}"); }
        }
        //void PrintLectureByDepartment()
        //{
        //    Console.WriteLine("Pasirinkite Departamenta");
        //    PrintDepartment();
        //    var department = Console.ReadLine();
        //    Console.WriteLine("Departamento paskaitos");
        //    var departmentLectures = systemService.GetAllLecturesByDepartmentId(department);
        //    foreach (var departmentLecture in departmentLectures) { Console.WriteLine(departmentLecture.Id) {lecture.Name}; } 
        //}
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
        void MeniuStart()
        {
            Console.Clear();
            Console.WriteLine("Pasirinkite is meniu");
            Console.WriteLine
                ("[1] Sukurti departamentą ir į jį pridėti studentus, paskaitas \n" +
                "[2] Pridėti studentus/paskaitas į jau egzistuojantį departamentą \n" +
                "[3] Sukurti paskaitą ir ją priskirti prie departamento \n" +
                "[4] Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas \n" +
                "[5] Perkelti studentą į kitą departamentą \n" +
                "....................................................... \n" +
                "[6] Atvaizduoti visus departamento studentus \n" +
                "[7] Atvaizduoti visas departamento paskaitas \n" +
                "[8] Atvaizduoti visas paskaitas pagal studentą");
            int meniuPasirinkimas = int.Parse(Console.ReadLine());
            switch (meniuPasirinkimas)
            {
                case 1:
                    CreatDepartmentAndAssignStudentLecrute();
                    break;
                case 2:
                    AddSudentAndLectureToDepartment();
                    break;
                case 3:
                    CreatLectureAndAssigneToDepartemnt();
                    break;
                case 4:
                    CreateAddStudentAndLecturesToDepartment();
                    break;
                case 5:
                    MoveStudentToDepartment();
                    break;
                case 6:
                    ShowStudentsOfDepartment();
                    break;
                case 7:
                    ShowLecturesOfDepartment();
                    break;
                case 8:
                    ShowLecturesOfStudent();
                    break;
                  
            }
            
        }
    }
}