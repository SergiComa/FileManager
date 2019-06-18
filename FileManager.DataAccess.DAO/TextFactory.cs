using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO
{
        class TextFactory : AbstractFileFactory
        {
            public IGeneratedFile CreateFile()
            {
                return new TextFile();
            }
        }
}
