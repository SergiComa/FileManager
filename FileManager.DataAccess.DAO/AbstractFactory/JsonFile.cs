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
            try
            {
                var students = JsonConvert.DeserializeObject<List<Student>>(json) ?? new List<Student>();
                students.Add(student);
                json = JsonConvert.SerializeObject(students, new JsonSerializerSettings { Formatting = Formatting.Indented });
                File.WriteAllText(pathToFile, json);
            }catch(JsonException jsonEx)
            {
                using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings.Get("LogPath")))
                {
                    Utils.Write2Log(jsonEx.Message, writer);
                }
            }

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

        public Student ReturnStringStudentById(int studentId)
        {
            return new Student();
        }
    }
}
