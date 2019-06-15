using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Common.Models
{
    class Utils
    {
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static string pathToFile = Path.Combine(path, "data.txt");
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
    }
}
