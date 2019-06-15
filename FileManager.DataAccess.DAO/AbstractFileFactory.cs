using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.DataAccess.DAO
{
    //Abstract object
    interface GeneratedFile
    {
        void WriteToFile(String textToWrite);
    }

    //Abstract Factory
    interface AbstractFileFactory
    {
        GeneratedFile CreateFile();
    }

    //Concrete text factory
    class TextFactory : AbstractFileFactory
    {
        public GeneratedFile CreateFile()
        {
            return new TextFile();
        }
    }

    //Concrete text object
    class TextFile : GeneratedFile
    {
        public void WriteToFile(String textToWrite)
        {
            Utils logger = new Utils();
            logger.WriteToFile("I'm properly creating a text factory");
        }
    }

    //Concrete text factory
    class JsonFactory : AbstractFileFactory
    {
        public GeneratedFile CreateFile()
        {
            return new TextFile();
        }
    }

    //Concrete text object
    class JsonFile : GeneratedFile
    {
        public void WriteToFile(String textToWrite)
        {
            Utils logger = new Utils();
            logger.WriteToFile("I'm properly creating a Json factory");
        }
    }

    //Concrete text factory
    class XmlFactory : AbstractFileFactory
    {
        public GeneratedFile CreateFile()
        {
            return new TextFile();
        }
    }

    //Concrete text object
    class XmlFile : GeneratedFile
    {
        public void WriteToFile(String textToWrite)
        {
            Utils logger = new Utils();
            logger.WriteToFile("I'm properly creating a Xml factory");
        }
    }


}
