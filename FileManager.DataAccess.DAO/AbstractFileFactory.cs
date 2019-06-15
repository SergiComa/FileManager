using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;
using Newtonsoft.Json;

namespace FileManager.DataAccess.DAO
{
    //Abstract object
    interface IGeneratedFile
    {
        void WriteToFile(Student student);
    }

    //Abstract Factory
    interface AbstractFileFactory
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
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathToFile = Path.Combine(path, "log.txt");
            String parsedString = student.StudentId + "," + student.Name + "," + student.Surname + "," + student.DateOfBirth.Date.ToString("d");
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile);
                TextWriter textWriter = new StreamWriter(pathToFile);
                textWriter.WriteLine(parsedString);
                textWriter.Close();
            }
            else if (File.Exists(pathToFile))
            {
                using (var tw = new StreamWriter(pathToFile, true))
                {
                    tw.WriteLine(parsedString);
                }
            }
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
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String pathToFile = Path.Combine(path, "jsonStudents.json");
            String jsonData = JsonConvert.SerializeObject(student);
            System.IO.File.WriteAllText(pathToFile, jsonData);
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
           /* Utils logger = new Utils();
            logger.WriteToFile("I'm properly creating a Xml factory");*/
        }
    }
}
