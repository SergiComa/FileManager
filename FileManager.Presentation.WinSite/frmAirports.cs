using FileManager.DataAccess.DAO.Aeroport;
using FileManager.Presentation.WinSite.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Presentation.WinSite
{
    public partial class frmAirports : Form
    {
        private SingletonVuelo vuelosSingleton = null;

        public frmAirports()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            InitializeComponent();
        }

        public string language = Properties.Settings.Default.Language;


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
                throw new Exception("ExceptionDefault");
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

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeLanguage(string language)
        {
            foreach (Control c in this.Controls)
            {
                ComponentResourceManager resource = new ComponentResourceManager(typeof(frmAirports));
                resource.ApplyResources(c, c.Name, new CultureInfo(language));
            }
          }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            language = "es-ES";
            spanishToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Checked = false;

            Properties.Settings.Default.Language = "es-ES";
            Properties.Settings.Default.Save();
        }

        private void englishToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //dlgChangeLanguage dialog = new dlgChangeLanguage();
            DialogResult dialog = MessageBox.Show("Reiniciar el idioma?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                language = "en-US";
                spanishToolStripMenuItem.Checked = false;
                englishToolStripMenuItem.Checked = true;

                Properties.Settings.Default.Language = "en-US";
                Properties.Settings.Default.Save();

                Application.Restart();
            }

        }
    }
}
