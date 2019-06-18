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

            readStudent = iStudent.Add(student, Common.Models.EnumTypeFactory.TXT);
            readLineFromFile = utils.ReadFromTxt();
            Assert.AreEqual(readLineFromFile, testEntry);
        }

        [DataRow("2", "ha", "ah", "18/09/2000", "2,ha,ah,18/09/2000 0:00:00")]
        [TestMethod()]
        public void JsonTest(String id, String name, String surname, String DateOfBirth, String testEntry)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;
            student = iStudent.Add(student, Common.Models.EnumTypeFactory.JSON);
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
            student = iStudent.Add(student, Common.Models.EnumTypeFactory.XML);
            readStudent = utils.ReadFromXml();
            readLineFromFile = readStudent.StudentId + "," + readStudent.Name + "," + readStudent.Surname + "," + readStudent.DateOfBirth;
            Assert.AreEqual(readLineFromFile, testEntry);
        }

        [DataRow(2, Common.Models.EnumTypeFactory.TXT, "2", "ayy", "lmao", "11/11/1111 0:00:00")]
        [TestMethod()]
        public void SearchTxtById(int idStudent, Common.Models.EnumTypeFactory typeFactory, String id, String name, String surname, String DateOfBirth)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;
            IAbstractFileFactory fileFactory = utils.DetectFactory(typeFactory);
            var file = fileFactory.CreateFile();
            readStudent = file.ReturnStringStudentById(idStudent);
            Assert.IsTrue(student.Equals(readStudent));
        }

        [DataRow(2, Common.Models.EnumTypeFactory.XML, "2", "sdf", "sdf", "11/11/1133 0:00:00")]
        [TestMethod()]
        public void SearchXmlById(int idStudent, Common.Models.EnumTypeFactory typeFactory, String id, String name, String surname, String DateOfBirth)
        {
            student.StudentId = Int32.Parse(id);
            student.Name = name;
            student.Surname = surname;
            student.DateOfBirth = DateTime.Parse(DateOfBirth).Date;
            IAbstractFileFactory fileFactory = utils.DetectFactory(typeFactory);
            var file = fileFactory.CreateFile();
            readStudent = file.ReturnStringStudentById(idStudent);
            Assert.IsTrue(student.Equals(readStudent));
        }

    }
}