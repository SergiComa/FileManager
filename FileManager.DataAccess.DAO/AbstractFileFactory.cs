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
            using (var tw = new StreamWriter(pathToFile, true))
            {
                tw.WriteLine(parsedString);
            }
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
            File.Create(pathToFile);
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
            String jsonData = JsonConvert.SerializeObject(student);
            System.IO.File.WriteAllText(pathToFile, jsonData);
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
            File.Create(pathToFile);
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
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            TextWriter textWriter = new StreamWriter(pathToFile);
            xmlSerializer.Serialize(textWriter, student);
            textWriter.Close();
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
            File.Create(pathToFile);
        }
    }
}
