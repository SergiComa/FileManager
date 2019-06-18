using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace FileManager.DataAccess.DAO
{
    class JsonFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("JsonPath");
            var json = File.ReadAllText(pathToFile);
            var students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
            students.Add(student);
            json = JsonConvert.SerializeObject(students, new JsonSerializerSettings { Formatting = Formatting.Indented });
            File.WriteAllText(pathToFile, json);
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
}
