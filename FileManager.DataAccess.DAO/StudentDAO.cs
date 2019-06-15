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
        public Student Add(Student student)
        {
            Utils fileUtils = new Utils();
            String parsedString = student.StudentId + "," + student.Name + "," + student.Surname + "," + student.DateOfBirth.Date.ToString("d");
            fileUtils.WriteToFile(parsedString);
            return student;
        }
    }
}
