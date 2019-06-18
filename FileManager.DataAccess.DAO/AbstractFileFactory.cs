using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FileManager.Common.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Xml.Linq;

namespace FileManager.DataAccess.DAO
{
    public interface AbstractFileFactory
    {
        IGeneratedFile CreateFile();
    }        
}
