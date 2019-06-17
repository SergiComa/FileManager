using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;

namespace FileManager.DataAccess.DAO
{
    public class StudentDAO : IStudentDAO
    {
        /// <summary>
        /// Adds a student information to a file
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Add(Student student, char FactoryType)
        {
            bool FileExistsInDirectory;
            Utils utilsFactory = new Utils();
            //Single Responsability
            AbstractFileFactory fileFactory = utilsFactory.DetectFactory(FactoryType);
            var file = fileFactory.CreateFile();
            FileExistsInDirectory = file.CheckFileExists();
            if (FileExistsInDirectory == false)
            {
                file.CreateFile();
            }
            file.WriteToFile(student);
            return student;
        }
    }
}
