using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FileManager.DataAccess.DAO.Aeroport
{
    public sealed class SingletonVuelo
    {
        private static SingletonVuelo instance = null;
        private static readonly object padlock = new object();
        public static string pathToFile = ConfigurationManager.AppSettings.Get("AeroportPath");
        public static Dictionary<Aeroport, List<Aeroport>> FlightsDictonary { get; private set;}
        public Guid SingletonGuid { get; set; }


        //Del objeto al no tener static
        private SingletonVuelo()
        {
            FlightsDictonary = new Dictionary<Aeroport, List<Aeroport>>();
            AddFlightsFromFile(pathToFile);
            SingletonGuid = Guid.NewGuid();
        }

        public static SingletonVuelo Instance
        {
            get
            {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonVuelo();
                        }
                    }
                return instance;
            }
        }

        private void AddFlightsFromFile(String pathToFile)
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
