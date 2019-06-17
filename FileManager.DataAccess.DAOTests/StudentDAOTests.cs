using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager.DataAccess.DAO;
using FileManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FileManager.DataAccess.DAO.Tests
{
    [TestClass()]
    public class StudentDAOTests
    {
        IStudentDAO iStudent = new StudentDAO();
        Student student = new Student();
        Student readStudent = new Student();
        Utils utils = new Utils();
        String sAttr = ConfigurationManager.AppSettings.Get("XmlPath");
        String readLineFromFile;

        [DataRow("1","Sergio","Gimenez", "19/09/1996", "1,Sergio,Gimenez,19/09/1996")]
        [TestMethod()]
        public void TextTest(String id, String name, String surname, String DateOfBirth, String testEntry)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;

            readStudent = iStudent.Add(student, 'T');
            readLineFromFile = utils.ReadFromTxt();
            Assert.AreEqual(readLineFromFile, testEntry);
        }

        [DataRow("1", "Sergio", "Gimenez", "19/09/1996", "1,Sergio,Gimenez,19/09/1996 0:00:00")]
        [TestMethod()]
        public void JsonTest(String id, String name, String surname, String DateOfBirth, String testEntry)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;
            student = iStudent.Add(student, 'J');
            readStudent = utils.ReadFromJson();
            readLineFromFile = readStudent.StudentId + "," + readStudent.Name + "," + readStudent.Surname + "," + readStudent.DateOfBirth;
            Assert.AreEqual(readLineFromFile, testEntry);
        }

        [DataRow("1", "Sergio", "Gimenez", "19/09/1996", "1,Sergio,Gimenez,19/09/1996 0:00:00")]
        [TestMethod()]
        public void XmlTest(String id, String name, String surname, String DateOfBirth, String testEntry)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;
            student = iStudent.Add(student, 'X');
            readStudent = utils.ReadFromXml();
            readLineFromFile = readStudent.StudentId + "," + readStudent.Name + "," + readStudent.Surname + "," + readStudent.DateOfBirth;
            Assert.AreEqual(readLineFromFile, testEntry);
        }
    }
}