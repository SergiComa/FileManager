using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FileManager.Common.Models;
using Newtonsoft.Json;

namespace FileManager.DataAccess.DAO
{
    //Abstract object
    public interface IGeneratedFile
    {
        void WriteToFile(Student student);
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
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            String pathToFile = Path.Combine(path, "xmlStudents.xml");

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            TextWriter textWriter = new StreamWriter(pathToFile);
            xmlSerializer.Serialize(textWriter, student);
            //Important to close the stream, otherwise the writer will lock the file and
            //other component will be able to perform R/W to it.
            textWriter.Close();
        }
    }
}
