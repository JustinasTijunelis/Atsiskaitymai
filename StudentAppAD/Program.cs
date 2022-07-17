
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

        //CreateStuden();



        void CreateDepartment()
        {
            Console.WriteLine("Iveskite departamento pavadinima");
            string name = Console.ReadLine();
            systemService.CreateDepartment(name);
        }
        //void CreateStuden()
        //{
        //    Console.WriteLine("Iveskite Studento varda - Vardenis");
        //    string firstName = Console.ReadLine();

        //    Console.WriteLine("Iveskite Studento pavarde - Pavardenis");
        //    string lastName = Console.ReadLine();

        //    Console.WriteLine("Iveskite Studento lyti - V/M");
        //    Char gender = Convert.ToChar(Console.ReadLine().ToUpper());

        //    Console.WriteLine("Iveskite Studento gimimo data - 1983-01-01");
        //    DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

        //    Console.WriteLine("Kuriam Departamentui priskirti");
        //    //string departament = Console.ReadLine();
        //    int departamentId = Convert.ToInt32(Console.ReadLine());

        //    systemService.CreateStudent(firstName, lastName, gender, birthDate, departamentId);
        //}
        void CreateLecture()
        {
            Console.WriteLine("Iveskite paskaita");
            string name = Console.ReadLine();
            systemService.CreateLecture(name);
        }
    }
}