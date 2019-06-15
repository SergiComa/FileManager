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
        static string pathToFile = Path.Combine(path, "data.txt");
        /// <summary>
        /// Writes information to a file in a comma separated value manner
        /// </summary>
        /// <param name="studentData"></param>
        public void WriteToFile(String studentData)
        {
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile);
                TextWriter textWriter = new StreamWriter(pathToFile);
                textWriter.WriteLine(studentData);
                textWriter.Close();
            }
            else if (File.Exists(pathToFile))
            {
                using (var tw = new StreamWriter(pathToFile, true))
                {
                    tw.WriteLine(studentData);
                }
            }
        }

        /// <summary>
        /// Returns the last line from a file
        /// </summary>
        /// <returns></returns>
        public String ReadFromFile()
        {
            String line = "No line to read";
            line = File.ReadLines(pathToFile).Last();
            return line;
        }
    }
}
