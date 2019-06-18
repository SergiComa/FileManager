using FileManager.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileManager.DataAccess.DAO
{
    public class Utils
    {

        static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        /// <summary>
        /// Returns the last line from a txt file
        /// </summary>
        /// <returns></returns>
        public String ReadFromTxt()
        {
            string pathToFile = Path.Combine(path, "log.txt");
            String lineFromFile = "No line to read";
            lineFromFile = File.ReadLines(pathToFile).Last();
            return lineFromFile;
        }

        /// <summary>
        /// Returns the last line from a json file and deserializes it
        /// </summary>
        /// <returns></returns>
        public Student ReadFromJson()
        {
            string pathToFile = Path.Combine(path, "jsonStudents.json");
            String lineFromFile = "No line to read";
            lineFromFile = File.ReadLines(pathToFile).Last();
            Student student = JsonConvert.DeserializeObject<Student>(lineFromFile);
            return student;
        }

        public Student ReadFromXml()
        {
            String pathToFile = Path.Combine(path, "xmlStudents.xml");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            Student student = new Student();
            using (var sr = new StreamReader(pathToFile))
            {
                 student = (Student)xmlSerializer.Deserialize(sr);
            }
            return student;
        }

        /// <summary>
        /// Returns a factory depending on the type passed
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public IAbstractFileFactory DetectFactory(Common.Models.EnumTypeFactory enumType)
        {
            IAbstractFileFactory fileFactory;
            switch (enumType)
            {
                case Common.Models.EnumTypeFactory.TXT:
                    fileFactory = new TextFactory();
                    break;
                case Common.Models.EnumTypeFactory.XML:
                    fileFactory = new XmlFactory();
                    break;
                case Common.Models.EnumTypeFactory.JSON:
                    fileFactory = new JsonFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return fileFactory;
        }
    }
}
