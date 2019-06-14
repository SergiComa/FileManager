using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Common.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
