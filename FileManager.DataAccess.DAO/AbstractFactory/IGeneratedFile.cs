using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Common.Models;

namespace FileManager.DataAccess.DAO
{
    public interface IGeneratedFile
    {
        //Que retorne un Student el cual ha sido insertado + mb generic
        void WriteToFile(Student student);
        //Devuelva booleano
        void CreateFile();
        bool CheckFileExists();
        String ReturnStringStudentById(int studentId);
    }
}
