using FileManager.Common.Models;
using FileManager.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            String sAttr = ConfigurationManager.AppSettings.Get("XmlPath");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IStudentDAO iStudentDAO = new StudentDAO();
            Student student = new Student();
            student.StudentId = Int32.Parse(txtStudentId.Text);
            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            student.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text).Date;
            IAbstractFileFactory fileFactory = new TextFactory();
            var file = fileFactory.CreateFile();
            bool fileExists = file.CheckFileExists();
            if (fileExists != true)
            {
                file.CreateFile();
            }
            iStudentDAO.Add(student, Common.Models.EnumTypeFactory.TXT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IStudentDAO iStudentDAO = new StudentDAO();
            Student student = new Student();
            student.StudentId = Int32.Parse(txtStudentId.Text);
            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            student.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text).Date;
            IAbstractFileFactory fileFactory = new XmlFactory();
            var file = fileFactory.CreateFile();
            bool fileExists = file.CheckFileExists();
            if (fileExists != true)
            {
                file.CreateFile();
            }
            iStudentDAO.Add(student, Common.Models.EnumTypeFactory.XML);
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            IStudentDAO iStudentDAO = new StudentDAO();
            Student student = new Student();
            student.StudentId = Int32.Parse(txtStudentId.Text);
            student.Name = txtName.Text;
            student.Surname = txtSurname.Text;
            student.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text).Date;
            IAbstractFileFactory fileFactory = new JsonFactory();
            var file = fileFactory.CreateFile();
            bool fileExists = file.CheckFileExists();
            if (fileExists != true)
            {
                file.CreateFile();
            }
            iStudentDAO.Add(student, Common.Models.EnumTypeFactory.JSON);
        }
    }
}
