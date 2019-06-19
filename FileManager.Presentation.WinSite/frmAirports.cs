using FileManager.DataAccess.DAO.Aeroport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmAirports : Form
    {
        private SingletonVuelo vuelosSingleton = null;

        public frmAirports()
        {
            InitializeComponent();
        }

        private void frmAirports_Load(object sender, EventArgs e)
        {
            vuelosSingleton = SingletonVuelo.Instance;
            InitializeOriginComboBox();

            string selectedCity = originCbo.SelectedItem.ToString();
            InitializeDestinationCombobox(selectedCity);
        }

        private void InitializeOriginComboBox()
        {
            int size = SingletonVuelo.FlightsDictonary.Keys.Count;
            string[] items = new string[size];
            int counter = 0;

            for (int i = 0; i < size; ++i)
            {
                items[i] = SingletonVuelo.FlightsDictonary.Keys.ElementAt(i).Name;
            }

            foreach (var single in SingletonVuelo.FlightsDictonary.Keys)
            {
                items[counter] = SingletonVuelo.FlightsDictonary.Keys.ElementAt(counter).Name;
                ++counter;
            }

            originCbo.DataSource = items;
            originCbo.SelectedIndex = 0;
        }

        private void InitializeDestinationCombobox(string cityName)
        {

            List<Aeroport> airports;
            int counter = 0;
            bool found = SingletonVuelo.FlightsDictonary.TryGetValue(new Aeroport(cityName), out airports);
            if (!found)
            {
                throw new Exception("Not found for now");
            }

            string[] airportNames = new string[airports.Count];

            foreach (Aeroport airport in airports)
            {
                airportNames[counter] = airports[counter].Name;
                ++counter;
            }

            destinationCbo.DataSource = airportNames;
            destinationCbo.SelectedItem = 0;
        }

        private void originCbo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedCity = originCbo.SelectedItem.ToString();
            InitializeDestinationCombobox(selectedCity);
        }

        private void destinationCbo_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
