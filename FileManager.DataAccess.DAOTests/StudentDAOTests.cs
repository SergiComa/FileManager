using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.DAO;
using FileManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO.Tests
{
    [TestClass()]
    public class StudentDAOTests
    {
        IStudentDAO iStudent = new StudentDAO();
        Student student = new Student();
        Student readStudent = new Student();
        Utils utils = new Utils();
        String readLineFromFile;
        [DataRow("1","Sergio","Gimenez", "19/09/1996", "1,Sergio,Gimenez,19/09/1996")]
        [TestMethod()]
        public void AddTest(String id, String name, String surname, String DateOfBirth, String testEntry)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;
            readStudent = iStudent.Add(student);
            readLineFromFile = utils.ReadFromFile();
            Assert.AreEqual(readLineFromFile, testEntry);
        }
    }
}