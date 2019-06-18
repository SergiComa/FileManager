using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace FileManager.DataAccess.DAO
{
    class XmlFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            XDocument xmlDoc = XDocument.Load(pathToFile);
            XElement students = xmlDoc.Element("Root");
            students.Add(new XElement("Student",
                         new XAttribute("Id", student.StudentId),
                         new XElement("Name", student.Name),
                         new XElement("Surname", student.Surname),
                         new XElement("DateOfBirth", student.DateOfBirth.Date.ToString("dd/MM/yyyy"))));
            xmlDoc.Save(pathToFile);
        }

        public bool CheckFileExists()
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            if (File.Exists(pathToFile))
            {
                return true;
            }
            return false;
        }

        public void CreateFile()
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            XDocument doc = new XDocument();
            doc.Add(new XElement("Root", ""));
            doc.Save(pathToFile);
        }

        public String ReturnStringStudentById(int studentId)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            XDocument xmlDoc = XDocument.Load(pathToFile);
            IEnumerable<XElement> student =
                from el in xmlDoc.Elements("Student")
                where (string)el.Attribute("Type") == "Billing"
                select el;
            return student.ToString();
        }
    }
}

