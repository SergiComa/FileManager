using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO
{
    class JsonFactory : AbstractFileFactory
    {
        public IGeneratedFile CreateFile()
        {
            return new JsonFile();
        }
    }
}
