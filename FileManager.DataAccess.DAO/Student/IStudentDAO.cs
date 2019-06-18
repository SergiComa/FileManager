using FileManager.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO
{
    public interface IStudentDAO
    {
        Student Add(Student student, Common.Models.EnumTypeFactory enumType);
    }
}
