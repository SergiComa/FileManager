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
        private Singleton vuelosSingleton = null;

        public frmAirports()
        {
            InitializeComponent();
        }

        private void frmAirports_Load(object sender, EventArgs e)
        {
            vuelosSingleton = Singleton.Instance;
            InitializeOriginComboBox();

            string selectedCity = originCbo.SelectedItem.ToString();
            InitializeDestinationCombobox(selectedCity);
        }

        private void InitializeOriginComboBox()
        {
            int size = vuelosSingleton.FlightsDictonary.Keys.Count;
            string[] items = new string[size];

            for (int i = 0; i < size; ++i)
            {
                items[i] = vuelosSingleton.FlightsDictonary.Keys.ElementAt(i).Name;
            }
            originCbo.DataSource = items;
            originCbo.SelectedIndex = 0;
        }

        private void InitializeDestinationCombobox(string cityName)
        {

            List<Aeroport> airports;
            bool found = vuelosSingleton.FlightsDictonary.TryGetValue(new Aeroport(cityName), out airports);
            if (!found)
            {
                throw new Exception("No airports");
            }

            string[] airportNames = new string[airports.Count];
            for (int i = 0; i < airportNames.Length; ++i)
            {
                airportNames[i] = airports[i].Name;
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
