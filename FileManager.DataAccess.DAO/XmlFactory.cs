using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO
{
    class XmlFactory : AbstractFileFactory
    {
        public IGeneratedFile CreateFile()
        {
            return new XmlFile();
        }
    }
}
