using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FileManager.Common.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml.Linq;

namespace FileManager.DataAccess.DAO
{
    //Abstract object
    public interface IGeneratedFile
    {
        void WriteToFile(Student student);
        void CreateFile();
        bool CheckFileExists();
    }

    //Abstract Factory
    public interface AbstractFileFactory
    {
        IGeneratedFile CreateFile();
    }

    //Concrete text factory
    class TextFactory : AbstractFileFactory
    {
        public IGeneratedFile CreateFile()
        {
            return new TextFile();
        }
    }

    //Concrete text object
    class TextFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            String parsedString = student.StudentId + "," + student.Name + "," + student.Surname + "," + student.DateOfBirth.Date.ToString("d");
            var textWriter = new StreamWriter(pathToFile, true);
            using (textWriter)
            {
                textWriter.WriteLine(parsedString);
            }

            textWriter.Close();
        }

        public bool CheckFileExists()
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            if (File.Exists(pathToFile))
            {
                return true;
            }
            return false;
        }

        public void CreateFile()
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            File.Create(pathToFile).Close();
        }
    }

    //Concrete text factory
    class JsonFactory : AbstractFileFactory
    {
        public IGeneratedFile CreateFile()
        {
            return new JsonFile();
        }
    }

    //Concrete text object
    class JsonFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("JsonPath");
            String newJson;
            int totalLines = 0;
            using (StreamReader r = new StreamReader(pathToFile))
            {
                while (r.ReadLine() != null) { totalLines++; }
                r.DiscardBufferedData();
                r.BaseStream.Seek(0, SeekOrigin.Begin);
                r.BaseStream.Position = 0;
                string json = r.ReadToEnd();
                //How to fix the whole thing when there's only one input in the database
                //Problem: If there's only one object I can't assign to it a List so a
                //special method have to be made, but can't distinguish if there's just
                //a single object or multiple. 3 passed to resort to default
                switch (3)
                {
                    case 0:
                        newJson = JsonConvert.SerializeObject(student);
                        break;
                    case 1:
                        Student singleStudent = JsonConvert.DeserializeObject<Student>(json);
                        List<Student> singleStudentList = new List<Student>();
                        singleStudentList.Add(singleStudent);
                        singleStudentList.Add(student);
                        newJson = JsonConvert.SerializeObject(singleStudentList);
                        break;
                    default:
                        List<Student> students = JsonConvert.DeserializeObject<List<Student>>(json);
                        students.Add(student);
                        newJson = JsonConvert.SerializeObject(students);
                        break;
                }
            }
            File.WriteAllText(pathToFile, newJson);
        }

        public bool CheckFileExists()
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("JsonPath");
            if (File.Exists(pathToFile))
            {
                return true;
            }
            return false;
        }

        public void CreateFile()
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("JsonPath");
            File.Create(pathToFile).Close();
        }
    }

    //Concrete text factory
    class XmlFactory : AbstractFileFactory
    {
        public IGeneratedFile CreateFile()
        {
            return new XmlFile();
        }
    }

    //Concrete text object
    class XmlFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("XmlPath");
            XDocument xmlDoc = XDocument.Load(pathToFile);
            XElement students = xmlDoc.Element("Root");
            students.Add(new XElement("Student",
                         new XElement("Id", student.StudentId),
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
    }
}
