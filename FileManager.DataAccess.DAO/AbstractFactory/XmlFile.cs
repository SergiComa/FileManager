using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;
using System.Configuration;
using System.IO;
using System.Xml.Linq;
using System.Security;
using System.Xml;

namespace FileManager.DataAccess.DAO
{
    class XmlFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            try
            {
                XDocument xmlDoc = XDocument.Load(pathToFile);
                XElement students = xmlDoc.Element("Students");
                students.Add(
                    new XElement("Student",
                    new XAttribute("Id", student.StudentId),
                             new XElement("Name", student.Name),
                             new XElement("Surname", student.Surname),
                             new XElement("DateOfBirth", Convert.ToString(student.DateOfBirth))
                             ));
                xmlDoc.Save(pathToFile);
            }
            catch (ArgumentNullException nullEx)
            {
                using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings.Get("LogPath")))
                {
                    Utils.Write2Log(nullEx.Message, writer);
                    throw;
                }
            }
            catch (SecurityException secEx)
            {
                using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings.Get("LogPath")))
                {
                    Utils.Write2Log(secEx.Message, writer);
                    throw;
                }
            }
            catch (FileNotFoundException foundEx)
            {
                using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings.Get("LogPath")))
                {
                    Utils.Write2Log(foundEx.Message, writer);
                    throw;
                }
            }

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
            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;
            xmlSettings.CheckCharacters = true;
            xmlSettings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create(ConfigurationManager.AppSettings.Get("XmlPath"), xmlSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Students");
                writer.Flush();
                writer.Close();
            }
        }

        public Student ReturnStringStudentById(int studentId)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            Student auxStudent = new Student();
            List<Student> list = new List<Student>();
            XDocument xDoc = XDocument.Load(pathToFile);
            XElement root = xDoc.Root;

            var studentSurname =
                from el in root.Elements("Student")
                where (string)el.Attribute("Id") == studentId.ToString()
                select el.Element("Surname");

            var student = from element in root.Elements("Student")
                          where element.Attribute("Id").Value.Equals(studentId.ToString())
                          select element;

            XElement foundStudent = student.First();
            auxStudent.StudentId = Int32.Parse(foundStudent.Attribute("Id").Value);
            auxStudent.Name = foundStudent.Element("Name").Value;
            auxStudent.Surname = foundStudent.Element("Surname").Value;
            auxStudent.DateOfBirth = Convert.ToDateTime(foundStudent.Element("DateOfBirth").Value);

            return auxStudent;
        }
    }
}

