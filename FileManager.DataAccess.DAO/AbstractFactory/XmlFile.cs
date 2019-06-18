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
            var studentXml = xDoc.Descendants("Student");
            foreach (var studentNode in studentXml)
            {
                auxStudent.StudentId = Int32.Parse(studentNode.Attribute("Id").Value);
                auxStudent.Name = studentNode.Element("Name").Value;
                auxStudent.Surname = studentNode.Element("Surname").Value;
                auxStudent.DateOfBirth = DateTime.Parse(studentNode.Element("DateOfBirth").Value);
                list.Add(auxStudent);
            }

            return list.Where(s => s.StudentId == studentId).FirstOrDefault();
            /*IEnumerable<XElement> fulStudent =
            from el in root.Elements("Student")
            where (string)el.Attribute("Id") == studentId.ToString()
            select el;

            var studentName =
                from el in root.Elements("Student")
                where (string)el.Attribute("Id") == studentId.ToString()
                select el.Element("Name");
            XElement xName = studentName.First();
            auxStudent.Name = xName.Value;

            var studentSurname =
                from el in root.Elements("Student")
                where (string)el.Attribute("Id") == studentId.ToString()
                select el.Element("Surname");
            XElement xSurname = studentName.First();
            auxStudent.Surname = xName.Value;

            var studentDateOfBirth =
                from el in root.Elements("Student")
                where (string)el.Attribute("Id") == studentId.ToString()
                select el.Element("DateOfBirth");
            XElement xDateOfBirth = studentName.First();
            auxStudent.DateOfBirth = DateTime.Parse(xDateOfBirth.Value);

            auxStudent.StudentId = studentId;*/


        }
    }
}

