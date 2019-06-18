using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;
using System.Configuration;
using System.IO;

namespace FileManager.DataAccess.DAO
{
    class TextFile : IGeneratedFile
    {
        public void WriteToFile(Student student)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            String parsedString = student.StudentId + "," + student.Name + "," + student.Surname + "," + student.DateOfBirth.Date.ToString("d");
            var textWriter = new StreamWriter(pathToFile, true);
            using (textWriter)
            {
                textWriter.WriteLine(parsedString);
            }

            textWriter.Close();
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
            File.Create(pathToFile).Close();
        }

        public String ReturnStringStudentById(int studentId)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            String auxStudent;
            String givenStudent = null;
            String[] values;
            bool studentFound = false;
            System.IO.StreamReader file = new System.IO.StreamReader(pathToFile);
            while (((auxStudent = file.ReadLine()) != null) && studentFound == false)
            {
                values = auxStudent.Split(',');
                if (values[0] == studentId.ToString())
                {
                    studentFound = true;
                    givenStudent = auxStudent;
                }
            }
            return givenStudent;
        }
    }
}
