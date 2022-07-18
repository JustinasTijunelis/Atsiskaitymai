
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

        AddStudentAndLecturesToDepartment();
        //CreateLecture();


        void CreateDepartment()
        {
            Console.WriteLine("Iveskite departamento pavadinima");
            string name = Console.ReadLine();
            systemService.CreateDepartment(name);
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
            //string department = Console.ReadLine();
            int departamentId = Convert.ToInt32(Console.ReadLine());

            systemService.CreateStudent(firstName, lastName, gender, birthDate, departamentId, department);
            return departamentId;

        }
        void CreateLecture()
        {
            Console.WriteLine("Iveskite paskaita");
            string name = Console.ReadLine();
            systemService.CreateLecture(name);
        }
        void CreatLectureAndAssignToDepartment()
        {
            Console.WriteLine("Iveskite paskaita");
            string lectureName = Console.ReadLine();
            systemService.CreateLecture(lectureName);
            Console.WriteLine("Kuriam departamentui priskirti paskaita");
            int departmentId = Convert.ToInt32(Console.ReadLine());
            
            systemService.AssignLectureToDepartment(lectureName, departmentId);
        }
        void CreatDepartmentAndAssignStudentLecrute(string name)
        {

        }
        void AddStudentAndLecturesToDepartment() //2 uzduoties puse darbo
        {
            
            var departmentId = CreateStuden();
            Console.WriteLine("Koks studento Id");
            var studentId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Koks Paskaitos Id");
            var lectureId = Convert.ToInt32(Console.ReadLine());
            systemService.AssignStudentToDepartment(departmentId, studentId);
            systemService.AssignLectureToDepartment(departmentId, lectureId);
            
        }
    }
}