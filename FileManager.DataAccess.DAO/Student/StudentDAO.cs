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
        public Student Add(Student student, Common.Models.EnumTypeFactory enumType)
        {
            bool FileExistsInDirectory;
            Utils utilsFactory = new Utils();
            IAbstractFileFactory fileFactory = utilsFactory.DetectFactory(enumType);
            var file = fileFactory.CreateFile();
            //Separar en clases
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
