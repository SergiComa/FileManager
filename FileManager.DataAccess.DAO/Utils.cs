using FileManager.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// Returns a factory depending on the type passed
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public AbstractFileFactory DetectFactory(char factory)
        {
            AbstractFileFactory fileFactory;
            switch (factory)
            {
                case 'T':
                    fileFactory = new TextFactory();
                    break;
                case 'X':
                    fileFactory = new XmlFactory();
                    break;
                case 'J':
                    fileFactory = new JsonFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return fileFactory;
        }
    }
}
