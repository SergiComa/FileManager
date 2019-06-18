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
            try
            {
                using (textWriter)
                {
                    textWriter.WriteLine(parsedString);
                }
                textWriter.Close();
            }
            catch (IOException ex)
            {
                using (StreamWriter writer = File.AppendText(ConfigurationManager.AppSettings.Get("LogPath")))
                {
                    Utils.Write2Log(ex.Message, writer);
                }
            }

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

        public Student ReturnStringStudentById(int studentId)
        {
            String pathToFile = ConfigurationManager.AppSettings.Get("TxtPath");
            String stringStudent;
            String givenStudent = null;
            String[] values;
            Student auxStudent = new Student();
            bool studentFound = false;
            System.IO.StreamReader file = new System.IO.StreamReader(pathToFile);
            while (((stringStudent = file.ReadLine()) != null) && studentFound == false)
            {
                values = stringStudent.Split(',');
                if (values[0] == studentId.ToString())
                {
                    studentFound = true;
                    givenStudent = stringStudent;
                    auxStudent.StudentId = Int32.Parse(values[0]);
                    auxStudent.Name = values[1];
                    auxStudent.Surname = values[2];
                    auxStudent.DateOfBirth = DateTime.Parse(values[3]);
                }
            }
            return auxStudent;
        }
    }
}
