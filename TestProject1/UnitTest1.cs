using NUnit.Framework;
using StudentAppAD;
using StudentAppAD.Entity;
using StudentAppAD.StudentSystemBL;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void CreateLectureTest()
        {
            
        }

        [Test]
        public void Test1()
        {
            var dbContext = new StudentDBContext();
            var name = "Pavadinimas";

            //ACT
           
            var department = new Department(name);
            dbContext.Departments.Add(department);
            dbContext.SaveChanges();
          


            string income = name;
            string actualy = department.Name;

            //Assert
            Assert.AreEqual(actualy, income);
        }
    }
}