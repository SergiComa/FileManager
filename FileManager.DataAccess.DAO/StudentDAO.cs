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
            AbstractFileFactory fileFactory;
            switch (FactoryType)
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
            var file = fileFactory.CreateFile();
            file.WriteToFile(student);
            return student;
        }
    }
}
