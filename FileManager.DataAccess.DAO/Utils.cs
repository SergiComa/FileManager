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
        static string pathToFile = Path.Combine(path, "log.txt");
        /// <summary>
        /// Returns the last line from a file
        /// </summary>
        /// <returns></returns>
        public String ReadFromTxt()
        {
            String line = "No line to read";
            line = File.ReadLines(pathToFile).Last();
            return line;
        }
    }
}
