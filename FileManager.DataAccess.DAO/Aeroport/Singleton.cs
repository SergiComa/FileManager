using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileManager.DataAccess.DAO.Aeroport
{
    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static readonly object padlock = new object();
        public string pathToFile = ConfigurationManager.AppSettings.Get("AeroportPath");
        public Dictionary<Aeroport, List<Aeroport>> FlightsDictonary { get; private set;}

        private Singleton()
        {
            FlightsDictonary = new Dictionary<Aeroport, List<Aeroport>>();
            getFlightsFromFile(pathToFile);
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            
                            return new Singleton();
                        }
                    }
                }
                return instance;
            }
        }

        private void getFlightsFromFile(String pathToFile)
        {
            XDocument document = XDocument.Load(pathToFile);
            XElement root = document.Element("airports");

            var airports = from element in root.Elements()
                           select element;

            foreach (XElement connection in airports)
            {
                string name = connection.Attribute("origin").Value;
                var connections = connection.Elements("connection");

                List<Aeroport> airportConnections = new List<Aeroport>();
                foreach (XElement con in connections)
                {
                    airportConnections.Add(new Aeroport(con.Value));
                }
                FlightsDictonary.Add(new Aeroport(name), airportConnections);
            }
        }
    }
}
