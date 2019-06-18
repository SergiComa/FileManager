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

    //Abstract Factory
    public interface AbstractFileFactory
    {
        IGeneratedFile CreateFile();
    }

    //Abstract object
    public interface IGeneratedFile
    {
        void WriteToFile(Student student);
        void CreateFile();
        bool CheckFileExists();
        String ReturnStringStudentById(int studentId);
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

        public String ReturnStringStudentById(int studentId)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            String auxStudent;
            String givenStudent = null;
            String[] values;
            bool studentFound = false;
            System.IO.StreamReader file =  new System.IO.StreamReader(pathToFile);
            while (((auxStudent = file.ReadLine()) != null) && studentFound == false)
            {
               values = auxStudent.Split(',');
                if (values[0] == studentId.ToString())
                {
                    studentFound = true;
                    givenStudent = auxStudent;
                }
            }
            return givenStudent;
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
            int testNumber = 3;
            int totalLines = 0;
            using (StreamReader r = new StreamReader(pathToFile))
            {
                while (r.ReadLine() != null) { totalLines++; }
                r.DiscardBufferedData();
                r.BaseStream.Seek(0, SeekOrigin.Begin);
                r.BaseStream.Position = 0;
                string json = r.ReadToEnd();
                //Check number of lines and identify the number of objects through it
                switch (testNumber) 
                {
                    case 0:
                        newJson = JsonConvert.SerializeObject(student, new JsonSerializerSettings { Formatting = Formatting.Indented});
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
            //Initialize to init list
            File.Create(pathToFile).Close();
        }

        public String ReturnStringStudentById(int studentId)
        {
            return "a";
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
